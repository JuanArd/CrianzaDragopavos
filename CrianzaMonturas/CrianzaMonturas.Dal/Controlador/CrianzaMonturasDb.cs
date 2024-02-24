using System.Data;
using System.Data.SqlClient;

namespace CrianzaMonturas.Dal.Controlador
{
    public static class CrianzaMonturasDb
    {
        public static bool ActualizarReproduccion(int idCria, int padre, int madre)
        {
            try
            {
                MasterConnection.Open();
                SqlCommand cmd = new("ActualizarReproduccion", MasterConnection.connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Cria", idCria);
                cmd.Parameters.AddWithValue("@Padre", padre);
                cmd.Parameters.AddWithValue("@Madre", madre);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                MasterConnection.Close();
            }
        }

        public static bool InsertarReproduccion(int padre, int madre)
        {
            try
            {
                MasterConnection.Open();
                SqlCommand cmd = new("InsertarReproduccion", MasterConnection.connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Padre", padre);
                cmd.Parameters.AddWithValue("@Madre", madre);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                MasterConnection.Close();
            }
        }

        public static bool CerrarReproduccion(int padre, int madre)
        {
            try
            {
                MasterConnection.Open();
                SqlCommand cmd = new("CerrarReproduccion", MasterConnection.connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Padre", padre);
                cmd.Parameters.AddWithValue("@Madre", madre);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                MasterConnection.Close();
            }
        }
    }
}
