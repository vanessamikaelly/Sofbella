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
        private static ConnectionMysql conn;

        public EnderecoDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Endereco endereco)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO endereco (rua_end, bairro_end, numero_end, cidade_end, estado_end, pais_end, cep_end) " +
                                    "VALUES (@rua, @bairro, @numero, @cidade, @estado, @pais, @cep)";

                query.Parameters.AddWithValue("@rua", endereco.Rua);
                query.Parameters.AddWithValue("@bairro", endereco.Bairro);
                query.Parameters.AddWithValue("@numero", endereco.Numero);
                query.Parameters.AddWithValue("@cidade", endereco.Cidade);
                query.Parameters.AddWithValue("@estado", endereco.Estado);
                query.Parameters.AddWithValue("@pais", endereco.Pais);
                query.Parameters.AddWithValue("@cep", endereco.CEP);

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

        public List<Endereco> List()
        {
            try
            {
                List<Endereco> list = new List<Endereco>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM endereco";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Endereco()
                    {
                        Id = reader.GetInt32("id_end"),
                        Rua = reader.GetString("rua_end"),
                        Bairro = reader.GetString("bairro_end"),
                        Numero = reader.GetString("numero_end"),
                        Cidade = reader.GetString("cidade_end"),
                        Estado = reader.GetString("estado_end"),
                        Pais = reader.GetString("pais_end"),
                        CEP = reader.GetString("cep_end")
                    });
                }

                return list;
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

        public Endereco GetById(int id)
        {
            try
            {
                Endereco endereco = new Endereco();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM endereco WHERE id_end = @id";
                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    endereco.Id = reader.GetInt32("id_end");
                    endereco.Rua = reader.GetString("rua_end");
                    endereco.Bairro = reader.GetString("bairro_end");
                    endereco.Numero = reader.GetString("numero_end");
                    endereco.Cidade = reader.GetString("cidade_end");
                    endereco.Estado = reader.GetString("estado_end");
                    endereco.Pais = reader.GetString("pais_end");
                    endereco.CEP = reader.GetString("cep_end");
                }

                return endereco;
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

        public void Update(Endereco endereco)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE endereco SET rua_end = @rua, bairro_end = @bairro, numero_end = @numero, cidade_end = @cidade, estado_end = @estado, pais_end = @pais, cep_end = @cep WHERE id_end = @id";

                query.Parameters.AddWithValue("@rua", endereco.Rua);
                query.Parameters.AddWithValue("@bairro", endereco.Bairro);
                query.Parameters.AddWithValue("@numero", endereco.Numero);
                query.Parameters.AddWithValue("@cidade", endereco.Cidade);
                query.Parameters.AddWithValue("@estado", endereco.Estado);
                query.Parameters.AddWithValue("@pais", endereco.Pais);
                query.Parameters.AddWithValue("@cep", endereco.CEP);
                query.Parameters.AddWithValue("@id", endereco.Id);

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
                query.CommandText = "DELETE FROM endereco WHERE id_end = @id";
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

