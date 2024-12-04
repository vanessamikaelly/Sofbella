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
    public class ProdutoDAO
    {
        private static ConnectionMysql conn;

        public ProdutoDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Produto produto)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO produto (nome_prod, descricao_prod, codigo_barras_prod, valor_prod, valor_custo_prod, comissao_prod, id_cate_fk ) " +
                                    "VALUES (@Nome, @Descricao, @CodigoBarras, @Preco, @PrecoCusto, @Comissao, @IdCateFk)";


                query.Parameters.AddWithValue("@Nome", produto.Nome);
                query.Parameters.AddWithValue("@Descricao", produto.Descricao);
                query.Parameters.AddWithValue("@CodigoBarras", produto.CodigoBarras);
                query.Parameters.AddWithValue("@Preco", produto.Preco);
                query.Parameters.AddWithValue("@PrecoCusto", produto.PrecoCusto);
                query.Parameters.AddWithValue("@Comissao", produto.Comissao);
                query.Parameters.AddWithValue("@IdCateFk", produto.IdCateFk);

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

        public List<Produto> List()
        {
            List<Produto> lista = new List<Produto>();

            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM produto";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Produto
                    {
                        Id = reader.GetInt32("id_prod"),
                        Nome = reader.GetString("nome_prod"),
                        Descricao = reader.GetString("descricao_prod"),
                        CodigoBarras = reader.GetString("codigo_barras_prod"),
                        Preco = reader.GetInt32("valor_prod"),
                        PrecoCusto = reader.GetInt32("valor_custo_prod"),
                        Comissao = reader.GetInt32("comissao_prod"),
                        IdCateFk = reader.GetInt32("id_cate_fk"),
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

        public Produto GetById(int id)
        {
            try
            {
                Produto produto = null;

                var query = conn.Query();
                query.CommandText = "SELECT * FROM produto WHERE id_prod = @id";
                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        produto = new Produto
                        {
                            Id = reader.GetInt32("id_prod"),
                            Nome = reader.GetString("nome_prod"),
                            Descricao = reader.GetString("descricao_prod"),
                            CodigoBarras = reader.GetString("codigo_barras_prod"),
                            Preco = reader.GetInt32("valor_prod"),
                            PrecoCusto = reader.GetInt32("valor_custo_prod"),
                            Comissao = reader.GetInt32("comissao_prod"),
                            IdCateFk = reader.GetInt32("id_cate_fk"),
                        };
                    }
                }

                return produto;
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
        public void Update(Produto produto)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE produto SET nome_prod = @Nome, descricao_prod = @Descricao, " +
                                    "codigo_barras_prod = @CodigoBarras, " +
                                    "valor_prod = @Preco, valor_custo_prod = @PrecoCusto, " +
                                    "comissao_prod = @Comissao, id_cate_fk = @IdCateFk WHERE id_prod = @Id";

                query.Parameters.AddWithValue("@Nome", produto.Nome);
                query.Parameters.AddWithValue("@Descricao", produto.Descricao);
                query.Parameters.AddWithValue("@CodigoBarras", produto.CodigoBarras);
                query.Parameters.AddWithValue("@Preco", produto.Preco);
                query.Parameters.AddWithValue("@PrecoCusto", produto.PrecoCusto);
                query.Parameters.AddWithValue("@Comissao", produto.Comissao);
                query.Parameters.AddWithValue("@IdCateFk", produto.IdCateFk);
                query.Parameters.AddWithValue("@Id", produto.Id);

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
                query.CommandText = "DELETE FROM produto WHERE id_prod = @Id";
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