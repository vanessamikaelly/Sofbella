using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;
using SALAODEBELEZA.Models;
using System;
using System.Collections.Generic;

namespace SOFBELLASALAOOO.Models
{
    public class PagamentoDAO
    {
        private static ConnectionMysql conn;

        public PagamentoDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Pagamento pagamento)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO comanda (id_pag, data_pag, valor_pag, desconto_pag, forma_pagamento_pag, id_caix_fk, id_serv_fk," + " id_orca_fk, id_cli_fk) " +
                                    "VALUES (@Identificacao, @Data, @Valor, @Desconto, @Forma, @Caixa, @Servico, @Orcamento, @Cliente)";

                query.Parameters.AddWithValue("@Identificacao", pagamento.Identificacao);
                query.Parameters.AddWithValue("@Data", pagamento.Data);
                query.Parameters.AddWithValue("@Valor", pagamento.Valor);
                query.Parameters.AddWithValue("@Desconto", pagamento.Desconto);
                query.Parameters.AddWithValue("@Forma", pagamento.Forma);
                query.Parameters.AddWithValue("@Caixa", pagamento.Caixa);
                query.Parameters.AddWithValue("@Servico", pagamento.Servico);
                query.Parameters.AddWithValue("@Orcamento", pagamento.Orcamento);
                query.Parameters.AddWithValue("@Cliente", pagamento.Cliente);


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

        public List<Pagamento> List()
        {
            List<Pagamento> lista = new List<Pagamento>();

            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM pagamento";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Pagamento
                    {
                        Id = reader.GetInt32("id_pag"),
                        Identificacao = reader.GetInt32("id_pag"),
                        Data = reader.GetDateTime("data_pag"),
                        Valor = reader.GetString("valor_pag"),
                        Desconto = reader.GetDateTime("desconto_pag"),
                        Forma = reader.GetString("forma_pagamento_pag"),
                        Caixa = reader.GetString(""),
                        DiaInteiro = reader.GetBoolean("dia_inteiro_blo")

                        //"INSERT INTO comanda (id_pag, data_pag, valor_pag, desconto_pag, forma_pagamento_pag, id_caix_fk, id_serv_fk," + " id_orca_fk, id_cli_fk) " +
                        //           "VALUES (@Identificacao, @Data, @Valor, @Desconto, @Forma, @Caixa, @Servico, @Orcamento, @Cliente)";

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

        public Bloqueio? GetById(int id)
        {
            try
            {
                Bloqueio bloqueio = new Bloqueio();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM bloqueio WHERE id_blo = @id";
                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    bloqueio.Id = reader.GetInt32("id_blo");
                    bloqueio.Profissional = reader.GetInt32("profissional_blo");
                    bloqueio.DataInicio = reader.GetDateTime("data_inicio_blo");
                    bloqueio.HoraInicio = reader.GetString("hora_inicio_blo");
                    bloqueio.DataFinal = reader.GetDateTime("data_fim_blo");
                    bloqueio.HoraFinal = reader.GetString("hora_fim_blo");
                    bloqueio.Motivo = reader.GetString("motivo_bloqueio_blo");
                    bloqueio.DiaInteiro = reader.GetBoolean("dia_inteiro_blo");
                }

                return bloqueio;
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

        public void Update(Bloqueio bloqueio)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE bloqueio SET profissional_blo = @Profissional, data_inicio_blo = @DataInicio, " +
                                    "hora_inicio_blo = @HoraInicio, data_fim_blo = @DataFinal, hora_fim_blo = @HoraFinal, " +
                                    "motivo_bloqueio_blo = @Motivo, dia_inteiro_blo = @DiaInteiro " +
                                    "WHERE id_blo = @Id";

                query.Parameters.AddWithValue("@Profissional", bloqueio.Profissional);
                query.Parameters.AddWithValue("@DataInicio", bloqueio.DataInicio);
                query.Parameters.AddWithValue("@HoraInicio", bloqueio.HoraInicio);
                query.Parameters.AddWithValue("@DataFinal", bloqueio.DataFinal);
                query.Parameters.AddWithValue("@HoraFinal", bloqueio.HoraFinal);
                query.Parameters.AddWithValue("@Motivo", bloqueio.Motivo);
                query.Parameters.AddWithValue("@DiaInteiro", bloqueio.DiaInteiro);
                query.Parameters.AddWithValue("@Id", bloqueio.Id);

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
                query.CommandText = "DELETE FROM bloqueio WHERE id_blo = @Id";
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
