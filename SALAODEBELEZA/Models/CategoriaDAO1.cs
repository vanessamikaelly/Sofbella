using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;
using System;
using System.Collections.Generic;

namespace SALAODEBELEZA.Models
{
    public class CategoriaDAO1
    {
        private static ConnectionMysql conn;

        public CategoriaDAO1()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Categoria categoria)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO categoria (nome_cate, tipo_cate, descricao_cate) " +
                                    "VALUES (@Nome, @Tipo, @Descricao)";

                query.Parameters.AddWithValue("@Nome", categoria.Nome);
                query.Parameters.AddWithValue("@Tipo", categoria.Tipo);
                query.Parameters.AddWithValue("@Descricao", categoria.Descricao);

                query.ExecuteNonQuery();

                return (int)query.LastInsertedId;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir categoria: " + ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Categoria> List()
        {
            List<Categoria> lista = new List<Categoria>();

            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM categoria";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Categoria
                    {
                        Id = reader.GetInt32("id_cate"),
                        Nome = reader.GetString("nome_cate"),
                        Tipo = reader.GetString("tipo_cate"),
                        Descricao = reader.GetString("descricao_cate")
                    });
                }

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar categorias: " + ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public Categoria GetById(int id)
        {
            try
            {
                Categoria categoria = null;

                var query = conn.Query();
                query.CommandText = "SELECT * FROM categoria WHERE id_cate = @Id";
                query.Parameters.AddWithValue("@Id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (reader.Read())
                {
                    categoria = new Categoria
                    {
                        Id = reader.GetInt32("id_cate"),
                        Nome = reader.GetString("nome_cate"),
                        Tipo = reader.GetString("tipo_cate"),
                        Descricao = reader.GetString("descricao_cate")
                    };
                }

                return categoria;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao buscar categoria por ID: " + ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Update(Categoria categoria)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE categoria SET nome_cate = @Nome, tipo_cate = @Tipo, descricao_cate = @Descricao " +
                                    "WHERE id_cate = @Id";

                query.Parameters.AddWithValue("@Nome", categoria.Nome);
                query.Parameters.AddWithValue("@Tipo", categoria.Tipo);
                query.Parameters.AddWithValue("@Descricao", categoria.Descricao);
                query.Parameters.AddWithValue("@Id", categoria.Id);

                query.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar categoria: " + ex.Message);
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
                query.CommandText = "DELETE FROM categoria WHERE id_cate = @Id";
                query.Parameters.AddWithValue("@Id", id);

                query.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao excluir categoria: " + ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
