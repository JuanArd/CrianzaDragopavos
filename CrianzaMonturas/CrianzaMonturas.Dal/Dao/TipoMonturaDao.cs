using CrianzaMonturas.Dal.Controlador;
using CrianzaMonturas.Dal.Modelo;
using CrianzaMonturas.Dal.Utilidades;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CrianzaMonturas.Dal.Dao
{
    public class TipoMonturaDao
    {
        public List<TipoMontura> CargarTipoMonturas()
        {
            List<TipoMontura> tipoMonturas = [];

            try
            {
                MasterConnection.Open();

                var query = "SELECT [Id], [Nombre] FROM [dbo].[TipoMontura];";

                using (var cmd = new SqlCommand(query, MasterConnection.Connection))
                {
                    cmd.CommandType = CommandType.Text;

                    using (var reader = cmd.ExecuteReader())
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
            catch (Exception ex)
            {
                Logger.WriteLog($"|{ex.Message} - {ex.StackTrace}|");
            }
            finally
            {
                MasterConnection.Close();
            }

            return tipoMonturas;
        }
    }
}
