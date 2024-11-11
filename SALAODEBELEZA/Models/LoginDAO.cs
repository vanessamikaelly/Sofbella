using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;
using SALAODEBELEZA.Models;
using System;
using System.Collections.Generic;

namespace SALAODEBELEZA.Models
{
    public class LoginDAO
    {
        private static ConnectionMysql conn;

        public LoginDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Login login)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO login (email_log, senha_log) VALUES (@Email, @Senha)";

                query.Parameters.AddWithValue("@Email", login.Email);
                query.Parameters.AddWithValue("@Senha", login.Senha);

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

        public List<Login> List()
        {
            List<Login> lista = new List<Login>();

            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM login";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Login
                    {
                        Id = reader.GetInt32("id_log"),
                        Email = reader.GetString("email_log"),
                        Senha = reader.GetString("senha_log")
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

        public Login GetById(int id)
        {
            try
            {
                Login login = null;

                var query = conn.Query();
                query.CommandText = "SELECT * FROM login WHERE id_log = @Id";
                query.Parameters.AddWithValue("@Id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (reader.Read())
                {
                    login = new Login
                    {
                        Id = reader.GetInt32("id_log"),
                        Email = reader.GetString("email_log"),
                        Senha = reader.GetString("senha_log")
                    };
                }

                return login;
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

        public void Update(Login login)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE login SET email_log = @Email, senha_log = @Senha WHERE id_log = @Id";

                query.Parameters.AddWithValue("@Email", login.Email);
                query.Parameters.AddWithValue("@Senha", login.Senha);
                query.Parameters.AddWithValue("@Id", login.Id);

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
                query.CommandText = "DELETE FROM login WHERE id_log = @Id";
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
