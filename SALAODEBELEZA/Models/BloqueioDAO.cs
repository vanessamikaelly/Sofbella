using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;
using System;
using System.Collections.Generic;

namespace SOFBELLASALAOOO.Models
{
    public class BloqueioDAO
    {
        private static ConnectionMysql conn;

        public BloqueioDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Bloqueio bloqueio)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO bloqueio (profissional_blo, data_inicio_blo, hora_inicio_blo, data_fim_blo, hora_fim_blo, motivo_bloqueio_blo, dia_inteiro_blo) " +
                                    "VALUES (@Profissional, @DataInicio, @HoraInicio, @DataFinal, @HoraFinal, @Motivo, @DiaInteiro)";

                query.Parameters.AddWithValue("@Profissional", bloqueio.Profissional);
                query.Parameters.AddWithValue("@DataInicio", bloqueio.DataInicio);
                query.Parameters.AddWithValue("@HoraInicio", bloqueio.HoraInicio);
                query.Parameters.AddWithValue("@DataFinal", bloqueio.DataFinal);
                query.Parameters.AddWithValue("@HoraFinal", bloqueio.HoraFinal);
                query.Parameters.AddWithValue("@Motivo", bloqueio.Motivo);
                query.Parameters.AddWithValue("@DiaInteiro", bloqueio.DiaInteiro);

                query.ExecuteNonQuery();

                return (int)query.LastInsertedId;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir: " + ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Bloqueio> List()
        {
            List<Bloqueio> lista = new List<Bloqueio>();

            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM bloqueio";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Bloqueio
                    {
                        Id = reader.GetInt32("id_blo"),
                        Profissional = reader.GetInt32("profissional_blo"),
                        DataInicio = reader.GetDateTime("data_inicio_blo"),
                        HoraInicio = reader.GetDateTime("hora_inicio_blo"),
                        DataFinal = reader.GetDateTime("data_fim_blo"),
                        HoraFinal = reader.GetDateTime("hora_fim_blo"),
                        Motivo = reader.GetString("motivo_bloqueio_blo"),
                        DiaInteiro = reader.GetBoolean("dia_inteiro_blo")
                    });
                }

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar: " + ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public Bloqueio? GetById(int id)
        {
            try
            {
                Bloqueio bloqueio = new Bloqueio();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM bloqueio WHERE id_blo = @id";
                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    bloqueio.Id = reader.GetInt32("id_blo");
                    bloqueio.Profissional = reader.GetInt32("profissional_blo");
                    bloqueio.DataInicio = reader.GetDateTime("data_inicio_blo");
                    bloqueio.HoraInicio = reader.GetDateTime("hora_inicio_blo");
                    bloqueio.DataFinal = reader.GetDateTime("data_fim_blo");
                    bloqueio.HoraFinal = reader.GetDateTime("hora_fim_blo");
                    bloqueio.Motivo = reader.GetString("motivo_bloqueio_blo");
                    bloqueio.DiaInteiro = reader.GetBoolean("dia_inteiro_blo");
                }

                return bloqueio;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao buscar por ID: " + ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Update(Bloqueio bloqueio)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE bloqueio SET profissional_blo = @Profissional, data_inicio_blo = @DataInicio, " +
                                    "hora_inicio_blo = @HoraInicio, data_fim_blo = @DataFinal, hora_fim_blo = @HoraFinal, " +
                                    "motivo_bloqueio_blo = @Motivo, dia_inteiro_blo = @DiaInteiro " +
                                    "WHERE id_blo = @Id";

                query.Parameters.AddWithValue("@Profissional", bloqueio.Profissional);
                query.Parameters.AddWithValue("@DataInicio", bloqueio.DataInicio);
                query.Parameters.AddWithValue("@HoraInicio", bloqueio.HoraInicio);
                query.Parameters.AddWithValue("@DataFinal", bloqueio.DataFinal);
                query.Parameters.AddWithValue("@HoraFinal", bloqueio.HoraFinal);
                query.Parameters.AddWithValue("@Motivo", bloqueio.Motivo);
                query.Parameters.AddWithValue("@DiaInteiro", bloqueio.DiaInteiro);
                query.Parameters.AddWithValue("@Id", bloqueio.Id);

                query.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar: " + ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Delete(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM bloqueio WHERE id_blo = @Id";
                query.Parameters.AddWithValue("@Id", id);

                query.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao excluir: " + ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
