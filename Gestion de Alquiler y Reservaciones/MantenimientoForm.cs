using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gestion_de_Alquiler_y_Reservaciones
{
    public partial class MantenimientoForm : Form
    {
        private static readonly Color ColorActivo = ColorTranslator.FromHtml("#C84F24");

        private static readonly Color ColorInactivo = ColorTranslator.FromHtml("#E0DBD2");
        private static readonly Color TextoInactivo = ColorTranslator.FromHtml("#666666");
        private DataTable tablalocal;

        public MantenimientoForm()
        {
            InitializeComponent();
            ConfigurarDataGridView(dgvHistorial);
            ActivarTabNuevo();
            CargarDatosBD();

            cboPropiedad.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSolicitud.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTecnico.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void ConfigurarDataGridView(DataGridView grid)
        {
            System.Drawing.Color naranjaTitulo = System.Drawing.Color.FromArgb(216, 122, 45);

            grid.RowHeadersVisible = false;
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.RowTemplate.Height = 28;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = System.Drawing.Color.White;
            grid.EnableHeadersVisualStyles = false;

            grid.ColumnHeadersDefaultCellStyle.BackColor = naranjaTitulo;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Montserrat", 9, FontStyle.Bold);

            grid.DefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            grid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(225, 225, 225);
        }
        private void btnSolicitud_Click(object sender, EventArgs e) => ActivarTabNuevo();
        private void btnActualizar_Click(object sender, EventArgs e) => ActivarTabEditar();
        private void btnHistorial_Click(object sender, EventArgs e) => ActivarTabHistorial();

        private void ActivarTabNuevo()
        {
            pnlNueva.Visible = true;
            pnlHistorial.Visible = false;
            pnlEditar.Visible = false;
            pnlAccion.Visible = true;
            pnlActualizar.Visible = false;

            EstiloTabActivo(btnSolicitud);
            EstiloTabInactivo(btnActualizar);
            EstiloTabInactivo(btnHistorial);
        }
        private void ActivarTabEditar()
        {
            pnlEditar.Visible = true;
            pnlHistorial.Visible = false;
            pnlNueva.Visible = false;
            pnlAccion.Visible = false;
            pnlActualizar.Visible = true;

            EstiloTabActivo(btnActualizar);
            EstiloTabInactivo(btnSolicitud);
            EstiloTabInactivo(btnHistorial);

        }
        private void ActivarTabHistorial()
        {
            pnlHistorial.Visible = true;
            pnlNueva.Visible = false;
            pnlEditar.Visible = false;
            pnlAccion.Visible = false;
            pnlActualizar.Visible = false;

            EstiloTabActivo(btnHistorial);
            EstiloTabInactivo(btnActualizar);
            EstiloTabInactivo(btnSolicitud);
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
        private void CargarDatosBD()
        {
            string query = @"
            SELECT 
                M.NumeroOrden AS [Número de Solicitud],
                P.Codigo AS [Propiedad],
                T.Nombre AS [Tipo de Mantenimiento],
                E.NombreCompleto AS [Técnico Asignado],
                M.Descripcion AS [Descripción],
                M.FechaProgramada AS [Fecha Programada],
                M.FechaConclusion AS [Fecha de Conclusión],
                M.Costo,
                EM.Nombre AS [Estado]
                FROM Mantenimiento M
                INNER JOIN Propiedades P ON M.IdPropiedad = P.IdPropiedad
                INNER JOIN EstadosMantenimiento EM ON M.IdEstadoMantenimiento = EM.IdEstadoMantenimiento
                INNER JOIN TiposMantenimiento T ON M.IdTipoMantenimiento = T.IdTipoMantenimiento
                INNER JOIN Empleado E ON M.IdTecnicoAsignado = E.IdEmpleado";

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);

                        tablalocal = new DataTable();

                        adaptador.Fill(tablalocal);
                        dgvHistorial.DataSource = tablalocal;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial de solicitudes de mantenimiento: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    $"Convert(Propiedad, 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert([Número de Solicitud], 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert([Técnico Asignado], 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert([Tipo de Mantenimiento], 'System.String') LIKE '%{filtro}%'";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar los datos: " + ex.Message, "Error de Filtro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvHistorial_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvHistorial.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString().Trim().ToLower();

                switch (estado)
                {
                    case "en proceso":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#155724");
                        break;
                    case "pendiente":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#856404");
                        break;
                    case "completado":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#8F8686");
                        break;
                    case "cancelado":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#721C24");
                        break;
                }

                e.CellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            }
        }

        private void MantenimientoForm_Load(object sender, EventArgs e)
        {
            cboPropiedad.SelectedIndex = 0;
            cboTecnico.SelectedIndex = 0;
            cboTipo.SelectedIndex = 0;
            llenarTipoMantenimiento();
            llenarTecnicoAsignado();
            llenarPropiedades();

            llenarcboSolicitud();
            cambiarEstadoCampos(false);
            btnActualizarSoli.Enabled = false;
        }

        private void llenarTipoMantenimiento()
        {
            try
            {
                string queryLlenarTipoMantenimiento = "select * from TiposMantenimiento";
                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmdLlenarTipoMantenimiento = new SqlCommand(queryLlenarTipoMantenimiento, conectar);
                    SqlDataReader readerLlenarTipoMantenimiento = cmdLlenarTipoMantenimiento.ExecuteReader();
                    while (readerLlenarTipoMantenimiento.Read())
                    {
                        cboTipo.Items.Add(readerLlenarTipoMantenimiento["Nombre"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Algos salió mal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void llenarTecnicoAsignado()
        {
            //Esto solo es por mientras, para hacer la validacion, estos nombres cambiarán
            try
            {
                string queryllenarTecnicoAsignado = "select * from Empleados";
                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmdllenarTecnicoAsignado = new SqlCommand(queryllenarTecnicoAsignado, conectar);
                    SqlDataReader readerllenarTecnicoAsignado = cmdllenarTecnicoAsignado.ExecuteReader();
                    while (readerllenarTecnicoAsignado.Read())
                    {
                        string nombrecompleto;
                        string[] nombrepartes;
                        nombrecompleto = readerllenarTecnicoAsignado["Nombre"].ToString();
                        nombrepartes = nombrecompleto.Split(' ');

                        cboTecnico.Items.Add(nombrepartes[0] + ' ' + nombrepartes[2]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Algos salió mal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void llenarPropiedades()
        {
            //Esto lo pongo solo para hacer las validaciones, no sé si así seria
            try
            {
                string queryLlenarPropiedades = "select * from Propiedades";
                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmdLlenarPropiedades = new SqlCommand(queryLlenarPropiedades, conectar);
                    SqlDataReader readerLlenarPropiedades = cmdLlenarPropiedades.ExecuteReader();
                    while (readerLlenarPropiedades.Read())
                    {
                        cboPropiedad.Items.Add(readerLlenarPropiedades["Codigo"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Algos salió mal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cboPropiedad.SelectedIndex == 0 || 
                cboTecnico.SelectedIndex == 0 || 
                cboTipo.SelectedIndex == 0)
            {
                MessageBox.Show(
                    "Los campos obligatorios no deben de estar vacíos",
                    "Campos vacíos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void cboPropiedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPropiedad.SelectedIndex > 0)
            {
                lblOPropiedad.Visible = false;
            }
            else
            {
                lblOPropiedad.Visible = true;
            }

            if (lblOPropiedad.Visible == false && 
                lblOTecnico.Visible == false && 
                lblOTipo.Visible == false &&
                lblOFecha.Visible == false)
            {
                btnGuardar.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
            }
        }

        private void cboTecnico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTecnico.SelectedIndex > 0)
            {
                lblOTecnico.Visible = false;
            }
            else
            {
                lblOTecnico.Visible = true;
            }

            if (lblOPropiedad.Visible == false &&
                lblOTecnico.Visible == false &&
                lblOTipo.Visible == false &&
                lblOFecha.Visible == false)
            {
                btnGuardar.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
            }
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTecnico.SelectedIndex > 0)
            {
                lblOTipo.Visible = false;
            }
            else
            {
                lblOTipo.Visible = true;
            }

            if (lblOPropiedad.Visible == false &&
                lblOTecnico.Visible == false &&
                lblOTipo.Visible == false &&
                lblOFecha.Visible == false)
            {
                btnGuardar.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
            }
        }

        private void dtpProgramada_ValueChanged(object sender, EventArgs e)
        {
            if(dtpProgramada.Value.Date < DateTime.Now.Date)
            {
                lblOFecha.Text = "Seleccione una fecha valida";
                lblOFecha.Visible = true;
            }
            else
            {
                lblOFecha.Visible = false;
            }

            if (lblOPropiedad.Visible == false &&
                lblOTecnico.Visible == false &&
                lblOTipo.Visible == false &&
                lblOFecha.Visible == false)
            {
                btnGuardar.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
            }
        }

        private void llenarcboSolicitud()
        {
            try
            {
                string queryLlenarcboSolicitud = "select * from Mantenimiento";
                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmdLlenarcboSolicitud = new SqlCommand(queryLlenarcboSolicitud, conectar);
                    SqlDataReader readerLlenarcboSolicitud = cmdLlenarcboSolicitud.ExecuteReader();
                    while (readerLlenarcboSolicitud.Read())
                    {
                        cboSolicitud.Items.Add(readerLlenarcboSolicitud["IdMantenimiento"].ToString());
                    }
                }
                cboSolicitud.SelectedItem = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Algos salió mal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void llenarcmbEstado()
        {
            try
            {
                string queryllenarcmbEstado = "select * from EstadosMantenimiento";
                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmdllenarcmbEstado = new SqlCommand(queryllenarcmbEstado, conectar);
                    SqlDataReader readerllenarcmbEstado = cmdllenarcmbEstado.ExecuteReader();
                    while (readerllenarcmbEstado.Read())
                    {
                        cmbEstado.Items.Add(readerllenarcmbEstado["Nombre"].ToString());
                    }
                }
                cboSolicitud.SelectedItem = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Algos salió mal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void buscarDatosEnDB()
        {
            try
            {
                string querybuscarDatosEnDB = "select M.IdMantenimiento, P.Codigo, Emp.NombreCompleto, M.Costo, " +
                    "M.Descripcion, M.FechaConclusion, Est.Nombre from Mantenimiento as M " +
                    "INNER JOIN Propiedades as P on M.IdPropiedad = P.IdPropiedad " +
                    "INNER JOIN Empleado as Emp on M.IdTecnicoAsignado = Emp.IdEmpleado " +
                    "INNER JOIN EstadosMantenimiento as Est on M.IdEstadoMantenimiento = Est.IdEstadoMantenimiento " +
                    "where M.IdMantenimiento = @id";
                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmdbuscarDatosEnDB = new SqlCommand(querybuscarDatosEnDB, conectar);
                    cmdbuscarDatosEnDB.Parameters.AddWithValue("@id", cboSolicitud.SelectedItem);
                    SqlDataReader readerbuscarDatosEnDB = cmdbuscarDatosEnDB.ExecuteReader();
                    while (readerbuscarDatosEnDB.Read())
                    {
                        txtPropiedadActu.Text = readerbuscarDatosEnDB["Codigo"].ToString();
                        txtTecnicoActu.Text = readerbuscarDatosEnDB["NombreCompleto"].ToString();
                        txtCosto.Text = readerbuscarDatosEnDB["Costo"].ToString();
                        txtDescripcionActu.Text = readerbuscarDatosEnDB["Descripcion"].ToString();
                        dtpConclusion.Value = DateTime.Parse(readerbuscarDatosEnDB["FechaConclusion"].ToString());
                        string estado = readerbuscarDatosEnDB["Nombre"].ToString();
                        cmbEstado.Text = estado;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Algos salió mal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void cboSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboSolicitud.SelectedIndex == 0)
            {
                btnActualizarSoli.Enabled = false;
                cambiarEstadoCampos(false);
                limpiarcampos();
            }
            else
            {
                llenarcmbEstado();
                buscarDatosEnDB();
                cambiarEstadoCampos(true);
                btnActualizarSoli.Enabled = true;
            }
        }
        

        private void cambiarEstadoCampos(bool estado)
        {
            txtPropiedadActu.Enabled = estado;
            txtTecnicoActu.Enabled = estado;
            txtCosto.Enabled = estado;
            txtDescripcionActu.Enabled = estado;
            dtpConclusion.Enabled = estado;
            cmbEstado.Enabled = estado;
        }
        
        
        private void limpiarcampos()
        {
            txtPropiedadActu.Text = string.Empty;
            txtPropiedadActu.Text = string.Empty;
            txtCosto.Text = string.Empty;
            txtDescripcionActu.Text = string.Empty;
            dtpConclusion.Text = string.Empty;
            cmbEstado.SelectedIndex = -1;
        }

        private void btnLimpiarActu_Click(object sender, EventArgs e)
        {
            limpiarcampos();
        }
    }
}