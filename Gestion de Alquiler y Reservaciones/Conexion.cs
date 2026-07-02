using Microsoft.Data.SqlClient;

public static class Conexion
{
    //Este es el archivo REAL
    //Este NO SE SUBE AL REPOSITORIO
    private static string cadenaConexion = 
        "Server=13.59.54.244,1433;" +
        "Database=InmobiliariaClarita;" +
        "User Id=unah;" +
        "Password=Analistas2026Clarita;" +
        "TrustServerCertificate=True;";

    public static SqlConnection ObtenerConexion()
    {
        return new SqlConnection(cadenaConexion);
    }
}