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
                                    "duracao_serv, comissao_serv)" +
                                    "VALUES (@Nome, @Descricao, @Valor, @Duracao, @Comissao)";

                query.Parameters.AddWithValue("@Nome", servico.NomeServico);
                query.Parameters.AddWithValue("@Descricao", servico.Descricao);
                query.Parameters.AddWithValue("@Valor", servico.PrecoUnitario);
                query.Parameters.AddWithValue("@Duracao", servico.DuracaoAtendimento);
                query.Parameters.AddWithValue("@Comissao", servico.Comissao);

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
                        PrecoUnitario = reader.GetDouble("valor_serv"),
                        DuracaoAtendimento = reader.GetString("duracao_serv"),
                        Comissao = reader.GetDouble("comissao_serv")
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
                            PrecoUnitario = reader.GetDouble("valor_serv"),
                            DuracaoAtendimento = reader.GetString("duracao_serv"),
                            Comissao = reader.GetDouble("comissao_serv")
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
                query.CommandText = "UPDATE servico SET nome_serv = @Nome, descricao_serv = @Descricao, " +
                                    "valor_serv = @Valor, duracao_serv = @Duracao, " +
                                    "comissao_serv = @Comissao";

                query.Parameters.AddWithValue("@Nome", servico.NomeServico);
                query.Parameters.AddWithValue("@Descricao", servico.Descricao);
                query.Parameters.AddWithValue("@Valor", servico.PrecoUnitario);
                query.Parameters.AddWithValue("@Duracao", servico.DuracaoAtendimento);
                query.Parameters.AddWithValue("@Comissao", servico.Comissao);


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
