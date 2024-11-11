using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;
using SALAODEBELEZA.Models;
using System;
using System.Collections.Generic;

namespace SALAODEBELEZA.Models
{
    public class PacoteDAO
    {
        private static ConnectionMysql conn;

        public PacoteDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Pacote pacote)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO pacote (nome_pacote_pac, valor_pacote_pac, validade_pacote_pac, itens_pacote_pac) " +
                                    "VALUES (@Nome, @Preco, @Validade, @Itens)";

                query.Parameters.AddWithValue("@Nome", pacote.Nome);
                query.Parameters.AddWithValue("@Preco", pacote.Preco);
                query.Parameters.AddWithValue("@Validade", pacote.Validade);
                query.Parameters.AddWithValue("@Itens", pacote.Itens);

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

        public List<Pacote> List()
        {
            List<Pacote> lista = new List<Pacote>();

            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM pacote";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Pacote
                    {
                        Id = reader.GetInt32("id_pac"),
                        Nome = reader.GetString("nome_pacote_pac"),
                        Preco = reader.GetFloat("valor_pacote_pac"),
                        Validade = reader.GetDateTime("validade_pacote_pac"),
                        Itens = reader.GetString("itens_pacote_pac")
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

        public Pacote GetById(int id)
        {
            try
            {
                Pacote pacote = new Pacote();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM pacote WHERE id_pac = @Id";
                query.Parameters.AddWithValue("@Id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    pacote.Id = reader.GetInt32("id_pac");
                    pacote.Nome = reader.GetString("nome_pacote_pac");
                    pacote.Preco = reader.GetFloat("valor_pacote_pac");
                    pacote.Validade = reader.GetDateTime("validade_pacote_pac");
                    pacote.Itens = reader.GetString("itens_pacote_pac");
                }

                return pacote;
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

        public void Update(Pacote pacote)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE pacote SET nome_pacote_pac = @Nome, valor_pacote_pac = @Preco, validade_pacote_pac = @Validade, itens_pacote_pac = @Itens " +
                                    "WHERE id_pac = @Id";

                query.Parameters.AddWithValue("@Nome", pacote.Nome);
                query.Parameters.AddWithValue("@Preco", pacote.Preco);
                query.Parameters.AddWithValue("@Validade", pacote.Validade);
                query.Parameters.AddWithValue("@Itens", pacote.Itens);
                query.Parameters.AddWithValue("@Id", pacote.Id);

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
                query.CommandText = "DELETE FROM pacote WHERE id_pac = @Id";
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
