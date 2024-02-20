using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CrianzaDragopavos.Controlador
{
    public class MasterConnection
    {
        //public static string connString = @"Data source=localhost\SQLEXPRESS;Initial Catalog=crianza_dragopavos;Integrated Security=true";
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
        private static SqlConnection conn = new(connectionString);

        public static SqlConnection connection { get { return conn; } }

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
