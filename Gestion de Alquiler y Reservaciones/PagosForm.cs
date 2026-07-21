using System;
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
            CurrencySymbol = "L. ",
            CurrencyDecimalDigits = 2,
            CurrencyGroupSeparator = ",",
            CurrencyDecimalSeparator = "."
        };

        private DataTable tablalocal;

        private int? idCuotaSeleccionada = null;
        private int? idReservacionSeleccionada = null;

        public PagosForm()
        {
            InitializeComponent();

            ActivarTabNuevo();

            ConfigurarDataGridView(dgvHistorial);
            ConfigurarDataGridView(dataGridView1);
            ConfigurarDataGridView(dataGridView2);

            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView2.CellClick += dataGridView2_CellClick;

            btnBuscarCuota.Click += (s, e) => CargarGridCuotas(txtBuscarCuota.Text);
            btnBuscarReserv.Click += (s, e) => CargarGridReservaciones(txtBuscarReserv.Text);

            btnGuardar.Click += btnGuardar_Click;
            btnLimpiar.Click += btnLimpiar_Click;

            CargarComboMetodoPago(cmbMetodoPago);
            CargarComboMetodoPago(cmbMetodoPagoR);

            CargarGridCuotas();
            CargarDatosBD();
            cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPagoR.DropDownStyle = ComboBoxStyle.DropDownList;
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
            CargarGridCuotas();
        }

        private void MostrarPanelReservacion()
        {
            pnlPagodeCuota.Visible = false;
            pnlPagoReservacion.Visible = true;
            CargarGridReservaciones();
        }

        private void CargarGridCuotas(string filtro = null)
        {
            string query = @"
                SELECT
                    cc.IdCuota,
                    cc.NumeroReciboCuota AS [Recibo Cuota],
                    c.NumeroContrato     AS Contrato,
                    cl.NombreCompleto    AS Cliente,
                    p.Codigo             AS Propiedad,
                    cc.PeriodoCorrespondiente AS Periodo,
                    cc.FechaVencimiento  AS Vencimiento,
                    cc.MontoCuota        AS [Monto Cuota],
                    cc.MontoMora         AS Mora,
                    (cc.MontoCuota + cc.MontoMora) - ISNULL(pg.TotalPagado, 0) AS Saldo,
                    ep.Nombre            AS Estado
                FROM CuotasContrato cc
                INNER JOIN Contratos c    ON c.IdContrato = cc.IdContrato
                INNER JOIN Clientes cl    ON cl.IdCliente = c.IdArrendatario
                INNER JOIN Propiedades p  ON p.IdPropiedad = c.IdPropiedad
                INNER JOIN EstadosPago ep ON ep.IdEstadoPago = cc.IdEstadoPago
                LEFT JOIN (
                    SELECT IdCuota, SUM(Monto) AS TotalPagado
                    FROM Pagos WHERE IdCuota IS NOT NULL GROUP BY IdCuota
                ) pg ON pg.IdCuota = cc.IdCuota
                WHERE ep.Nombre IN ('Pendiente', 'Vencida', 'Pagada Parcial')
                  AND (@Busqueda IS NULL OR c.NumeroContrato LIKE '%' + @Busqueda + '%'
                       OR cl.NombreCompleto LIKE '%' + @Busqueda + '%'
                       OR p.Codigo LIKE '%' + @Busqueda + '%')
                ORDER BY cc.FechaVencimiento;";

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Busqueda",
                        string.IsNullOrWhiteSpace(filtro) ? (object)DBNull.Value : filtro.Trim());

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    dataGridView1.DataSource = tabla;

                    if (dataGridView1.Columns["IdCuota"] != null)
                        dataGridView1.Columns["IdCuota"].Visible = false;

                    AplicarFormatoColumna(dataGridView1, "Vencimiento", "dd/MM/yyyy");
                    AplicarFormatoColumna(dataGridView1, "Periodo", "MMMM yyyy");
                    AplicarFormatoMoneda(dataGridView1, "Monto Cuota");
                    AplicarFormatoMoneda(dataGridView1, "Mora");
                    AplicarFormatoMoneda(dataGridView1, "Saldo");
                }

                LimpiarDetalleCuota();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las cuotas: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGridReservaciones(string filtro = null)
        {
            string query = @"
                SELECT
                    r.IdReservacion,
                    r.NumeroReservacion AS Reservación,
                    cl.NombreCompleto   AS Cliente,
                    p.Codigo            AS Propiedad,
                    r.FechaEntrada      AS Entrada,
                    r.FechaSalida       AS Salida,
                    r.MontoTotal        AS [Monto Total],
                    r.MontoTotal - ISNULL(pg.TotalPagado, 0) AS Saldo,
                    er.Nombre           AS Estado
                FROM Reservaciones r
                INNER JOIN Clientes cl   ON cl.IdCliente = r.IdCliente
                INNER JOIN Propiedades p ON p.IdPropiedad = r.IdPropiedad
                INNER JOIN EstadosReservacion er ON er.IdEstadoReservacion = r.IdEstadoReservacion
                LEFT JOIN (
                    SELECT IdReservacion, SUM(Monto) AS TotalPagado
                    FROM Pagos WHERE IdReservacion IS NOT NULL GROUP BY IdReservacion
                ) pg ON pg.IdReservacion = r.IdReservacion
                WHERE er.Nombre IN ('Pendiente', 'Confirmada', 'En Curso')
                  AND (@Busqueda IS NULL OR r.NumeroReservacion LIKE '%' + @Busqueda + '%'
                       OR cl.NombreCompleto LIKE '%' + @Busqueda + '%'
                       OR p.Codigo LIKE '%' + @Busqueda + '%')
                ORDER BY r.FechaEntrada;";

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Busqueda",
                        string.IsNullOrWhiteSpace(filtro) ? (object)DBNull.Value : filtro.Trim());

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    dataGridView2.DataSource = tabla;

                    if (dataGridView2.Columns["IdReservacion"] != null)
                        dataGridView2.Columns["IdReservacion"].Visible = false;

                    AplicarFormatoColumna(dataGridView2, "Entrada", "dd/MM/yyyy HH:mm");
                    AplicarFormatoColumna(dataGridView2, "Salida", "dd/MM/yyyy HH:mm");
                    AplicarFormatoMoneda(dataGridView2, "Monto Total");
                    AplicarFormatoMoneda(dataGridView2, "Saldo");
                }

                LimpiarDetalleReservacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las reservaciones: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
            if (fila.Cells["IdCuota"].Value == null || fila.Cells["IdCuota"].Value == DBNull.Value) return;

            txtCliente.Text = fila.Cells["Cliente"].Value.ToString();
            textBox1.Text = fila.Cells["Propiedad"].Value.ToString();
            textBox2.Text = Convert.ToDateTime(fila.Cells["Periodo"].Value).ToString("MMMM yyyy", new CultureInfo("es-HN"));

            decimal montoCuota = Convert.ToDecimal(fila.Cells["Monto Cuota"].Value);
            decimal mora = Convert.ToDecimal(fila.Cells["Mora"].Value);
            decimal saldo = Convert.ToDecimal(fila.Cells["Saldo"].Value);

            txtMontoCuota.Text = montoCuota.ToString("C", FormatoLempiras);
            txtMora.Text = mora.ToString("C", FormatoLempiras);
            txtSaldoPendiente.Text = saldo.ToString("C", FormatoLempiras);

            numMontoPagar.Maximum = saldo > 0 ? saldo : 0;
            numMontoPagar.Value = saldo > 0 ? saldo : 0;

            dtpFechaPago.Value = DateTime.Today;
            txtNumeroRecibo.Text = GenerarNumeroReciboPreview();

            idCuotaSeleccionada = Convert.ToInt32(fila.Cells["IdCuota"].Value);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dataGridView2.Rows[e.RowIndex];
            if (fila.Cells["IdReservacion"].Value == null || fila.Cells["IdReservacion"].Value == DBNull.Value) return;

            txtClienteR.Text = fila.Cells["Cliente"].Value.ToString();
            txtPropiedadR.Text = fila.Cells["Propiedad"].Value.ToString();

            decimal montoTotal = Convert.ToDecimal(fila.Cells["Monto Total"].Value);
            decimal saldo = Convert.ToDecimal(fila.Cells["Saldo"].Value);

            txtMontoTotalR.Text = montoTotal.ToString("C", FormatoLempiras);
            txtSaldoPendienteR.Text = saldo.ToString("C", FormatoLempiras);

            numMontoPagarR.Maximum = saldo > 0 ? saldo : 0;
            numMontoPagarR.Value = saldo > 0 ? saldo : 0;

            dtpFechaPagoR.Value = DateTime.Today;
            txtNumeroReciboR.Text = GenerarNumeroReciboPreview();

            idReservacionSeleccionada = Convert.ToInt32(fila.Cells["IdReservacion"].Value);
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
                MessageBox.Show("Error al cargar métodos de pago: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Selecciona una cuota de la lista antes de registrar el pago.", "Falta selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbMetodoPago.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un método de pago.", "Falta selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numMontoPagar.Value <= 0)
            {
                MessageBox.Show("El monto a pagar debe ser mayor a cero.", "Monto inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCuota = idCuotaSeleccionada.Value;
            decimal monto = numMontoPagar.Value;
            int idMetodoPago = Convert.ToInt32(cmbMetodoPago.SelectedValue);
            string nombreMetodo = cmbMetodoPago.Text;
            DateTime fechaPago = dtpFechaPago.Value.Date;

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
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
                        cmdInsert.Parameters.AddWithValue("@Monto", monto);
                        cmdInsert.Parameters.AddWithValue("@Fecha", fechaPago);
                        cmdInsert.Parameters.AddWithValue("@Metodo", idMetodoPago);
                        cmdInsert.ExecuteNonQuery();
                    }

                    decimal totalCuotaConMora;
                    using (SqlCommand cmdTotal = new SqlCommand(
                        "SELECT (MontoCuota + MontoMora) FROM CuotasContrato WHERE IdCuota = @IdCuota;", conexion, transaccion))
                    {
                        cmdTotal.Parameters.AddWithValue("@IdCuota", idCuota);
                        totalCuotaConMora = Convert.ToDecimal(cmdTotal.ExecuteScalar());
                    }

                    decimal totalPagadoAcumulado;
                    using (SqlCommand cmdPagado = new SqlCommand(
                        "SELECT ISNULL(SUM(Monto), 0) FROM Pagos WHERE IdCuota = @IdCuota;", conexion, transaccion))
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

                    MessageBox.Show($"Pago registrado correctamente.\nRecibo: {numeroRecibo}\nEstado de la cuota: {nuevoEstado}",
                        "Pago registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarGridCuotas();
                    CargarDatosBD();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show("Error al registrar el pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GuardarPagoReservacion()
        {
            if (idReservacionSeleccionada == null)
            {
                MessageBox.Show("Selecciona una reservación de la lista antes de registrar el pago.", "Falta selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbMetodoPagoR.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un método de pago.", "Falta selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numMontoPagarR.Value <= 0)
            {
                MessageBox.Show("El monto a pagar debe ser mayor a cero.", "Monto inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idReservacion = idReservacionSeleccionada.Value;
            decimal monto = numMontoPagarR.Value;
            int idMetodoPago = Convert.ToInt32(cmbMetodoPagoR.SelectedValue);
            string nombreMetodo = cmbMetodoPagoR.Text;
            DateTime fechaPago = dtpFechaPagoR.Value.Date;

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
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
                        cmdInsert.Parameters.AddWithValue("@Monto", monto);
                        cmdInsert.Parameters.AddWithValue("@Fecha", fechaPago);
                        cmdInsert.Parameters.AddWithValue("@Metodo", idMetodoPago);
                        cmdInsert.ExecuteNonQuery();
                    }

                    transaccion.Commit();

                    MessageBox.Show($"Pago registrado correctamente.\nRecibo: {numeroRecibo}",
                        "Pago registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarGridReservaciones();
                    CargarDatosBD();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show("Error al registrar el pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dataGridView1.ClearSelection();
            }
            else
            {
                LimpiarDetalleReservacion();
                dataGridView2.ClearSelection();
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
                MessageBox.Show("Error al cargar el historial de pagos: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error al filtrar los datos: " + ex.Message, "Error de Filtro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PagosForm_Load(object sender, EventArgs e)
        {

        }
    }
}