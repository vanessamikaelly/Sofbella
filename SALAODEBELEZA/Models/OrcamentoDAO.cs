using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;

namespace SALAODEBELEZA.Models
{
    public class OrcamentoDAO
    {
        private static ConnectionMysql _conn;

        public OrcamentoDAO()
        {
            _conn = new ConnectionMysql();
        }

        public int Insert(Orcamento item)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "INSERT INTO orcamento (descricao_orca, data_orca, forma_pagamento_orca, valor_orca, id_serv_fk) " +
                                    "VALUES (@descricao, @data, @forma_pagamento, @valor, @id_serv_fk)";

                query.Parameters.AddWithValue("@descricao", item.Descricao);
                query.Parameters.AddWithValue("@data", item.Data);
                query.Parameters.AddWithValue("@forma_pagamento", item.Forma_Pagamento);
                query.Parameters.AddWithValue("@valor", item.Valor);
                query.Parameters.AddWithValue("@id_serv_fk", item.IdServFk);

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

        public List<Orcamento> List()
        {
            try
            {
                var lista = new List<Orcamento>();
                var query = _conn.Query();
                query.CommandText = "SELECT * FROM orcamento";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Orcamento
                    {
                        Id = reader.GetInt32("id_orca"),
                        Descricao = reader.GetString("descricao_orca"),
                        Data = reader.GetDateTime("data_orca"),
                        Forma_Pagamento = reader.GetInt32("forma_pagamento_orca"),
                        Valor = reader.GetFloat("valor_orca"),
                        IdServFk = reader.GetInt32("id_serv_fk")
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

        public Orcamento? GetById(int id)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "SELECT * FROM orcamento WHERE id_orca = @_id";

                query.Parameters.AddWithValue("@_id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    return null;

                reader.Read();

                return new Orcamento
                {
                    Id = reader.GetInt32("id_orca"),
                    Descricao = reader.GetString("descricao_orca"),
                    Data = reader.GetDateTime("data_orca"),
                    Forma_Pagamento = reader.GetInt32("forma_pagamento_orca"),
                    Valor = reader.GetFloat("valor_orca"),
                    IdServFk = reader.GetInt32("id_serv_fk")
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

        public void Update(Orcamento item)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "UPDATE orcamento SET descricao_orca = @descricao, data_orca = @data, forma_pagamento_orca = @forma_pagamento, valor_orca = @valor, id_serv_fk = @id_serv_fk WHERE id_orca = @id";

                query.Parameters.AddWithValue("@descricao", item.Descricao);
                query.Parameters.AddWithValue("@data", item.Data);
                query.Parameters.AddWithValue("@forma_pagamento", item.Forma_Pagamento);
                query.Parameters.AddWithValue("@valor", item.Valor);
                query.Parameters.AddWithValue("@id_serv_fk", item.IdServFk);
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
                query.CommandText = "DELETE FROM orcamento WHERE id_orca = @_id";

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
