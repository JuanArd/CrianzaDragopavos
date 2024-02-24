using System.Data;
using System.Data.SqlClient;

namespace CrianzaMonturas.Dal.Controlador
{
    public static class CrianzaMonturasDb
    {
        public static void ObtenerMonturas(ref DataTable dt, int tipoMontura)
        {
            try
            {
                MasterConnection.Open();
                SqlDataAdapter da = new("ObtenerMonturas", MasterConnection.connection);

                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@TipoMontura", tipoMontura);

                da.Fill(dt);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                MasterConnection.Close();
            }
        }

        public static bool InsertarCria(string nombre, string sexo, int tipoMontura, int cria, bool predispuesto, int padre, int madre, out int idCria)
        {
            try
            {
                MasterConnection.Open();
                SqlCommand cmd = new("InsertarCria", MasterConnection.connection);

                int predisp = predispuesto ? 1 : 0;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Sexo", sexo);
                cmd.Parameters.AddWithValue("@TipoMontura", tipoMontura);
                cmd.Parameters.AddWithValue("@TipoCria", cria);
                cmd.Parameters.AddWithValue("@Predispuesto", predisp);
                cmd.Parameters.AddWithValue("@Padre", padre);
                cmd.Parameters.AddWithValue("@Madre", madre);

                idCria = (int)cmd.ExecuteScalar();

                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                idCria = 0;
                return false;
            }
            finally
            {
                MasterConnection.Close();
            }
        }
    
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
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
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
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
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
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                MasterConnection.Close();
            }
        }
    }
}
