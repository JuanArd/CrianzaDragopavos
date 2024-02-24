using CrianzaMonturas.Dal.Contratos;
using CrianzaMonturas.Dal.Controlador;
using CrianzaMonturas.Dal.Modelo;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace CrianzaMonturas.Dal.Dao
{
    public class MonturaDao
    {

        private List<Montura> CargarPadres(Dictionary<IMontura, List<int>> padres)
        {
            List<Montura> monturas = new();

            foreach(var kvp in padres)
            {
                Montura monturaActual = (Montura)kvp.Key;

                monturaActual.Padre = this.CargarMonturaPorId(kvp.Value[0]);
                monturaActual.Madre = this.CargarMonturaPorId(kvp.Value[1]);

                monturas.Add(monturaActual);
            }

            return monturas;
        }

        private Montura CargarMonturaPorId(int id)
        {
            Montura montura = new();
            
            try
            {
                MasterConnection.Open();

                var query = "SELECT [Id], [Nombre], [Salvaje], [Sexo], [TipoId], [Predispuesto], " +
                    "[Padre], [Madre], [Reproducciones], [MaxReproducciones], [Esteril] " +
		            "FROM [dbo].[Montura] WHERE Id = @Id;";

                using (var cmd = new SqlCommand(query, MasterConnection.connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id", id);
                    var padres = new Dictionary<string, int>();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Montura nuevaMontura = new()
                            {
                                Id = reader.GetInt32("Id"),
                                Nombre = reader.GetString("Nombre"),
                                Salvaje = reader.GetBoolean("Salvaje"),
                                Sexo = reader.GetString("Sexo"),
                                TipoId = reader.GetInt32("TipoId"),
                                Predispuesto = reader.GetBoolean("Predispuesto"),
                                Reproducciones = Convert.ToInt32(reader.GetByte("Reproducciones")),
                                MaxReproducciones = Convert.ToInt32(reader.GetByte("Reproducciones")),
                                Esteril = reader.GetBoolean("Esteril")
                            };

                            padres.Add("P", reader.GetInt32("Padre"));
                            padres.Add("M", reader.GetInt32("Madre"));

                            montura = nuevaMontura;
                        }
                    }

                    if (padres.Count > 0)
                    {
                        montura.Padre = this.CargarMonturaPorId(padres["P"]);
                        montura.Madre = this.CargarMonturaPorId(padres["M"]);
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

            return montura;
        }

        public List<Montura> CargarMonturas(int tipoMontura)
        {
            List<Montura> monturas = new();

            try
            {
                MasterConnection.Open();

                var query = "SELECT [Id], [Nombre], [Salvaje], [Sexo], [TipoId], [Predispuesto], " +
                    "[Padre], [Madre], [Reproducciones], [MaxReproducciones], [Esteril] " +
                    "FROM [dbo].[Montura] WHERE TipoMonturaId = @TipoMontura " +
                    "AND (Esteril = 0 AND Reproducible = 1) OR (Esteril = 1 AND Fecundada = 1)" +
                    "ORDER BY TipoId, Nombre;";

                using (var cmd = new SqlCommand(query, MasterConnection.connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@TipoMontura", tipoMontura);
                    var padres = new Dictionary<IMontura, List<int>>();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Montura montura = new()
                            {
                                Id = reader.GetInt32("Id"),
                                Nombre = reader.GetString("Nombre"),
                                Salvaje = reader.GetBoolean("Salvaje"),
                                Sexo = reader.GetString("Sexo"),
                                TipoId = reader.GetInt32("TipoId"),
                                Predispuesto = reader.GetBoolean("Predispuesto"),
                                Reproducciones = Convert.ToInt32(reader.GetByte("Reproducciones")),
                                MaxReproducciones = Convert.ToInt32(reader.GetByte("Reproducciones")),
                                Esteril = reader.GetBoolean("Esteril")
                            };

                            padres.Add(montura, new List<int> { reader.GetInt32("Padre"), reader.GetInt32("Madre") });
                        }
                    }

                    monturas = CargarPadres(padres);
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

            return monturas;
        }

        public int InsertarCria(IMontura cria)
        {
            int idCria = 0;

            try
            {
                MasterConnection.Open();

                using(var cmd = new SqlCommand("InsertarCria", MasterConnection.connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", cria.Nombre);
                    cmd.Parameters.AddWithValue("@Sexo", cria.Sexo);
                    cmd.Parameters.AddWithValue("@TipoMontura", cria.TipoMonturaId);
                    cmd.Parameters.AddWithValue("@TipoCria", cria.TipoId);
                    cmd.Parameters.AddWithValue("@Predispuesto", cria.Predispuesto);
                    cmd.Parameters.AddWithValue("@Padre", cria.Padre!.Id);
                    cmd.Parameters.AddWithValue("@Madre", cria.Madre!.Id);

                    idCria = (int)cmd.ExecuteScalar();
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

            return idCria;
        }
    }
}
