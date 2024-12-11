/*using ApiTarefas2.Database;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ApiTarefas2.Models
{
    public class TarefaDAO
    {
        private static ConnectionMysql conn;

        public TarefaDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Tarefa item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO tarefas (descricao_tar, data_tar) VALUES (@descricao, @data, @id_cat)";

                query.Parameters.AddWithValue("@descricao", item.Descricao);
                query.Parameters.AddWithValue("@data", item.Data.ToString("yyyy-MM-dd HH:mm:ss")); //"10/11/1990" -> "1990-11-10"
                query.Parameters.AddWithValue("@id_cat", item.Categoria.Id);




                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente");
                }

                return (int) query.LastInsertedId;
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

        public List<Tarefa> List()
        {
            try
            {
                List<Tarefa> list = new List<Tarefa>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM tarefas LEFT JOIN categorias ON id_cat = id_cat_fk";


                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    var tarefa = new Tarefa()
                    {
                        Id = reader.GetInt32("id_tar"),
                        Descricao = reader.GetString("descricao_tar"),
                        Data = reader.GetDateTime("data_tar"),
                        Feito = reader.GetBoolean("feito_tar")
                    };

                    if (!reader.IsDBNull(4))            
                    {
                        var categoria = new Categoria()
                        {
                            Id = reader.GetInt32("id_cat"),
                            Nome = reader.GetString("nome_cat")
                        };

                        tarefa.Categoria = categoria;
                    }

                    list.Add(tarefa);

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

       
        public Tarefa? GetById(int id)
        {
            try
            {
                Tarefa _tarefa = new Tarefa();
 
                var query = conn.Query();
                query.CommandText = "SELECT * FROM tarefas LEFT JOIN categorias ON id_cat = id_cat_fk";

                query.Parameters.AddWithValue("@_id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {

                    var tarefa = new Tarefa();
                    {
                        _tarefa.Id = reader.GetInt32("id_tar");
                        _tarefa.Descricao = reader.GetString("descricao_tar");
                        _tarefa.Data = reader.GetDateTime("data_tar");
                        _tarefa.Feito = reader.GetBoolean("feito_tar");

                    };

                    if (!reader.IsDBNull(4))
                    {
                        var categoria = new Categoria()
                        {
                            Id = reader.GetInt32("id_cat"),
                            Nome = reader.GetString("nome_cat")
                        };

                        tarefa.Categoria = categoria;

                    }
  

                }

                return _tarefa;
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

        public void Update(Tarefa item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE tarefas SET descricao_tar = @_descricao, feito_tar = @_feito WHERE id_tar = @_id";

                query.Parameters.AddWithValue("@_descricao", item.Descricao);
                query.Parameters.AddWithValue("@_feito", item.Feito);
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
                query.CommandText = "DELETE FROM tarefas WHERE id_tar = @_id";

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
