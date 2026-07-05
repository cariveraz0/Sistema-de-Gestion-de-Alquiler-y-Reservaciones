using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gestion_de_Alquiler_y_Reservaciones.Reportes
{
    public partial class ReporteCasasReservadasEfectivo : ReporteBase
    {
        public ReporteCasasReservadasEfectivo()
        {
            InitializeComponent();
            cmbAño.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ReporteCasasReservadasEfectivo_Load(object sender, EventArgs e)
        {
            buscarClientes();
            dgvCasas.Enabled = false;
        }

        private void buscarClientes()
        {
            cmbClientes.Items.Clear();
            try
            {
                string queryBuscarClientes =
                    "select Res.IdReservacion, Res.NumeroReservacion, TiPr.Nombre, MP.Nombre as MetodoPago, Cli.NombreCompleto, " +
                    "Res.FechaCreacion " +
                    "from Reservaciones as Res " +
                    "inner join Propiedades as Prop on Res.IdPropiedad = Prop.IdPropiedad " +
                    "inner join TiposPropiedad as  TiPr on Prop.IdTipoPropiedad = TiPr.IdTipoPropiedad " +
                    "inner join Pagos as Pa on Res.IdReservacion = Pa.IdReservacion " +
                    "inner join MetodosPago as MP on Pa.IdMetodoPago = MP.IdMetodoPago " +
                    "inner join Clientes as Cli on Res.IdCliente = Cli.IdCliente " +
                    "where MP.Nombre like '%efectivo%' " +
                    "and TiPr.Nombre like '%casa%'";

                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmdBuscarClientes = new SqlCommand(queryBuscarClientes, conectar);
                    SqlDataReader readerBuscarClientes = cmdBuscarClientes.ExecuteReader();
                    while (readerBuscarClientes.Read())
                    {
                        cmbClientes.Items.Add(readerBuscarClientes["NombreCompleto"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Algo salió mal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbClientes.SelectedIndex != -1 && cmbAño.SelectedIndex != -1)
            {
                llenarDGV();
            }
        }

        private void cmbAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedIndex != -1 && cmbAño.SelectedIndex != -1)
            {
                llenarDGV();
            }
        }

        private void llenarDGV()
        {
            dgvCasas.Rows.Clear();
            try
            {
                try
                {
                    string queryBuscarClientes =
                        "select Res.IdReservacion, Res.NumeroReservacion, Res.FechaCreacion, Res.FechaEntrada, " +
                        "Res.FechaSalida, Res.NumeroPersonas, Res.MontoTotal " +
                        "from Reservaciones as Res " +
                        "inner join Propiedades as Prop on Res.IdPropiedad = Prop.IdPropiedad " +
                        "inner join TiposPropiedad as  TiPr on Prop.IdTipoPropiedad = TiPr.IdTipoPropiedad " +
                        "inner join Pagos as Pa on Res.IdReservacion = Pa.IdReservacion " +
                        "inner join MetodosPago as MP on Pa.IdMetodoPago = MP.IdMetodoPago " +
                        "inner join Clientes as Cli on Res.IdCliente = Cli.IdCliente " +
                        "where MP.Nombre like '%efectivo%' " +
                        "and TiPr.Nombre like '%casa%' " +
                        $"and Cli.NombreCompleto like '%{cmbClientes.SelectedItem}%'" +
                        $"and YEAR(Res.FechaCreacion) = {cmbAño.SelectedItem}";

                    using (SqlConnection conectar = Conexion.ObtenerConexion())
                    {
                        conectar.Open();
                        SqlCommand cmdBuscarClientes = new SqlCommand(queryBuscarClientes, conectar);
                        SqlDataReader readerBuscarClientes = cmdBuscarClientes.ExecuteReader();
                        while (readerBuscarClientes.Read())
                        {
                            dgvCasas.Rows.Add(
                                readerBuscarClientes["IdReservacion"].ToString(),
                                readerBuscarClientes["NumeroReservacion"].ToString(),
                                readerBuscarClientes["FechaCreacion"].ToString(),
                                readerBuscarClientes["FechaEntrada"].ToString(),
                                readerBuscarClientes["FechaSalida"].ToString(),
                                readerBuscarClientes["NumeroPersonas"].ToString(),
                                readerBuscarClientes["MontoTotal"].ToString()
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Algo salió mal",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
