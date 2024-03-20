using CrianzaMonturas.Dal.Contratos;
using CrianzaMonturas.Dal.Controlador;
using CrianzaMonturas.Dal.Utilidades;
using System.Data;
using System.Data.SqlClient;

namespace CrianzaMonturas.Dal.Dao
{
    public class ReproduccionDao
    {
        public bool ActualizarReproduccion(IMontura cria)
        {
            var result = false;

            try
            {
                MasterConnection.Open();

                using (var cmd = new SqlCommand("ActualizarReproduccion", MasterConnection.connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Cria", cria.Id);
                    cmd.Parameters.AddWithValue("@Padre", cria.Padre!.Id);
                    cmd.Parameters.AddWithValue("@Madre", cria.Madre!.Id);

                    cmd.ExecuteNonQuery();
                }

                result = true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"|{ex.Message} - {ex.StackTrace}|");
            }
            finally
            {
                MasterConnection.Close();
            }

            return result;
        }

        public bool CerrarReproduccion(int padreId, int madreId)
        {
            var result = false;

            try
            {
                MasterConnection.Open();

                using (var cmd = new SqlCommand("CerrarReproduccion", MasterConnection.connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Padre", padreId);
                    cmd.Parameters.AddWithValue("@Madre", madreId);

                    cmd.ExecuteNonQuery();
                }

                result = true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"|{ex.Message} - {ex.StackTrace}|");
            }
            finally
            {
                MasterConnection.Close();
            }

            return result;
        }

        public bool InsertarReproduccion(int padreId, int madreId)
        {
            var result = false;

            try
            {
                MasterConnection.Open();

                using (var cmd = new SqlCommand("InsertarReproduccion", MasterConnection.connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Padre", padreId);
                    cmd.Parameters.AddWithValue("@Madre", madreId);

                    cmd.ExecuteNonQuery();
                }

                result = true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"|{ex.Message} - {ex.StackTrace}|");
            }
            finally
            {
                MasterConnection.Close();
            }

            return result;
        }
    }
}
