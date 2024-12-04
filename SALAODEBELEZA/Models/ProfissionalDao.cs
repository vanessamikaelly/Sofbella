TOME

using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;
using SALAODEBELEZA.Models;
using SOFBELLASALAOOO.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace SALAODEBELEZA.Models
{
    public class ProfissionalDAO
    {
        private static ConnectionMysql conn;

        public ProfissionalDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Profissional profissional)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO produto (nome_pro, celular_pro, email_pro, cpf_pro, " +
                                    "sexo_pro, observacoes_pro, expediente_pro, possui_agenda_pro " +
                                    "ativo_pro, id_cate_fk, id_log_fk, id_perf_fk, id_end_fk) " +
                                    "VALUES (@Nome, @Celular, @Email, @CPF, @Sexo, " +
                                    "@Observacoes, @Expediente, @PossuiAgenda, @Ativo, @IdCateFk, @IdLogFk @IdPerfFk, @IdEndFk)";

                query.Parameters.AddWithValue("@Nome", profissional.NomePro);
                query.Parameters.AddWithValue("@Celular", profissional.Celular);
                query.Parameters.AddWithValue("@Email", profissional.Email);
                query.Parameters.AddWithValue("@CPF", profissional.Cpf);
                query.Parameters.AddWithValue("@Sexo", profissional.Sexo);
                query.Parameters.AddWithValue("@Observacoes", profissional.Observacoes);
                query.Parameters.AddWithValue("@Expediente", profissional.Expediente);
                query.Parameters.AddWithValue("@PossuiAgenda", profissional.Possui_Agenda);
                query.Parameters.AddWithValue("@Ativo", profissional.Ativo);
                query.Parameters.AddWithValue("@IdCateFk", profissional.IdCateFk);
                query.Parameters.AddWithValue("@IdLogFk", profissional.IdLogFk);
                query.Parameters.AddWithValue("@IdPerfFk", profissional.IdPerfFk);
                query.Parameters.AddWithValue("@IdEndFk", profissional.IdEndFk);

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

        public List<Profissional> List()
        {
            List<Profissional> lista = new List<Profissional>();

            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM profissional";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Profissional
                    {
                        Id = reader.GetInt32("id_pro"),
                        NomePro = reader.GetString("nome_pro"),
                        Celular = reader.GetString("celular_pro"),
                        Email = reader.GetString("email_pro"),
                        Cpf = reader.GetString("cpf_pro"),
                        Sexo = reader.GetString("sexo_pro"),
                        Observacoes = reader.GetString("observacoes_pro"),
                        Expediente = reader.GetString("expediente_pro"),
                        Possui_Agenda = reader.GetString("possui_agenda_pro"),
                        Ativo = reader.GetString("ativo_pro "),
                        IdCateFk = reader.GetInt32("id_cate_fk"),
                        IdLogFk = reader.GetInt32("id_log_fk"),
                        IdPerfFk = reader.GetInt32("id_perf_fk"),
                        IdEndFk = reader.GetInt32("id_end_fk")
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

        public Profissional GetById(int id)
        {
            try
            {
                Profissional profissional = null;

                var query = conn.Query();
                query.CommandText = "SELECT * FROM produto WHERE id_prod = @id";
                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        profissional = new Profissional
                        {
                            Id = reader.GetInt32("id_pro"),
                            NomePro = reader.GetString("nome_pro"),
                            Celular = reader.GetString("celular_pro"),
                            Email = reader.GetString("email_pro"),
                            Cpf = reader.GetString("cpf_pro"),
                            Sexo = reader.GetString("sexo_pro"),
                            Observacoes = reader.GetString("observacoes_pro"),
                            Expediente = reader.GetString("expediente_pro"),
                            Possui_Agenda = reader.GetString("possui_agenda_pro"),
                            Ativo = reader.GetString("ativo_pro "),
                            IdCateFk = reader.GetInt32("id_cate_fk"),
                            IdLogFk = reader.GetInt32("id_log_fk"),
                            IdPerfFk = reader.GetInt32("id_perf_fk"),
                            IdEndFk = reader.GetInt32("id_end_fk")
                        };
                    }
                }

                return profissional;
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
        public void Update(Profissional profissional)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO produto (nome_pro, celular_pro, email_pro, cpf_pro, " +
                                   "sexo_pro, observacoes_pro, expediente_pro, possui_agenda_pro " +
                                   "ativo_pro, id_cate_fk, id_log_fk, id_perf_fk, id_end_fk) " +
                                   "VALUES (@Nome, @Celular, @Email, @CPF, @Sexo, " +
                                   "@Observacoes, @Expediente, @PossuiAgenda, @Ativo, @IdCateFk, @IdLogFk @IdPerfFk, @IdEndFk)";

                query.Parameters.AddWithValue("@Nome", profissional.NomePro);
                query.Parameters.AddWithValue("@Celular", profissional.Celular);
                query.Parameters.AddWithValue("@Email", profissional.Email);
                query.Parameters.AddWithValue("@CPF", profissional.Cpf);
                query.Parameters.AddWithValue("@Sexo", profissional.Sexo);
                query.Parameters.AddWithValue("@Observacoes", profissional.Observacoes);
                query.Parameters.AddWithValue("@Expediente", profissional.Expediente);
                query.Parameters.AddWithValue("@PossuiAgenda", profissional.Possui_Agenda);
                query.Parameters.AddWithValue("@Ativo", profissional.Ativo);
                query.Parameters.AddWithValue("@IdCateFk", profissional.IdCateFk);
                query.Parameters.AddWithValue("@IdLogFk", profissional.IdLogFk);
                query.Parameters.AddWithValue("@IdPerfFk", profissional.IdPerfFk);
                query.Parameters.AddWithValue("@IdEndFk", profissional.IdEndFk);

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
                query.CommandText = "DELETE FROM produto WHERE id_pro = @Id";
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