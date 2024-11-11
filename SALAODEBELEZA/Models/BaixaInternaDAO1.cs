using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;
using SALAODEBELEZA.Models;
using System;
using System.Collections.Generic;

namespace SALAODEBELEZA.Models
{
    public class BaixaInternaDAO1
    {
        private static ConnectionMysql conn;

        public BaixaInternaDAO1()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(BaixaInterna baixa)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO baixa_uso_interno (nome_baixa, estoqueatual_baixa, baixarestoque_baixa, descricao_baixa, id_est_fk) " +
                                    "VALUES (@Nome, @EstoqueAtual, @BaixarEstoque, @Descricao, @IdEstoqueFk)";

                query.Parameters.AddWithValue("@Nome", baixa.Nome);
                query.Parameters.AddWithValue("@EstoqueAtual", baixa.EstoqueAtual);
                query.Parameters.AddWithValue("@BaixarEstoque", baixa.BaixarEstoque);
                query.Parameters.AddWithValue("@Descricao", baixa.Descricao);
                query.Parameters.AddWithValue("@IdEstoqueFk", baixa.IdEstoqueFk);

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

        public List<BaixaInterna> List()
        {
            List<BaixaInterna> lista = new List<BaixaInterna>();

            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM baixa_uso_interno";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new BaixaInterna
                    {
                        Id = reader.GetInt32("id_baixa"),
                        Nome = reader.GetString("nome_baixa"),
                        EstoqueAtual = reader.GetInt32("estoqueatual_baixa"),
                        BaixarEstoque = reader.GetInt32("baixarestoque_baixa"),
                        Descricao = reader.GetString("descricao_baixa"),
                        IdEstoqueFk = reader.GetInt32("id_est_fk")
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

        public BaixaInterna GetById(int id)
        {
            try
            {
                BaixaInterna baixa = new BaixaInterna();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM baixa_uso_interno WHERE id_baixa = @id";
                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    baixa.Id = reader.GetInt32("id_baixa");
                    baixa.Nome = reader.GetString("nome_baixa");
                    baixa.EstoqueAtual = reader.GetInt32("estoqueatual_baixa");
                    baixa.BaixarEstoque = reader.GetInt32("baixarestoque_baixa");
                    baixa.Descricao = reader.GetString("descricao_baixa");
                    baixa.IdEstoqueFk = reader.GetInt32("id_est_fk");
                }

                return baixa;
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

        public void Update(BaixaInterna baixa)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE baixa_uso_interno SET nome_baixa = @Nome, estoqueatual_baixa = @EstoqueAtual, " +
                                    "baixarestoque_baixa = @BaixarEstoque, descricao_baixa = @Descricao, id_est_fk = @IdEstoqueFk " +
                                    "WHERE id_baixa = @Id";

                query.Parameters.AddWithValue("@Nome", baixa.Nome);
                query.Parameters.AddWithValue("@EstoqueAtual", baixa.EstoqueAtual);
                query.Parameters.AddWithValue("@BaixarEstoque", baixa.BaixarEstoque);
                query.Parameters.AddWithValue("@Descricao", baixa.Descricao);
                query.Parameters.AddWithValue("@IdEstoqueFk", baixa.IdEstoqueFk);
                query.Parameters.AddWithValue("@Id", baixa.Id);

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
                query.CommandText = "DELETE FROM baixa_uso_interno WHERE id_baixa = @Id";
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
