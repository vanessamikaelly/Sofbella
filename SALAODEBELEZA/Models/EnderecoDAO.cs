using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

namespace SALAODEBELEZA.Models
{
    public class EnderecoDAO
    {
        private static ConnectionMysql _conn;

        public EnderecoDAO()
        {
            _conn = new ConnectionMysql();
        }

        public int Insert(Endereco item)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "INSERT INTO tarefas (rua_end, bairro_end, numero_end, cidade_end, estado_end, pais_end, cep_end " +
                    "VALUES (@rua, @bairro, @numero, @cidade, @estado, @pais, @cep)";

                query.Parameters.AddWithValue("@rua", item.Rua);
                query.Parameters.AddWithValue("@bairro", item.Bairro);
                query.Parameters.AddWithValue("@numero", item.Numero);
                query.Parameters.AddWithValue("@cidade", item.Cidade);
                query.Parameters.AddWithValue("@estado", item.Estado);
                query.Parameters.AddWithValue("@pais", item.Pais);
                query.Parameters.AddWithValue("@cep", item.CEP);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente");
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

        public List<Endereco> List()
        {
            try
            {
                List<Endereco> list = new List<Endereco>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM endereco";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Endereco()
                    {
                        Id = reader.GetInt32("id_end"),
                        Rua = reader.GetString("rua_end"),
                        Bairro = reader.GetString(" bairro_end"),
                        Numero = reader.GetString("numero_end"),
                        Cidade = reader.GetString("cidade_end"),
                        Estado = reader.GetString("estado_end"),
                        Pais = reader.GetString("pais_end"),
                        CEP = reader.GetString("cep_end"),

                    });
                }

                return list;
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

        public Endereco? GetById(int id)
        {
            try
            {
                Endereco _endereco = new Endereco();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM endereco WHERE id_end = @_id";

                query.Parameters.AddWithValue("@_id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    _endereco.Id = reader.GetInt32("id_end");
                    _endereco.Rua = reader.GetString("rua_end");
                    _endereco.Bairro = reader.GetString(" bairro_end");
                    _endereco.Numero = reader.GetString("numero_end");
                    _endereco.Cidade = reader.GetString("cidade_end");
                    _endereco.Estado = reader.GetString("estado_end");
                    _endereco.Pais = reader.GetString("pais_end");
                    _endereco.CEP = reader.GetString("cep_end");
                }

                return _endereco;
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

        public void Update(Endereco item)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "UPDATE endereco SET rua_end = @_rua, bairro_end = @_bairro, numero_end = @_numero, cidade_end = @_cidade, estado_end = @_estado, pais_end = @_pais, cep_end = @_cep";

                query.Parameters.AddWithValue("@_rua", item.Rua);
                query.Parameters.AddWithValue("@_bairro", item.Bairro);
                query.Parameters.AddWithValue("@_numero", item.Numero);
                query.Parameters.AddWithValue("@_cidade", item.Cidade);
                query.Parameters.AddWithValue("@_estado", item.Estado);
                query.Parameters.AddWithValue("@_pais", item.Pais);
                query.Parameters.AddWithValue("@_cep", item.CEP);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi atualizado. Verifique e tente novamente");
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
                query.CommandText = "DELETE FROM endereco WHERE id_end = @_id";

                query.Parameters.AddWithValue("@_id", id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi excluído. Verifique e tente novamente");
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

