﻿using CrianzaMonturas.Dal.Controlador;
using CrianzaMonturas.Dal.Modelo;
using CrianzaMonturas.Dal.Utilidades;
using System.Data;
using System.Data.SqlClient;

namespace CrianzaMonturas.Dal.Dao
{
    public class TipoDao
    {
        public List<Tipo> CargarTipos(int tipoMontura)
        {
            List<Tipo> tipos = [];

            try
            {
                MasterConnection.Open();

                var query = "SELECT [Id], [Alias], [Nombre], [Imagen], [Sigla], [Generacion] " +
                    "FROM [dbo].[Tipo] WHERE [TipoMonturaId] = @TipoMontura;";

                using (var cmd = new SqlCommand(query, MasterConnection.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@TipoMontura", tipoMontura);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tipo tipo = new()
                            {
                                Id = reader.GetInt32("Id"),
                                Alias = reader.GetValue("Alias") != DBNull.Value ? reader.GetString("Alias") : string.Empty,
                                Nombre = reader.GetValue("Nombre") != DBNull.Value ? reader.GetString("Nombre") : string.Empty,
                                Imagen = reader.GetValue("Imagen") != DBNull.Value ? (Byte[])reader.GetValue("Imagen") : [],
                                Sigla = reader.GetValue("Sigla") != DBNull.Value ? reader.GetString("Sigla") : string.Empty,
                                Generacion = reader.GetValue("Generacion") != DBNull.Value ? reader.GetInt32("Generacion") : 0
                            };

                            tipos.Add(tipo);
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

            return tipos;
        }
    }
}
