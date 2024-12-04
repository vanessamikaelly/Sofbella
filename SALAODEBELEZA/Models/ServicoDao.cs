using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;

namespace SALAODEBELEZA.Models
{
    public class ServicoDao
    {
        private static ConnectionMysql conn;

        public ServicoDao()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Servico servico)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO servico (nome_serv, descricao_serv, valor_serv, " +
                                    "duracao_serv, comissao_serv, id_cate_fk)" +
                                    "VALUES (@Nome, @Descricao, @Valor, @Duracao, @Comissao, @IdCateFk)";

                query.Parameters.AddWithValue("@Nome", servico.NomeServico);
                query.Parameters.AddWithValue("@Descricao", servico.Descricao);
                query.Parameters.AddWithValue("@Valor", servico.Valor);
                query.Parameters.AddWithValue("@Duracao", servico.DuracaoAtendimento);
                query.Parameters.AddWithValue("@Comissao", servico.Comissao);
                query.Parameters.AddWithValue("@IdCateFk", servico.IdCateFk);

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

        public List<Servico> List()
        {
            List<Servico> lista = new List<Servico>();

            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM servico";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Servico
                    {
                        Id = reader.GetInt32("id_cli"),
                        NomeServico = reader.GetString("nome_serv"),
                        Descricao = reader.GetString("descricao_serv"),
                        Valor = reader.GetDouble("valor_serv"),
                        DuracaoAtendimento = reader.GetString("duracao_serv"),
                        Comissao = reader.GetDouble("comissao_serv"),
                        IdCateFk = reader.GetInt32("id_cate_fk"),
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

        public Servico GetById(int id)
        {
            try
            {
                Servico servico = null;

                var query = conn.Query();
                query.CommandText = "SELECT * FROM servico WHERE id_serv = @id";
                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        servico = new Servico
                        {
                            Id = reader.GetInt32("id_cli"),
                            NomeServico = reader.GetString("nome_serv"),
                            Descricao = reader.GetString("descricao_serv"),
                            Valor = reader.GetDouble("valor_serv"),
                            DuracaoAtendimento = reader.GetString("duracao_serv"),
                            Comissao = reader.GetDouble("comissao_serv"),
                            IdCateFk = reader.GetInt32("id_cate_fk"),
                        };
                    }
                }

                return servico;
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

        public void Update(Servico servico)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO servico (nome_serv, descricao_serv, valor_serv, " +
                                   "duracao_serv, comissao_serv, id_cate_fk)" +
                                   "VALUES (@Nome, @Descricao, @Valor, @Duracao, @Comissao, @IdCateFk)";

                query.Parameters.AddWithValue("@Nome", servico.NomeServico);
                query.Parameters.AddWithValue("@Descricao", servico.Descricao);
                query.Parameters.AddWithValue("@Valor", servico.Valor);
                query.Parameters.AddWithValue("@Duracao", servico.DuracaoAtendimento);
                query.Parameters.AddWithValue("@Comissao", servico.Comissao);
                query.Parameters.AddWithValue("@IdCateFk", servico.IdCateFk);


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
                query.CommandText = "DELETE FROM servico WHERE id_serv = @Id";
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
