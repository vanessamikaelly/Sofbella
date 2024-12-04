using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;

namespace SALAODEBELEZA.Models
{
    public class FornecedorDAO
    {
        private static ConnectionMysql _conn;

        public FornecedorDAO()
        {
            _conn = new ConnectionMysql();
        }

        public int Insert(Fornecedor fornecedor)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "INSERT INTO fornecedor (nome_forn, razao_social_forn, cnpj_forn, site_forn, id_end_fk) " +
                                    "VALUES (@nomeFantasia, @razaoSocial, @cnpj, @site, @idEndFk)";

                query.Parameters.AddWithValue("@nomeFantasia", fornecedor.NomeFantasia);
                query.Parameters.AddWithValue("@razaoSocial", fornecedor.RazaoSocial);
                query.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                query.Parameters.AddWithValue("@site", fornecedor.Site);
                query.Parameters.AddWithValue("@idEndFk", fornecedor.IdEndFk);

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

        public List<Fornecedor> List()
        {
            try
            {
                var lista = new List<Fornecedor>();
                var query = _conn.Query();
                query.CommandText = "SELECT * FROM fornecedor";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Fornecedor
                    {
                        Id = reader.GetInt32("id_forn"),
                        NomeFantasia = reader.GetString("nome_forn"),
                        RazaoSocial = reader.GetString("razao_social_forn"),
                        Cnpj = reader.GetString("cnpj_forn"),
                        Site = reader.GetString("site_forn"),
                        IdEndFk = reader.GetInt32("id_end_fk")
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

        public Fornecedor? GetById(int id)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "SELECT * FROM fornecedor WHERE id_forn = @_id";

                query.Parameters.AddWithValue("@_id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    return null;

                reader.Read();

                return new Fornecedor
                {
                    Id = reader.GetInt32("id_forn"),
                    NomeFantasia = reader.GetString("nome_forn"),
                    RazaoSocial = reader.GetString("razao_social_forn"),
                    Cnpj = reader.GetString("cnpj_forn"),
                    Site = reader.GetString("site_forn"),
                    IdEndFk = reader.GetInt32("id_end_fk")
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

        public void Update(Fornecedor fornecedor)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "UPDATE fornecedor SET nome_forn = @nomeFantasia, razao_social_forn = @razaoSocial, " +
                                    "cnpj_forn = @cnpj, site_forn = @site, id_end_fk = @idEndFk WHERE id_forn = @id";

                query.Parameters.AddWithValue("@nomeFantasia", fornecedor.NomeFantasia);
                query.Parameters.AddWithValue("@razaoSocial", fornecedor.RazaoSocial);
                query.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                query.Parameters.AddWithValue("@site", fornecedor.Site);
                query.Parameters.AddWithValue("@idEndFk", fornecedor.IdEndFk);
                query.Parameters.AddWithValue("@id", fornecedor.Id);

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
                query.CommandText = "DELETE FROM fornecedor WHERE id_forn = @_id";

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
