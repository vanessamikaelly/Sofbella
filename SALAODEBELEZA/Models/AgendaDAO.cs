using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;

namespace SALAODEBELEZA.Models
{
    public class AgendaDAO
    {
        private static ConnectionMysql conn;

        public AgendaDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Agenda agenda)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO agenda (data_agend, telefone_agend, nome_cliente_agend, observacoes_agend, responsavel_agend, " +
                                    "hora_agend, tempo_atendimento_agend, servico_agend, id_pro_fk, id_cli_fk) " +
                                    "VALUES (@Data, @Telefone, @NomeCliente, @Observacoes, @Responsavel, @Hora, @TempoAtendimento, @Servico, @IdProFk, @IdCliFk)";

               
                query.Parameters.AddWithValue("@Data", agenda.Data);
                query.Parameters.AddWithValue("@Telefone", agenda.Telefone);
                query.Parameters.AddWithValue("@NomeCliente", agenda.NomeCliente);
                query.Parameters.AddWithValue("@Observacoes", agenda.Observacoes);
                query.Parameters.AddWithValue("@Responsavel", agenda.Responsavel);
                query.Parameters.AddWithValue("@Hora", agenda.Hora);
                query.Parameters.AddWithValue("@TempoAtendimento", agenda.TempoAtendimento);
                query.Parameters.AddWithValue("@Servico", agenda.Servico);
                query.Parameters.AddWithValue("@IdProFk", agenda.IdProFk);
                query.Parameters.AddWithValue("@IdCliFk", agenda.IdCliFk);

                
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

        public List<Agenda> List()
        {
            List<Agenda> lista = new List<Agenda>();

            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM agenda";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Agenda
                    {
                        Id = reader.GetInt32("id_agend"),
                        Data = reader.GetDateTime("data_agend"),
                        Telefone = reader.GetString("telefone_agend"),
                        NomeCliente = reader.GetString("nome_cliente_agend"),
                        Observacoes = reader.GetString("observacoes_agend"),
                        Responsavel = reader.GetString("responsavel_agend"),
                        Hora = reader.GetDateTime("hora_agend"),
                        TempoAtendimento = reader.GetDateTime("tempo_atendimento_agend"),
                        Servico = reader.GetString("servico_agend"),
                        IdProFk = reader.GetInt32("id_pro_fk"),
                        IdCliFk = reader.GetInt32("id_cli_fk")
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

        public Agenda GetById(int id)
        {
            try
            {
                Agenda agenda = null;

                var query = conn.Query();
                query.CommandText = "SELECT * FROM agenda WHERE id_agend = @id";
                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    agenda = new Agenda
                    {
                        Id = reader.GetInt32("id_agend"),
                        Data = reader.GetDateTime("data_agend"),
                        Telefone = reader.GetString("telefone_agend"),
                        NomeCliente = reader.GetString("nome_cliente_agend"),
                        Observacoes = reader.GetString("observacoes_agend"),
                        Responsavel = reader.GetString("responsavel_agend"),
                        Hora = reader.GetDateTime("hora_agend"),
                        TempoAtendimento = reader.GetDateTime("tempo_atendimento_agend"),
                        Servico = reader.GetString("servico_agend"),
                        IdProFk = reader.GetInt32("id_pro_fk"),
                        IdCliFk = reader.GetInt32("id_cli_fk")
                    };
                }

                return agenda;
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

        public void Update(Agenda agenda)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE agenda SET data_agend = @Data, telefone_agend = @Telefone, nome_cliente_agend = @NomeCliente, " +
                                    "observacoes_agend = @Observacoes, responsavel_agend = @Responsavel, hora_agend = @Hora, " +
                                    "tempo_atendimento_agend = @TempoAtendimento, servico_agend = @Servico, id_pro_fk = @IdProFk, " +
                                    "id_cli_fk = @IdCliFk WHERE id_agend = @Id";

                query.Parameters.AddWithValue("@Data", agenda.Data);
                query.Parameters.AddWithValue("@Telefone", agenda.Telefone);
                query.Parameters.AddWithValue("@NomeCliente", agenda.NomeCliente);
                query.Parameters.AddWithValue("@Observacoes", agenda.Observacoes);
                query.Parameters.AddWithValue("@Responsavel", agenda.Responsavel);
                query.Parameters.AddWithValue("@Hora", agenda.Hora);
                query.Parameters.AddWithValue("@TempoAtendimento", agenda.TempoAtendimento);
                query.Parameters.AddWithValue("@Servico", agenda.Servico);
                query.Parameters.AddWithValue("@IdProFk", agenda.IdProFk);
                query.Parameters.AddWithValue("@IdCliFk", agenda.IdCliFk);
                query.Parameters.AddWithValue("@Id", agenda.Id);

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
                query.CommandText = "DELETE FROM agenda WHERE id_agend = @Id";
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
