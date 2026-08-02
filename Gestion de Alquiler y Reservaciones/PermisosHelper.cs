using System.Collections.Generic;

namespace Gestion_de_Alquiler_y_Reservaciones
{
    public static class PermisosHelper
    {
        private static readonly Dictionary<string, List<string>> ModulosPorCargo =
            new Dictionary<string, List<string>>
        {
            { "administrador", new List<string> {
                "DashboardForm", "PropiedadesForm", "ContratosForm", "ReservacionesForm",
                "ClientesForm", "MantenimientoForm", "PagosForm", "ReportesForm"
            }},
            { "arrendamiento", new List<string> {
                "ContratosForm", "ClientesForm", "PropiedadesForm", "ReportesForm"
            }},
            { "reservaciones", new List<string> {
                "ContratosForm", "ReservacionesForm", "ClientesForm", "PropiedadesForm", "ReportesForm"
            }},
            { "mantenimiento", new List<string> {
                "MantenimientoForm", "ReportesForm"
            }},
        };

        public static bool TieneAcceso(string cargo, string nombreFormulario)
        {
            if (string.IsNullOrWhiteSpace(cargo)) return false;

            string cargoNormalizado = cargo.Trim().ToLower();

            if (!ModulosPorCargo.ContainsKey(cargoNormalizado))
                return false;

            return ModulosPorCargo[cargoNormalizado].Contains(nombreFormulario);
        }

        private static readonly Dictionary<string, List<string>> ReportesPorCargo =
        new Dictionary<string, List<string>>
    {
        { "administrador", new List<string> {
            "Contratos", "Mantenimiento", "Reservaciones", "Pagos", "Propiedades", "Administracion"
        }},
        { "arrendamiento", new List<string> { "Contratos" }},
        { "reservaciones",   new List<string> { "Reservaciones" }},
        { "mantenimiento", new List<string> { "Mantenimiento" }},
    };

        public static bool TieneAccesoReporte(string cargo, string categoria)
        {
            if (string.IsNullOrWhiteSpace(cargo)) return false;

            string cargoNormalizado = cargo.Trim().ToLower();

            if (!ReportesPorCargo.ContainsKey(cargoNormalizado))
                return false;

            return ReportesPorCargo[cargoNormalizado].Contains(categoria);
        }
    }
}
