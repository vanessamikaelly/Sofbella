using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;
using SALAODEBELEZA.Models;
using System;
using System.Collections.Generic;

namespace SALAODEBELEZA.Models
{
    public class ExpedienteDAO1
    {
        private static ConnectionMysql conn;

        public ExpedienteDAO1()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Expediente expediente)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO expediente (nome_exp, dia_semana, hora_entrada_exp, almoco_inicio_exp, almoco_fim_exp, intervalo_almoco_exp, hora_saida_exp, id_pro_fk) " +
                                    "VALUES (@Nome, @DiaSemana, @HoraEntrada, @AlmocoInicio, @AlmocoFim, @IntervaloAlmoco, @HoraSaida, @IdProFK)";

                query.Parameters.AddWithValue("@Nome", expediente.Nome);
                query.Parameters.AddWithValue("@DiaSemana", expediente.Dia);
                query.Parameters.AddWithValue("@HoraEntrada", expediente.HoraEntrada);
                query.Parameters.AddWithValue("@AlmocoInicio", expediente.AlmoçoInicio);
                query.Parameters.AddWithValue("@AlmocoFim", expediente.AlmoçoFinal);
                query.Parameters.AddWithValue("@IntervaloAlmoco", expediente.IntervaloAlmoço);
                query.Parameters.AddWithValue("@HoraSaida", expediente.HoraSaida);
                query.Parameters.AddWithValue("@IdProFK", expediente.FuncionarioIdFK);

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

        public List<Expediente> List()
        {
            List<Expediente> lista = new List<Expediente>();

            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM expediente";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Expediente
                    {
                        Id = reader.GetInt32("id_exp"),
                        Nome = reader.GetString("nome_exp"),
                        Dia = reader.GetString("dia_semana"),
                        HoraEntrada = reader.GetDateTime("hora_entrada_exp"),
                        AlmoçoInicio = reader.GetDateTime("almoco_inicio_exp"),
                        AlmoçoFinal = reader.GetDateTime("almoco_fim_exp"),
                        IntervaloAlmoço = reader.GetBoolean("intervalo_almoco_exp"),
                        HoraSaida = reader.GetDateTime("hora_saida_exp"),
                        FuncionarioIdFK = reader.GetInt32("id_pro_fk")
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

        public Expediente GetById(int id)
        {
            try
            {
                Expediente expediente = new Expediente();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM expediente WHERE id_exp = @id";
                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    expediente.Id = reader.GetInt32("id_exp");
                    expediente.Nome = reader.GetString("nome_exp");
                    expediente.Dia = reader.GetString("dia_semana");
                    expediente.HoraEntrada = reader.GetDateTime("hora_entrada_exp");
                    expediente.AlmoçoInicio = reader.GetDateTime("almoco_inicio_exp");
                    expediente.AlmoçoFinal = reader.GetDateTime("almoco_fim_exp");
                    expediente.IntervaloAlmoço = reader.GetBoolean("intervalo_almoco_exp");
                    expediente.HoraSaida = reader.GetDateTime("hora_saida_exp");
                    expediente.FuncionarioIdFK = reader.GetInt32("id_pro_fk");
                }

                return expediente;
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

        public void Update(Expediente expediente)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE expediente SET nome_exp = @Nome, dia_semana = @DiaSemana, hora_entrada_exp = @HoraEntrada, " +
                                    "almoco_inicio_exp = @AlmocoInicio, almoco_fim_exp = @AlmocoFim, intervalo_almoco_exp = @IntervaloAlmoco, " +
                                    "hora_saida_exp = @HoraSaida, id_pro_fk = @IdProFK WHERE id_exp = @Id";

                query.Parameters.AddWithValue("@Nome", expediente.Nome);
                query.Parameters.AddWithValue("@DiaSemana", expediente.Dia);
                query.Parameters.AddWithValue("@HoraEntrada", expediente.HoraEntrada);
                query.Parameters.AddWithValue("@AlmocoInicio", expediente.AlmoçoInicio);
                query.Parameters.AddWithValue("@AlmocoFim", expediente.AlmoçoFinal);
                query.Parameters.AddWithValue("@IntervaloAlmoco", expediente.IntervaloAlmoço);
                query.Parameters.AddWithValue("@HoraSaida", expediente.HoraSaida);
                query.Parameters.AddWithValue("@IdProFK", expediente.FuncionarioIdFK);
                query.Parameters.AddWithValue("@Id", expediente.Id);

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
                query.CommandText = "DELETE FROM expediente WHERE id_exp = @Id";
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
