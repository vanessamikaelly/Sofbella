using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;
using SALAODEBELEZA.Models;
using System;
using System.Collections.Generic;

namespace SOFBELLASALAOOO.Models
{
    public class PagamentoDAO
    {
        private static ConnectionMysql _conn;

        public PagamentoDAO()
        {
            _conn = new ConnectionMysql();
        }

        public int Insert(Pagamento pagamento)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = @"INSERT INTO pagamento (data_pag, valor_pag, desconto_pag, forma_pagamento_pag, id_caix_fk, id_serv_fk, id_orca_fk, id_cli_fk)
                                  VALUES (@dataPagamento, @valor, @desconto, @formaPagamento, @idCaiFk, @idServFk, @idOrcaFk, @idCliFk)";

                query.Parameters.AddWithValue("@dataPagamento", pagamento.DataPagamento);
                query.Parameters.AddWithValue("@valor", pagamento.Valor);
                query.Parameters.AddWithValue("@desconto", pagamento.Desconto);
                query.Parameters.AddWithValue("@formaPagamento", pagamento.FormaPagamento);
                query.Parameters.AddWithValue("@idCaiFk", pagamento.IdCaiFk);
                query.Parameters.AddWithValue("@idServFk", pagamento.IdServFk);
                query.Parameters.AddWithValue("@idOrcaFk", pagamento.IdOrcaFk);
                query.Parameters.AddWithValue("@idCliFk", pagamento.IdCliFk);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente.");

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

        public List<Pagamento> List()
        {
            try
            {
                var lista = new List<Pagamento>();
                var query = _conn.Query();
                query.CommandText = "SELECT * FROM pagamento";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Pagamento
                    {
                        Id = reader.GetInt32("id_pag"),
                        DataPagamento = reader.GetDateTime("data_pag"),
                        Valor = reader.GetFloat("valor_pag"),
                        Desconto = reader.GetFloat("desconto_pag"),
                        FormaPagamento = reader.GetInt32("forma_pagamento_pag"),
                        IdCaiFk = reader.GetInt32("id_caix_fk"),
                        IdServFk = reader.GetInt32("id_serv_fk"),
                        IdOrcaFk = reader.GetInt32("id_orca_fk"),
                        IdCliFk = reader.GetInt32("id_cli_fk")
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

        public Pagamento? GetById(int id)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "SELECT * FROM pagamento WHERE id_pag = @_id";

                query.Parameters.AddWithValue("@_id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    return null;

                reader.Read();

                return new Pagamento
                {
                    Id = reader.GetInt32("id_pag"),
                    DataPagamento = reader.GetDateTime("data_pag"),
                    Valor = reader.GetFloat("valor_pag"),
                    Desconto = reader.GetFloat("desconto_pag"),
                    FormaPagamento = reader.GetInt32("forma_pagamento_pag"),
                    IdCaiFk = reader.GetInt32("id_caix_fk"),
                    IdServFk = reader.GetInt32("id_serv_fk"),
                    IdOrcaFk = reader.GetInt32("id_orca_fk"),
                    IdCliFk = reader.GetInt32("id_cli_fk")
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

        public void Update(Pagamento pagamento)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = @"UPDATE pagamento SET data_pag = @dataPagamento, valor_pag = @valor, desconto_pag = @desconto, 
                                  forma_pagamento_pag = @formaPagamento, id_caix_fk = @idCaiFk, id_serv_fk = @idServFk, 
                                  id_orca_fk = @idOrcaFk, id_cli_fk = @idCliFk WHERE id_pag = @id";

                query.Parameters.AddWithValue("@dataPagamento", pagamento.DataPagamento);
                query.Parameters.AddWithValue("@valor", pagamento.Valor);
                query.Parameters.AddWithValue("@desconto", pagamento.Desconto);
                query.Parameters.AddWithValue("@formaPagamento", pagamento.FormaPagamento);
                query.Parameters.AddWithValue("@idCaiFk", pagamento.IdCaiFk);
                query.Parameters.AddWithValue("@idServFk", pagamento.IdServFk);
                query.Parameters.AddWithValue("@idOrcaFk", pagamento.IdOrcaFk);
                query.Parameters.AddWithValue("@idCliFk", pagamento.IdCliFk);
                query.Parameters.AddWithValue("@id", pagamento.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O registro não foi atualizado. Verifique e tente novamente.");
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
                query.CommandText = "DELETE FROM pagamento WHERE id_pag = @_id";

                query.Parameters.AddWithValue("@_id", id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O registro não foi excluído. Verifique e tente novamente.");
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
