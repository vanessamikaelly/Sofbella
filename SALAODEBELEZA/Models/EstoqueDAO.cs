using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;
using SALAODEBELEZA.Models;
using System;
using System.Collections.Generic;

namespace SOFBELLASALAOOO.Models
{
    public class EstoqueDAO
    {
        private static ConnectionMysql conn;

        public EstoqueDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Estoque estoque)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO estoque (nomeprod_est, estoque_atual_est, entrada_est, preco_compra_est, preco_venda_est, id_forn_fk, id_prod_fk) " +
                                    "VALUES (@nomeProduto, @estoqueAtual, @entrada, @precoCompra, @precoVenda, @idFornFk, @idProdFk)";

                query.Parameters.AddWithValue("@nomeProduto", estoque.NomeProduto);
                query.Parameters.AddWithValue("@estoqueAtual", estoque.EstoqueAtual);
                query.Parameters.AddWithValue("@entrada", estoque.Entrada);
                query.Parameters.AddWithValue("@precoCompra", estoque.PrecoCompra);
                query.Parameters.AddWithValue("@precoVenda", estoque.PrecoVenda);
                query.Parameters.AddWithValue("@idFornFk", estoque.IdFornFk);
                query.Parameters.AddWithValue("@idProdFk", estoque.IdProdFk);

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

        public List<Estoque> List()
        {
            try
            {
                List<Estoque> lista = new List<Estoque>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM estoque";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Estoque()
                    {
                        Id = reader.GetInt32("id_est"),
                        NomeProduto = reader.GetString("nomeprod_est"),
                        EstoqueAtual = reader.GetInt32("estoque_atual_est"),
                        Entrada = reader.GetInt32("entrada_est"),
                        PrecoCompra = reader.GetDouble("preco_compra_est"),
                        PrecoVenda = reader.GetDouble("preco_venda_est"),
                        IdFornFk = reader.GetInt32("id_forn_fk"),
                        IdProdFk = reader.GetInt32("id_prod_fk")
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

        public Estoque GetById(int id)
        {
            try
            {
                Estoque estoque = new Estoque();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM estoque WHERE id_est = @id";
                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    estoque.Id = reader.GetInt32("id_est");
                    estoque.NomeProduto = reader.GetString("nomeprod_est");
                    estoque.EstoqueAtual = reader.GetInt32("estoque_atual_est");
                    estoque.Entrada = reader.GetInt32("entrada_est");
                    estoque.PrecoCompra = reader.GetDouble("preco_compra_est");
                    estoque.PrecoVenda = reader.GetDouble("preco_venda_est");
                    estoque.IdFornFk = reader.GetInt32("id_forn_fk");
                    estoque.IdProdFk = reader.GetInt32("id_prod_fk");
                }

                return estoque;
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

        public void Update(Estoque estoque)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE estoque SET nomeprod_est = @nomeProduto, estoque_atual_est = @estoqueAtual, entrada_est = @entrada, " +
                                    "preco_compra_est = @precoCompra, preco_venda_est = @precoVenda, id_forn_fk = @idFornFk, id_prod_fk = @idProdFk " +
                                    "WHERE id_est = @id";

                query.Parameters.AddWithValue("@nomeProduto", estoque.NomeProduto);
                query.Parameters.AddWithValue("@estoqueAtual", estoque.EstoqueAtual);
                query.Parameters.AddWithValue("@entrada", estoque.Entrada);
                query.Parameters.AddWithValue("@precoCompra", estoque.PrecoCompra);
                query.Parameters.AddWithValue("@precoVenda", estoque.PrecoVenda);
                query.Parameters.AddWithValue("@idFornFk", estoque.IdFornFk);
                query.Parameters.AddWithValue("@idProdFk", estoque.IdProdFk);
                query.Parameters.AddWithValue("@id", estoque.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi atualizado. Verifique e tente novamente.");
                }
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
                query.CommandText = "DELETE FROM estoque WHERE id_est = @id";
                query.Parameters.AddWithValue("@id", id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi excluído. Verifique e tente novamente.");
                }
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
