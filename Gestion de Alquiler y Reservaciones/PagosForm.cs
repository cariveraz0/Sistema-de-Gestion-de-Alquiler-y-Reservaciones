using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gestion_de_Alquiler_y_Reservaciones
{
    public partial class PagosForm : Form
    {
        private static readonly Color ColorActivo = ColorTranslator.FromHtml("#C84F24");
        private static readonly Color ColorInactivo = ColorTranslator.FromHtml("#E0DBD2");
        private static readonly Color TextoInactivo = ColorTranslator.FromHtml("#666666");

        private static readonly NumberFormatInfo FormatoLempiras = new NumberFormatInfo
        {
            CurrencySymbol = "L",
            CurrencyDecimalDigits = 2,
            CurrencyGroupSeparator = ",",
            CurrencyDecimalSeparator = "."
        };

        private DataTable tablalocal;

        private int? idCuotaSeleccionada = null;
        private int? idReservacionSeleccionada = null;

        private class ResultadoCuota
        {
            public int IdCuota { get; set; }
            public string Cliente { get; set; }
            public string Propiedad { get; set; }
            public DateTime Periodo { get; set; }
            public decimal MontoCuota { get; set; }
            public decimal Mora { get; set; }
            public decimal Saldo { get; set; }
            public string Estado { get; set; }

            public override string ToString() =>
                $"{Cliente} — {Propiedad} · {Periodo.ToString("MMMM yyyy", new CultureInfo("es-HN"))} · {Estado} · Saldo {Saldo.ToString("C", FormatoLempiras)}";
        }

        private class ResultadoReservacion
        {
            public int IdReservacion { get; set; }
            public string Cliente { get; set; }
            public string Propiedad { get; set; }
            public DateTime Entrada { get; set; }
            public DateTime Salida { get; set; }
            public decimal MontoTotal { get; set; }
            public decimal Saldo { get; set; }
            public string Estado { get; set; }

            public override string ToString() =>
                $"{Cliente} — {Propiedad} · {Entrada:dd/MM/yyyy} al {Salida:dd/MM/yyyy} · {Estado} · Saldo {Saldo.ToString("C", FormatoLempiras)}";
        }
        public PagosForm()
        {
            InitializeComponent();

            ActivarTabNuevo();

            ConfigurarDataGridView(dgvHistorial);

            cmbResultadosCuota.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbResultadosReserv.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbResultadosCuota.SelectedIndexChanged += cmbResultadosCuota_SelectedIndexChanged;
            cmbResultadosReserv.SelectedIndexChanged += cmbResultadosReserv_SelectedIndexChanged;

            btnBuscarCuota.Click += (s, e) => CargarResultadosCuotas(txtBuscarCuota.Text);
            btnBuscarReserv.Click += (s, e) => CargarResultadosReservaciones(txtBuscarReserv.Text);

            txtBuscarCuota.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { CargarResultadosCuotas(txtBuscarCuota.Text); e.SuppressKeyPress = true; } };
            txtBuscarReserv.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { CargarResultadosReservaciones(txtBuscarReserv.Text); e.SuppressKeyPress = true; } };

            btnGuardar.Click += btnGuardar_Click;
            btnLimpiar.Click += btnLimpiar_Click;

            CargarComboMetodoPago(cmbMetodoPago);
            CargarComboMetodoPago(cmbMetodoPagoR);

            CargarDatosBD();
            cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPagoR.DropDownStyle = ComboBoxStyle.DropDownList;

            LimpiarDetalleCuota();
            LimpiarDetalleReservacion();
            lblResultadosCuota.Text = "Escribe un cliente, contrato o propiedad y presiona Buscar.";
            lblResultadosReserv.Text = "Escribe un cliente, reservación o propiedad y presiona Buscar.";
        }

        public void ConfigurarDataGridView(DataGridView grid)
        {
            Color naranjaTitulo = Color.FromArgb(216, 122, 45);

            grid.RowHeadersVisible = false;
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.RowTemplate.Height = 28;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = Color.White;
            grid.EnableHeadersVisualStyles = false;

            grid.ColumnHeadersDefaultCellStyle.BackColor = naranjaTitulo;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Montserrat", 9, FontStyle.Bold);

            grid.DefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(225, 225, 225);
        }

        private void btnPagos_Click(object sender, EventArgs e) => ActivarTabNuevo();
        private void btnHistorial_Click(object sender, EventArgs e) => ActivarTabHistorial();

        private void ActivarTabNuevo()
        {
            pnlPagos.Visible = true;
            pnlHistorial.Visible = false;
            pnlAccion.Visible = true;
            pnlPagodeCuota.Visible = rbPagodeCuota.Checked;
            pnlPagoReservacion.Visible = rbReservacion.Checked;

            EstiloTabActivo(btnPagos);
            EstiloTabInactivo(btnHistorial);
        }

        private void ActivarTabHistorial()
        {
            pnlHistorial.Visible = true;
            pnlPagos.Visible = false;
            pnlAccion.Visible = false;
            pnlPagodeCuota.Visible = false;
            pnlPagoReservacion.Visible = false;

            EstiloTabActivo(btnHistorial);
            EstiloTabInactivo(btnPagos);

            CargarDatosBD();
        }

        private void EstiloTabActivo(Button btn)
        {
            btn.BackColor = ColorActivo;
            btn.ForeColor = Color.White;
        }

        private void EstiloTabInactivo(Button btn)
        {
            btn.BackColor = ColorInactivo;
            btn.ForeColor = TextoInactivo;
        }

        private void rbTipoPago_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPagodeCuota.Checked)
                MostrarPanelCuota();
            else if (rbReservacion.Checked)
                MostrarPanelReservacion();
        }

        private void MostrarPanelCuota()
        {
            pnlPagodeCuota.Visible = true;
            pnlPagoReservacion.Visible = false;
        }

        private void MostrarPanelReservacion()
        {
            pnlPagodeCuota.Visible = false;
            pnlPagoReservacion.Visible = true;
        }

        private void CargarResultadosCuotas(string busqueda)
        {
            cmbResultadosCuota.DataSource = null;
            idCuotaSeleccionada = null;

            if (string.IsNullOrWhiteSpace(busqueda) || busqueda.Trim().Length < 2)
            {
                pnlPagodeCuota.Enabled = false;
                LimpiarDetalleCuota();
                return;
            }

            string filtro = busqueda.Trim();

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                try
                {
                    conexion.Open();

                    string query = @"
                WITH CuotasPendientes AS (
                    SELECT 
                        CC.IdCuota,
                        CC.IdContrato,
                        CC.NumeroCuota,
                        CC.FechaVencimiento,
                        CC.MontoCuota,
                        CC.MontoMora,
                        CLI.NombreCompleto AS Cliente,
                        CLI.Identidad,
                        P.Codigo AS Propiedad,
                        EP.Nombre AS EstadoPago,
                        ISNULL(SUM(PAG.Monto), 0) AS TotalPagado,
                        (CC.MontoCuota + CC.MontoMora - ISNULL(SUM(PAG.Monto), 0)) AS Saldo,
                        ROW_NUMBER() OVER (
                            PARTITION BY C.IdContrato 
                            ORDER BY CC.FechaVencimiento ASC, CC.NumeroCuota ASC
                        ) AS RowNum
                    FROM CuotasContrato CC
                    INNER JOIN Contratos C ON CC.IdContrato = C.IdContrato
                    INNER JOIN Clientes CLI ON C.IdArrendatario = CLI.IdCliente
                    INNER JOIN Propiedades P ON C.IdPropiedad = P.IdPropiedad
                    INNER JOIN EstadosPago EP ON CC.IdEstadoPago = EP.IdEstadoPago
                    LEFT JOIN Pagos PAG ON CC.IdCuota = PAG.IdCuota
                    WHERE C.IdEstadoContrato = (SELECT IdEstadoContrato FROM EstadosContrato WHERE Nombre = 'Vigente')
                    GROUP BY CC.IdCuota, CC.IdContrato, CC.NumeroCuota, CC.FechaVencimiento, CC.MontoCuota, CC.MontoMora, 
                             CLI.NombreCompleto, CLI.Identidad, P.Codigo, EP.Nombre
                    HAVING (CC.MontoCuota + CC.MontoMora - ISNULL(SUM(PAG.Monto), 0)) > 0
                )
                SELECT IdCuota, Cliente, Propiedad, FechaVencimiento, MontoCuota, MontoMora, Saldo, EstadoPago
                FROM CuotasPendientes
                WHERE RowNum = 1
                  AND (Cliente LIKE '%' + @Filtro + '%' 
                       OR Identidad LIKE '%' + @Filtro + '%' 
                       OR Propiedad LIKE '%' + @Filtro + '%');";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Filtro", filtro);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            var listaResultados = new List<ResultadoCuota>();

                            while (reader.Read())
                            {
                                listaResultados.Add(new ResultadoCuota
                                {
                                    IdCuota = Convert.ToInt32(reader["IdCuota"]),
                                    Cliente = reader["Cliente"].ToString(),
                                    Propiedad = reader["Propiedad"].ToString(),
                                    Periodo = Convert.ToDateTime(reader["FechaVencimiento"]),
                                    MontoCuota = Convert.ToDecimal(reader["MontoCuota"]),
                                    Mora = Convert.ToDecimal(reader["MontoMora"]),
                                    Saldo = Convert.ToDecimal(reader["Saldo"]),
                                    Estado = reader["EstadoPago"].ToString()
                                });
                            }

                            if (listaResultados.Count > 0)
                            {
                                cmbResultadosCuota.DataSource = listaResultados;
                                pnlPagodeCuota.Enabled = true;
                            }
                            else
                            {
                                pnlPagodeCuota.Enabled = false;
                                LimpiarDetalleCuota();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar la siguiente cuota pendiente: " + ex.Message, "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarResultadosReservaciones(string busqueda)
        {
            cmbResultadosReserv.DataSource = null;
            idReservacionSeleccionada = null;

            if (string.IsNullOrWhiteSpace(busqueda) || busqueda.Trim().Length < 2)
            {
                pnlPagoReservacion.Enabled = false;
                LimpiarDetalleReservacion();
                return;
            }

            string filtro = busqueda.Trim();

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                try
                {
                    conexion.Open();

                    string query = @"
                SELECT 
                    R.IdReservacion,
                    R.NumeroReservacion,
                    CLI.NombreCompleto AS Cliente,
                    CLI.Identidad,
                    P.Codigo AS Propiedad,
                    R.MontoTotal,
                    ISNULL(SUM(PAG.Monto), 0) AS TotalPagado,
                    (R.MontoTotal - ISNULL(SUM(PAG.Monto), 0)) AS Saldo,
                    ER.Nombre AS EstadoReservacion
                FROM Reservaciones R
                INNER JOIN Clientes CLI ON R.IdCliente = CLI.IdCliente
                INNER JOIN Propiedades P ON R.IdPropiedad = P.IdPropiedad
                INNER JOIN EstadosReservacion ER ON R.IdEstadoReservacion = ER.IdEstadoReservacion
                LEFT JOIN Pagos PAG ON R.IdReservacion = PAG.IdReservacion
                WHERE ER.Nombre NOT IN ('Cancelada', 'Completada')
                GROUP BY R.IdReservacion, R.NumeroReservacion, CLI.NombreCompleto, CLI.Identidad, P.Codigo, R.MontoTotal, ER.Nombre
                HAVING (R.MontoTotal - ISNULL(SUM(PAG.Monto), 0)) > 0
                   AND (CLI.NombreCompleto LIKE '%' + @Filtro + '%' 
                        OR CLI.Identidad LIKE '%' + @Filtro + '%' 
                        OR P.Codigo LIKE '%' + @Filtro + '%' 
                        OR R.NumeroReservacion LIKE '%' + @Filtro + '%');";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Filtro", filtro);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            var listaResultados = new List<ResultadoReservacion>();

                            while (reader.Read())
                            {
                                listaResultados.Add(new ResultadoReservacion
                                {
                                    IdReservacion = Convert.ToInt32(reader["IdReservacion"]),
                                    Cliente = reader["Cliente"].ToString(),
                                    Propiedad = reader["Propiedad"].ToString(),
                                    MontoTotal = Convert.ToDecimal(reader["MontoTotal"]),
                                    Saldo = Convert.ToDecimal(reader["Saldo"]),
                                    Estado = reader["EstadoReservacion"].ToString()
                                });
                            }

                            if (listaResultados.Count > 0)
                            {
                                cmbResultadosReserv.DataSource = listaResultados;
                                pnlPagoReservacion.Enabled = true;
                            }
                            else
                            {
                                pnlPagoReservacion.Enabled = false;
                                LimpiarDetalleReservacion();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar reservaciones pendientes: " + ex.Message, "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AplicarFormatoColumna(DataGridView grid, string nombreColumna, string formato)
        {
            if (grid.Columns[nombreColumna] != null)
                grid.Columns[nombreColumna].DefaultCellStyle.Format = formato;
        }

        private void AplicarFormatoMoneda(DataGridView grid, string nombreColumna)
        {
            if (grid.Columns[nombreColumna] == null) return;
            grid.Columns[nombreColumna].DefaultCellStyle.Format = "C";
            grid.Columns[nombreColumna].DefaultCellStyle.FormatProvider = FormatoLempiras;
        }
        private void cmbResultadosCuota_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cmbResultadosCuota.SelectedItem is ResultadoCuota seleccion)) return;

            txtCliente.Text = seleccion.Cliente;
            textBox1.Text = seleccion.Propiedad;
            textBox2.Text = seleccion.Periodo.ToString("MMMM yyyy", new CultureInfo("es-HN"));

            txtMontoCuota.Text = seleccion.MontoCuota.ToString("C", FormatoLempiras);
            txtMora.Text = seleccion.Mora.ToString("C", FormatoLempiras);
            txtSaldoPendiente.Text = seleccion.Saldo.ToString("C", FormatoLempiras);

            numMontoPagar.Maximum = seleccion.Saldo > 0 ? seleccion.Saldo : 0;
            numMontoPagar.Value = seleccion.Saldo > 0 ? seleccion.Saldo : 0;

            dtpFechaPago.Value = DateTime.Today;
            txtNumeroRecibo.Text = GenerarNumeroReciboPreview();

            idCuotaSeleccionada = seleccion.IdCuota;
        }

        private void cmbResultadosReserv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cmbResultadosReserv.SelectedItem is ResultadoReservacion seleccion)) return;

            txtClienteR.Text = seleccion.Cliente;
            txtPropiedadR.Text = seleccion.Propiedad;

            txtMontoTotalR.Text = seleccion.MontoTotal.ToString("C", FormatoLempiras);
            txtSaldoPendienteR.Text = seleccion.Saldo.ToString("C", FormatoLempiras);

            numMontoPagarR.Maximum = seleccion.Saldo > 0 ? seleccion.Saldo : 0;
            numMontoPagarR.Value = seleccion.Saldo > 0 ? seleccion.Saldo : 0;

            dtpFechaPagoR.Value = DateTime.Today;
            txtNumeroReciboR.Text = GenerarNumeroReciboPreview();

            idReservacionSeleccionada = seleccion.IdReservacion;
        }

        private string GenerarNumeroReciboPreview()
        {
            return "REC-" + DateTime.Today.ToString("yyMMdd") + "-XX";
        }

        private void LimpiarDetalleCuota()
        {
            txtCliente.Clear();
            textBox1.Clear();
            textBox2.Clear();
            txtMontoCuota.Clear();
            txtMora.Clear();
            txtSaldoPendiente.Clear();
            numMontoPagar.Maximum = 100000;
            numMontoPagar.Value = 0;
            txtNumeroRecibo.Clear();
            idCuotaSeleccionada = null;
        }

        private void LimpiarDetalleReservacion()
        {
            txtClienteR.Clear();
            txtPropiedadR.Clear();
            txtMontoTotalR.Clear();
            txtSaldoPendienteR.Clear();
            numMontoPagarR.Maximum = 100000;
            numMontoPagarR.Value = 0;
            txtNumeroReciboR.Clear();
            idReservacionSeleccionada = null;
        }

        private void CargarComboMetodoPago(ComboBox combo)
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand comando = new SqlCommand("SELECT IdMetodoPago, Nombre FROM MetodosPago;", conexion))
                {
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    combo.DataSource = tabla;
                    combo.DisplayMember = "Nombre";
                    combo.ValueMember = "IdMetodoPago";
                    combo.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar métodos de pago: " + ex.Message, 
                    "Error de datos.", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (rbPagodeCuota.Checked)
                GuardarPagoCuota();
            else if (rbReservacion.Checked)
                GuardarPagoReservacion();
        }

        private void GuardarPagoCuota()
        {
            if (idCuotaSeleccionada == null)
            {
                MessageBox.Show("Selecciona una cuota de la lista antes de registrar el pago.", "Falta selección.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbMetodoPago.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un método de pago.", "Falta selección.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numMontoPagar.Value <= 0)
            {
                MessageBox.Show("El monto a pagar debe ser mayor a cero.", "Monto inválido.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCuota = idCuotaSeleccionada.Value;
            decimal montoAbonado = numMontoPagar.Value;
            int idMetodoPago = Convert.ToInt32(cmbMetodoPago.SelectedValue);
            string nombreMetodo = cmbMetodoPago.Text;
            DateTime fechaPago = dtpFechaPago.Value.Date;

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                conexion.Open();
                SqlTransaction transaccion = conexion.BeginTransaction();
                try
                {
                    string numeroRecibo = GenerarNumeroRecibo(conexion, transaccion, nombreMetodo);

                    using (SqlCommand cmdInsert = new SqlCommand(
                        @"INSERT INTO Pagos (NumeroRecibo, IdCuota, IdReservacion, Monto, FechaPago, IdMetodoPago)
                  VALUES (@Recibo, @IdCuota, NULL, @Monto, @Fecha, @Metodo);", conexion, transaccion))
                    {
                        cmdInsert.Parameters.AddWithValue("@Recibo", numeroRecibo);
                        cmdInsert.Parameters.AddWithValue("@IdCuota", idCuota);
                        cmdInsert.Parameters.AddWithValue("@Monto", montoAbonado);
                        cmdInsert.Parameters.AddWithValue("@Fecha", fechaPago);
                        cmdInsert.Parameters.AddWithValue("@Metodo", idMetodoPago);
                        cmdInsert.ExecuteNonQuery();
                    }

                    decimal totalCuotaConMora;
                    using (SqlCommand cmdTotal = new SqlCommand("SELECT (MontoCuota + MontoMora) FROM CuotasContrato WHERE IdCuota = @IdCuota;", conexion, transaccion))
                    {
                        cmdTotal.Parameters.AddWithValue("@IdCuota", idCuota);
                        totalCuotaConMora = Convert.ToDecimal(cmdTotal.ExecuteScalar());
                    }

                    decimal totalPagadoAcumulado;
                    using (SqlCommand cmdPagado = new SqlCommand("SELECT ISNULL(SUM(Monto), 0) FROM Pagos WHERE IdCuota = @IdCuota;", conexion, transaccion))
                    {
                        cmdPagado.Parameters.AddWithValue("@IdCuota", idCuota);
                        totalPagadoAcumulado = Convert.ToDecimal(cmdPagado.ExecuteScalar());
                    }

                    string nuevoEstado = totalPagadoAcumulado >= totalCuotaConMora ? "Pagada" : "Pagada Parcial";

                    using (SqlCommand cmdEstado = new SqlCommand(
                        @"UPDATE CuotasContrato
                  SET IdEstadoPago = (SELECT IdEstadoPago FROM EstadosPago WHERE Nombre = @Estado)
                  WHERE IdCuota = @IdCuota;", conexion, transaccion))
                    {
                        cmdEstado.Parameters.AddWithValue("@Estado", nuevoEstado);
                        cmdEstado.Parameters.AddWithValue("@IdCuota", idCuota);
                        cmdEstado.ExecuteNonQuery();
                    }

                    transaccion.Commit();

                    MessageBox.Show($"Pago registrado exitosamente.\nRecibo: {numeroRecibo}\nEstado actualizado a: {nuevoEstado}", "Transacción Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarResultadosCuotas(txtBuscarCuota.Text);
                    CargarDatosBD();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show("Error al registrar el pago: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GuardarPagoReservacion()
        {
            if (idReservacionSeleccionada == null)
            {
                MessageBox.Show("Selecciona una reservación de la lista antes de registrar el pago.", "Falta selección.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbMetodoPagoR.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un método de pago.", "Falta selección.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numMontoPagarR.Value <= 0)
            {
                MessageBox.Show("El monto a pagar debe ser mayor a cero.", "Monto inválido.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idReservacion = idReservacionSeleccionada.Value;
            decimal montoAbonado = numMontoPagarR.Value;
            int idMetodoPago = Convert.ToInt32(cmbMetodoPagoR.SelectedValue);
            string nombreMetodo = cmbMetodoPagoR.Text;
            DateTime fechaPago = dtpFechaPagoR.Value.Date;

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                conexion.Open();
                SqlTransaction transaccion = conexion.BeginTransaction();
                try
                {
                    string numeroRecibo = GenerarNumeroRecibo(conexion, transaccion, nombreMetodo);

                    using (SqlCommand cmdInsert = new SqlCommand(
                        @"INSERT INTO Pagos (NumeroRecibo, IdCuota, IdReservacion, Monto, FechaPago, IdMetodoPago)
                  VALUES (@Recibo, NULL, @IdReservacion, @Monto, @Fecha, @Metodo);", conexion, transaccion))
                    {
                        cmdInsert.Parameters.AddWithValue("@Recibo", numeroRecibo);
                        cmdInsert.Parameters.AddWithValue("@IdReservacion", idReservacion);
                        cmdInsert.Parameters.AddWithValue("@Monto", montoAbonado);
                        cmdInsert.Parameters.AddWithValue("@Fecha", fechaPago);
                        cmdInsert.Parameters.AddWithValue("@Metodo", idMetodoPago);
                        cmdInsert.ExecuteNonQuery();
                    }

                    decimal totalReservacion;
                    using (SqlCommand cmdTotal = new SqlCommand("SELECT MontoTotal FROM Reservaciones WHERE IdReservacion = @IdReservacion;", conexion, transaccion))
                    {
                        cmdTotal.Parameters.AddWithValue("@IdReservacion", idReservacion);
                        totalReservacion = Convert.ToDecimal(cmdTotal.ExecuteScalar());
                    }

                    decimal totalPagadoAcumulado;
                    using (SqlCommand cmdPagado = new SqlCommand("SELECT ISNULL(SUM(Monto), 0) FROM Pagos WHERE IdReservacion = @IdReservacion;", conexion, transaccion))
                    {
                        cmdPagado.Parameters.AddWithValue("@IdReservacion", idReservacion);
                        totalPagadoAcumulado = Convert.ToDecimal(cmdPagado.ExecuteScalar());
                    }

                    string estadoMensaje = "Pendiente (Pago Parcial)";
                    if (totalPagadoAcumulado >= totalReservacion)
                    {
                        using (SqlCommand cmdEstado = new SqlCommand(
                            @"UPDATE Reservaciones
                      SET IdEstadoReservacion = (SELECT IdEstadoReservacion FROM EstadosReservacion WHERE Nombre = 'Confirmada')
                      WHERE IdReservacion = @IdReservacion;", conexion, transaccion))
                        {
                            cmdEstado.Parameters.AddWithValue("@IdReservacion", idReservacion);
                            cmdEstado.ExecuteNonQuery();
                        }
                        estadoMensaje = "Confirmada (Pago Total)";
                    }

                    transaccion.Commit();

                    MessageBox.Show($"Pago registrado exitosamente.\nRecibo: {numeroRecibo}\nEstado Reservación: {estadoMensaje}", "Transacción Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarResultadosReservaciones(txtBuscarReserv.Text);
                    CargarDatosBD();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show("Error al registrar el pago: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GenerarNumeroRecibo(SqlConnection conexion, SqlTransaction transaccion, string nombreMetodo)
        {
            string codigoMetodo = (nombreMetodo != null && nombreMetodo.StartsWith("Tarjeta")) ? "TJ" : "EF";
            Random rnd = new Random();

            for (int intento = 0; intento < 8; intento++)
            {
                string candidato = $"REC-{DateTime.Today:yyMMdd}-{codigoMetodo}{rnd.Next(10, 99)}";

                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Pagos WHERE NumeroRecibo = @Recibo;", conexion, transaccion))
                {
                    cmd.Parameters.AddWithValue("@Recibo", candidato);
                    int existe = (int)cmd.ExecuteScalar();
                    if (existe == 0) return candidato;
                }
            }

            throw new Exception("No se pudo generar un número de recibo único. Intenta nuevamente.");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (rbPagodeCuota.Checked)
            {
                LimpiarDetalleCuota();
                cmbResultadosCuota.Items.Clear();
                txtBuscarCuota.Clear();
                lblResultadosCuota.Text = "Escribe un cliente, contrato o propiedad y presiona Buscar.";
            }
            else
            {
                LimpiarDetalleReservacion();
                cmbResultadosReserv.Items.Clear();
                txtBuscarReserv.Clear();
                lblResultadosReserv.Text = "Escribe un cliente, reservación o propiedad y presiona Buscar.";
            }
        }

        private void CargarDatosBD()
        {
            string query = @"
                SELECT
                    pg.NumeroRecibo AS [Número de Recibo],
                    pg.FechaPago AS [Fecha de Pago],
                    cl.NombreCompleto AS Cliente,
                    prop.Codigo         AS Propiedad,
                    'Cuota'            AS Tipo,
                    c.NumeroContrato + ' - Cuota ' + CAST(cc.NumeroCuota AS VARCHAR(3)) AS Referencia,
                    pg.Monto,
                    mp.Nombre          AS Metodo
                FROM Pagos pg
                INNER JOIN CuotasContrato cc ON cc.IdCuota = pg.IdCuota
                INNER JOIN Contratos c       ON c.IdContrato = cc.IdContrato
                INNER JOIN Clientes cl       ON cl.IdCliente = c.IdArrendatario
                INNER JOIN Propiedades prop  ON prop.IdPropiedad = c.IdPropiedad
                INNER JOIN MetodosPago mp    ON mp.IdMetodoPago = pg.IdMetodoPago
                WHERE pg.IdCuota IS NOT NULL
                UNION ALL
                SELECT
                    pg.NumeroRecibo,
                    pg.FechaPago,
                    cl.NombreCompleto AS Cliente,
                    prop.Codigo         AS Propiedad,
                    'Reservación'      AS Tipo,
                    r.NumeroReservacion AS Referencia,
                    pg.Monto,
                    mp.Nombre          AS Metodo
                FROM Pagos pg
                INNER JOIN Reservaciones r  ON r.IdReservacion = pg.IdReservacion
                INNER JOIN Clientes cl      ON cl.IdCliente = r.IdCliente
                INNER JOIN Propiedades prop ON prop.IdPropiedad = r.IdPropiedad
                INNER JOIN MetodosPago mp   ON mp.IdMetodoPago = pg.IdMetodoPago
                WHERE pg.IdReservacion IS NOT NULL
                ORDER BY [Fecha de Pago] DESC;";

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);

                    tablalocal = new DataTable();
                    adaptador.Fill(tablalocal);
                    dgvHistorial.DataSource = tablalocal;

                    AplicarFormatoColumna(dgvHistorial, "Fecha de Pago", "dd/MM/yyyy HH:mm");
                    AplicarFormatoMoneda(dgvHistorial, "Monto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar el historial de pagos: " + ex.Message, 
                    "Error de datos.", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FiltrarHistorial();
                e.SuppressKeyPress = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarHistorial();
        }

        private void FiltrarHistorial()
        {
            if (tablalocal == null) return;

            string filtro = txtBuscar.Text.Trim().Replace("'", "''");

            if (string.IsNullOrEmpty(filtro))
            {
                tablalocal.DefaultView.RowFilter = string.Empty;
                return;
            }

            try
            {
                tablalocal.DefaultView.RowFilter =
                    $"Convert(Cliente, 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert([Número de Recibo], 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert(Propiedad, 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert(Tipo, 'System.String') LIKE '%{filtro}%'";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al filtrar los datos: " + ex.Message, 
                    "Error de filtro.", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning
                );
            }
        }

        private void PagosForm_Load(object sender, EventArgs e)
        {

        }
    }
}