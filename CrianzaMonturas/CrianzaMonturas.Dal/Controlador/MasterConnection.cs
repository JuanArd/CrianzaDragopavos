using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CrianzaMonturas.Dal.Controlador
{
    public static class MasterConnection
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
        private static readonly SqlConnection conn = new(connectionString);

        public static SqlConnection Connection { get { return conn; } }

        public static void Open()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public static void Close()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
