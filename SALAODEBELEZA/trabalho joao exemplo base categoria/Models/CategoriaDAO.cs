/*using ApiTarefas2.Database;
using MySql.Data.MySqlClient;

namespace ApiTarefas2.Models
{
    public class CategoriaDAO
    {

        private static ConnectionMysql conn;

        public CategoriaDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Categoria item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO categorias (nome_cat) VALUES (@nome)";

                query.Parameters.AddWithValue("@nome", item.Nome);

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
                conn.Close();
            }
        }

        public List<Categoria> List()
        {
            try
            {
                List<Categoria> list = new List<Categoria>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM categorias";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Categoria()
                    {
                        Id = reader.GetInt32("id_cat"),
                        Nome = reader.GetString("nome_cat")
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
                conn.Close();
            }
        }

        public Categoria? GetById(int id)
        {
            try
            {
                Categoria _categoria = new Categoria();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM categorias WHERE id_cat = @_id";

                query.Parameters.AddWithValue("@_id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    _categoria.Id = reader.GetInt32("id_cat");
                    _categoria.Nome = reader.GetString("nome_cat");
                }

                return _categoria;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Update(Categoria item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE categorias SET nome_cat = @_nome WHERE id_cat = @_id";

                query.Parameters.AddWithValue("@_nome", item.Nome);
                query.Parameters.AddWithValue("@_id", item.Id);

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
                conn.Close();
            }
        }

        public void Delete(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM categorias WHERE id_cat = @_id";

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
                conn.Close();
            }
        }
    }
}*/
