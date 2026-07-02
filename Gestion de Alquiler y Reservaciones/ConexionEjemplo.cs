using Microsoft.Data.SqlClient;

public static class ConexionEjemplo
{
    //Este es el archivo plantilla, este es el que se sube al repositorio
    private static string cadenaConexion = 
        "Server=PONER_IP_AWS,1433;" +
        "Database=NOMBRE_DE_LA_DB;" +
        "User Id=USUARIO;" +
        "Password=PONER_CONTRASEÑA_AQUÍ;" +
        "TrustServerCertificate=True;";

    public static SqlConnection ObtenerConexion()
    {
        return new SqlConnection(cadenaConexion);
    }
}