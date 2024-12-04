using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;
using SALAODEBELEZA.Models;
using System;
using System.Collections.Generic;

namespace SOFBELLASALAOOO.Models
{
    public class EstoqueDAO
    {
        private static ConnectionMysql _conn;

        public EstoqueDAO()
        {
            _conn = new ConnectionMysql();
        }

        public int Insert(Estoque item)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "INSERT INTO estoque (nomeprod_est, estoque_atual_est, entrada_est, preco_compra_est, preco_venda_est, id_forn_fk, id_prod_fk) " +
                                    "VALUES (@nomeProduto, @estoqueAtual, @entrada, @precoCompra, @precoVenda, @idFornFk, @idProdFk)";

                query.Parameters.AddWithValue("@nomeProduto", item.NomeProduto);
                query.Parameters.AddWithValue("@estoqueAtual", item.EstoqueAtual);
                query.Parameters.AddWithValue("@entrada", item.Entrada);
                query.Parameters.AddWithValue("@precoCompra", item.PrecoCompra);
                query.Parameters.AddWithValue("@precoVenda", item.PrecoVenda);
                query.Parameters.AddWithValue("@idFornFk", item.IdFornFk);
                query.Parameters.AddWithValue("@idProdFk", item.IdProdFk);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente.");
                }

                return (int)query.LastInsertedId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public List<Estoque> List()
        {
            try
            {
                var lista = new List<Estoque>();
                var query = _conn.Query();
                query.CommandText = "SELECT * FROM estoque";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Estoque
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
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public Estoque? GetById(int id)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "SELECT * FROM estoque WHERE id_est = @_id";

                query.Parameters.AddWithValue("@_id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    return null;

                reader.Read();

                return new Estoque
                {
                    Id = reader.GetInt32("id_est"),
                    NomeProduto = reader.GetString("nomeprod_est"),
                    EstoqueAtual = reader.GetInt32("estoque_atual_est"),
                    Entrada = reader.GetInt32("entrada_est"),
                    PrecoCompra = reader.GetDouble("preco_compra_est"),
                    PrecoVenda = reader.GetDouble("preco_venda_est"),
                    IdFornFk = reader.GetInt32("id_forn_fk"),
                    IdProdFk = reader.GetInt32("id_prod_fk")
                };
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public void Update(Estoque item)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "UPDATE estoque SET nomeprod_est = @nomeProduto, estoque_atual_est = @estoqueAtual, entrada_est = @entrada, " +
                                    "preco_compra_est = @precoCompra, preco_venda_est = @precoVenda, id_forn_fk = @idFornFk, id_prod_fk = @idProdFk " +
                                    "WHERE id_est = @id";

                query.Parameters.AddWithValue("@nomeProduto", item.NomeProduto);
                query.Parameters.AddWithValue("@estoqueAtual", item.EstoqueAtual);
                query.Parameters.AddWithValue("@entrada", item.Entrada);
                query.Parameters.AddWithValue("@precoCompra", item.PrecoCompra);
                query.Parameters.AddWithValue("@precoVenda", item.PrecoVenda);
                query.Parameters.AddWithValue("@idFornFk", item.IdFornFk);
                query.Parameters.AddWithValue("@idProdFk", item.IdProdFk);
                query.Parameters.AddWithValue("@id", item.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi atualizado. Verifique e tente novamente.");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public void Delete(int id)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "DELETE FROM estoque WHERE id_est = @_id";

                query.Parameters.AddWithValue("@_id", id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi excluído. Verifique e tente novamente.");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
