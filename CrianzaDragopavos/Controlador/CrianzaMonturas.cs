using CrianzaDragopavos.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrianzaDragopavos.Controlador
{
    public static class CrianzaMonturas
    {
        public static void ObtenerTiposMontura(ref DataTable dt)
        {
            try
            {
                MasterConnection.Open();
                SqlDataAdapter da = new("SELECT * FROM TipoMontura", MasterConnection.conn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MasterConnection.Close();
            }
        }

        public static void ObtenerMonturas(ref DataTable dt, int pTipoMontura)
        {
            try
            {
                MasterConnection.Open();
                SqlDataAdapter da = new("ObtenerMonturas", MasterConnection.conn);

                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@TipoMontura", pTipoMontura);

                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                MasterConnection.Close();
            }
        }

        public static void ObtenerMontura(ref DataTable dt, int pIdMontura)
        {
            try
            {
                MasterConnection.Open();
                SqlDataAdapter da = new("ObtenerMontura", MasterConnection.conn);

                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id", pIdMontura);

                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                MasterConnection.Close();
            }
        }

        public static void ObtenerTipo(ref DataTable dt, int pTipoMontura)
        {
            try
            {
                MasterConnection.Open();
                SqlDataAdapter da = new("ObtenerTipo", MasterConnection.conn);

                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@TipoMontura", pTipoMontura);

                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                MasterConnection.Close();
            }
        }

        public static void ObtenerCruces(ref DataTable dt, int pTipoMontura)
        {
            try
            {
                MasterConnection.Open();
                SqlDataAdapter da = new("ObtenerCruces", MasterConnection.conn);

                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@TipoMontura", pTipoMontura);

                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                MasterConnection.Close();
            }
        }
    
        public static bool InsertarCria(string pNombre, string pSexo, int pTipoMontura, int pCria, bool pPredispuesto, int pPadre, int pMadre, out int idCria)
        {
            try
            {
                MasterConnection.Open();
                SqlCommand cmd = new("InsertarCria", MasterConnection.conn);

                int predisp = pPredispuesto ? 1 : 0;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", pNombre);
                cmd.Parameters.AddWithValue("@Sexo", pSexo);
                cmd.Parameters.AddWithValue("@TipoMontura", pTipoMontura);
                cmd.Parameters.AddWithValue("@TipoCria", pCria);
                cmd.Parameters.AddWithValue("@Predispuesto", predisp);
                cmd.Parameters.AddWithValue("@Padre", pPadre);
                cmd.Parameters.AddWithValue("@Madre", pMadre);

                idCria = (int)cmd.ExecuteScalar();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                idCria = 0;
                return false;
            }
            finally
            {
                MasterConnection.Close();
            }
        }
    
        public static bool ActualizarReproduccion(int pIdCria, int pPadre, int pMadre)
        {
            try
            {
                MasterConnection.Open();
                SqlCommand cmd = new("ActualizarReproduccion", MasterConnection.conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Cria", pIdCria);
                cmd.Parameters.AddWithValue("@Padre", pPadre);
                cmd.Parameters.AddWithValue("@Madre", pMadre);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                MasterConnection.Close();
            }
        }

        public static bool InsertarReproduccion(int pPadre, int pMadre)
        {
            try
            {
                MasterConnection.Open();
                SqlCommand cmd = new("InsertarReproduccion", MasterConnection.conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Padre", pPadre);
                cmd.Parameters.AddWithValue("@Madre", pMadre);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                MasterConnection.Close();
            }
        }

        public static bool CerrarReproduccion(int pPadre, int pMadre)
        {
            try
            {
                MasterConnection.Open();
                SqlCommand cmd = new("CerrarReproduccion", MasterConnection.conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Padre", pPadre);
                cmd.Parameters.AddWithValue("@Madre", pMadre);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                MasterConnection.Close();
            }
        }
    }
}
