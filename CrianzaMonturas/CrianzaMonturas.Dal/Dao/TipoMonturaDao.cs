using CrianzaMonturas.Dal.Controlador;
using CrianzaMonturas.Dal.Modelo;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace CrianzaMonturas.Dal.Dao
{
    public static class TipoMonturaDao
    {
        public static List<TipoMontura> CargarTipoMonturas()
        {
            List<TipoMontura> tipoMonturas = new();

            try
            {
                MasterConnection.Open();

                var query = "SELECT [Id], [Nombre] FROM [dbo].[TipoMontura];";

                using (SqlCommand cmd = new(query, MasterConnection.connection))
                {
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TipoMontura tipoMontura = new()
                            {
                                Id = reader.GetInt32("Id"),
                                Nombre = reader.GetString("Nombre")
                            };

                            tipoMonturas.Add(tipoMontura);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                MasterConnection.Close();
            }

            return tipoMonturas;
        }
    }
}
