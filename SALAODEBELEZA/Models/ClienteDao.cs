using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using SALAODEBELEZA.DataBase;
using SALAODEBELEZA.Models;
using SOFBELLASALAOOO.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace SALAODEBELEZA.Models
{
  
        public class ClienteDAO
        {
            private static ConnectionMysql conn;

            public ClienteDAO()
            {
                conn = new ConnectionMysql();
            }

            public int Insert(Cliente cliente)
            {
                try
                {
                    var query = conn.Query();
                    query.CommandText = "INSERT INTO cliente (nome_cli, email_cli, tel_cli, " +
                                        "cpf_cli, sexo_cli, data_nasc_cli, id_end_fk)" +
                                        "VALUES (@Nome, @Email, @Telefone, @CPF, @Sexo, @DataNasci, @IdEndFk)";

                    query.Parameters.AddWithValue("@Nome", cliente.NomeCli);
                    query.Parameters.AddWithValue("@DataNasci", cliente.DataNascimento.ToString("yyyy-MM-dd HH:mm:ss"));
                    query.Parameters.AddWithValue("@Email", cliente.EmailCli);
                    query.Parameters.AddWithValue("@Telefone", cliente.TelefoneCli);
                    query.Parameters.AddWithValue("@CPF", cliente.CPFCli);
                    query.Parameters.AddWithValue("@Sexo", cliente.SexoCli);
                    query.Parameters.AddWithValue("@IdEndFk", cliente.IdEndFk);


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

            public List<Cliente> List()
            {
                List<Cliente> lista = new List<Cliente>();

                try
                {
                    var query = conn.Query();
                    query.CommandText = "SELECT * FROM cliente";

                    MySqlDataReader reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new Cliente
                        {
                            Id = reader.GetInt32("id_cli"),
                            NomeCli = reader.GetString("nome_cli"),
                            DataNascimento = reader.GetDateTime("data_nasc_cli"),
                            EmailCli = reader.GetString("email_cli"),
                            TelefoneCli = reader.GetString("tel_cli"),
                            CPFCli = reader.GetString("cpf_cli"),
                            SexoCli = reader.GetString("sexo_cli"),
                            IdEndFk = reader.GetInt32("id_end_fk"),
               

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

            public Cliente GetById(int id)
            {
                try
                {
                    Cliente cliente = null;

                    var query = conn.Query();
                    query.CommandText = "SELECT * FROM cliente WHERE id_cli = @id";
                    query.Parameters.AddWithValue("@id", id);

                    MySqlDataReader reader = query.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            cliente = new Cliente
                            {
                                Id = reader.GetInt32("id_cli"),
                                NomeCli = reader.GetString("nome_cli"),
                                DataNascimento = reader.GetDateTime("data_nasc_cli"),
                                EmailCli = reader.GetString("email_cli"),
                                TelefoneCli = reader.GetString("tel_cli"),
                                CPFCli = reader.GetString("cpf_cli"),
                                SexoCli = reader.GetString("nome_cli"),
                                IdEndFk = reader.GetInt32("id_end_fk"),

                            };
                        }
                    }

                    return cliente;
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

            public void Update(Cliente cliente)
            {
                try
                {
                    var query = conn.Query();
                    query.CommandText = "UPDATE cliente SET nome_cli = @Nome, email_cli = @Email, " +
                                        "tel_cli = @Telefone, cpf_cli = @CPF, " +
                                        "sexo_cli = @Sexo, data_nasc_cli = @DataNasci, id_end_fk = @IdEndFk";

                    query.Parameters.AddWithValue("@Nome", cliente.NomeCli);
                    query.Parameters.AddWithValue("@DataNasci", cliente.DataNascimento.ToString("yyyy-MM-dd HH:mm:ss"));
                    query.Parameters.AddWithValue("@Email", cliente.EmailCli);
                    query.Parameters.AddWithValue("@Telefone", cliente.TelefoneCli);
                    query.Parameters.AddWithValue("@CPF", cliente.CPFCli);
                    query.Parameters.AddWithValue("@Sexo", cliente.SexoCli);
                    query.Parameters.AddWithValue("@IdEndFk", cliente.IdEndFk);
                

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
                    query.CommandText = "DELETE FROM cliente WHERE id_cli = @Id";
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
