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
                query.CommandText = "INSERT INTO produto (nome_pro, celular_pro, email_pro, senha_pro, cpf_pro, " +
                                    "sexo_pro, observacoes_pro, expediente_pro, categoria_pro, perfil_acesso_pro, possui_agenda_pro, rg_pro, " +
                                    "data_nasc_pro, ativo_pro ) " +
                                    "VALUES (@Nome, @Celular, @Email, @Senha, @CPF, @Sexo, " +
                                    "@Observacoes, @Expediente, @Categoria, @PerfilAcesso, @PossuiAgenda, @RG, @DataNascimento, @Ativo )";

                query.Parameters.AddWithValue("@Nome", profissional.Nome);
                query.Parameters.AddWithValue("@Celular", profissional.Celular);
                query.Parameters.AddWithValue("@Email", profissional.Email);
                query.Parameters.AddWithValue("@Senha", profissional.Senha);
                query.Parameters.AddWithValue("@CPF", profissional.CPF);
                query.Parameters.AddWithValue("@Sexo", profissional.Sexo);
                query.Parameters.AddWithValue("@Observacoes", profissional.Observacoes);
                query.Parameters.AddWithValue("@Expediente", profissional.Expediente);
                query.Parameters.AddWithValue("@Categoria", profissional.Categoria);
                query.Parameters.AddWithValue("@PerfilAcesso", profissional.PerfilAcesso);
                query.Parameters.AddWithValue("@PossuiAgenda", profissional.PossuiAgenda);
                query.Parameters.AddWithValue("@RG", profissional.RG);
                query.Parameters.AddWithValue("@DataNascimento", profissional.DataNascimento);
                query.Parameters.AddWithValue("@Ativo", profissional.Ativo);
                query.Parameters.AddWithValue("@Id", profissional.Id);

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
                        Nome = reader.GetString("nome_pro"),
                        Celular = reader.GetString("celular_pro"),
                        Email = reader.GetString("email_pro"),
                        Senha = reader.GetString("senha_pro"),
                        CPF = reader.GetString("cpf_pro"),
                        Sexo = reader.GetInt32("sexo_pro"),
                        Observacoes = reader.GetString("observacoes_pro"),
                        Expediente = reader.GetString("expediente_pro"),
                        Categoria = reader.GetString("categoria_pro"),
                        PerfilAcesso = reader.GetString("perfil_acesso_pro"),
                        PossuiAgenda = reader.GetString("possui_agenda_pro"),
                        RG = reader.GetString("rg_pro"),
                        DataNascimento = reader.GetDateTime("data_nasc_pro"),
                        Ativo = reader.GetString("ativo_pro "),
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
                        profissional = new profissional
                        {
                            Id = reader.GetInt32("id_pro"),
                            Nome = reader.GetString("nome_pro"),
                            Celular = reader.GetString("celular_pro"),
                            Email = reader.GetString("email_pro"),
                            Senha = reader.GetString("senha_pro"),
                            CPF = reader.GetString("cpf_pro"),
                            Sexo = reader.GetInt32("sexo_pro"),
                            Observacoes = reader.GetString("observacoes_pro"),
                            Expediente = reader.GetString("expediente_pro"),
                            Categoria = reader.GetString("categoria_pro"),
                            PerfilAcesso = reader.GetString("perfil_acesso_pro"),
                            PossuiAgenda = reader.GetString("possui_agenda_pro"),
                            RG = reader.GetString("rg_pro"),
                            DataNascimento = reader.GetDateTime("data_nasc_pro"),
                            Ativo = reader.GetString("ativo_pro "),
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
                query.CommandText = "UPDATE profissional SET nome_prod = @Nome, celular_pro = @Celular, email_pro = @Email, senha_pro = @Senha, " +
                                    "cpf_pro = @CPF, sexo_pro = @Sexo, observacoes_pro = @Observacoes, expediente_pro = @Expediente, categoria_pro = @Categoria, " +
                                    "perfil_acesso_pro = @PerfilAcesso, possui_agenda_pro = @PossuiAgenda, rg_pro = @RG, data_nasc_pro = @DataNascimento, " +
                                    "ativo_pro = @Ativo, WHERE id_pro = @Id";

                query.Parameters.AddWithValue("@Nome", profissional.Nome);
                query.Parameters.AddWithValue("@Celular", profissional.Celular);
                query.Parameters.AddWithValue("@Email", profissional.Email);
                query.Parameters.AddWithValue("@Senha", profissional.Senha);
                query.Parameters.AddWithValue("@CPF", profissional.CPF);
                query.Parameters.AddWithValue("@Sexo", profissional.Sexo);
                query.Parameters.AddWithValue("@Observacoes", profissional.Observacoes);
                query.Parameters.AddWithValue("@Expediente", profissional.Expediente);
                query.Parameters.AddWithValue("@Categoria", profissional.Categoria);
                query.Parameters.AddWithValue("@PerfilAcesso", profissional.PerfilAcesso);
                query.Parameters.AddWithValue("@PossuiAgenda", profissional.PossuiAgenda);
                query.Parameters.AddWithValue("@RG", profissional.RG);
                query.Parameters.AddWithValue("@DataNascimento", profissional.DataNascimento);
                query.Parameters.AddWithValue("@Ativo", profissional.Ativo);
                query.Parameters.AddWithValue("@Id", profissional.Id);

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