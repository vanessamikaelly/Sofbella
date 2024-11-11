using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;
using SALAODEBELEZA.Models;
using System;
using System.Collections.Generic;

namespace SALAODEBELEZA.Models
{
    public class CaixaDao
    {       
            private static ConnectionMysql conn;

            public CaixaDao()
            {
                conn = new ConnectionMysql();
            }

            public int Insert(Caixa caixa)
            {
                try
                {
                    var query = conn.Query();
                    query.CommandText = "INSERT INTO caixa (usuario_caix, data_inicio_caix, valor_inicial_caix, " +
                                        "entrada_caix, saida_caix, saldo_final_caix)" +
                                        "VALUES (@Usuario, @DataInic, @ValorInic, @Entrada, @Saida, @SaldoFinal)";

                    query.Parameters.AddWithValue("@Usuario", caixa.UsuarioCaixa);
                    query.Parameters.AddWithValue("@DataInic", caixa.DataInicio.ToString("yyyy-MM-dd HH:mm:ss"));
                    query.Parameters.AddWithValue("@ValorInic", caixa.ValorInicial);
                    query.Parameters.AddWithValue("@Entrada", caixa.EntradaCaixa);
                    query.Parameters.AddWithValue("@Saida", caixa.SaidaCaixa);
                    query.Parameters.AddWithValue("@SaldoFinal", caixa.SaldoFinal);
                   

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

            public List<Caixa> List()
            {
                List<Caixa> lista = new List<Caixa>();

                try
                {
                    var query = conn.Query();
                    query.CommandText = "SELECT * FROM caixa";

                    MySqlDataReader reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new Caixa
                        {
                            Id = reader.GetInt32("id_caix"),
                            UsuarioCaixa = reader.GetString("usuario_caix"),
                            DataInicio = reader.GetDateTime("data_inicio_caix"),
                            ValorInicial = reader.GetDouble("valor_inicial_caix"),
                            EntradaCaixa = reader.GetDouble("entrada_caix"),
                            SaidaCaixa = reader.GetDouble("saida_caix"),
                            SaldoFinal = reader.GetDouble("saldo_final_caix")
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

            public Caixa GetById(int id)
            {
                try
                {
                    Caixa caixa = null;

                    var query = conn.Query();
                    query.CommandText = "SELECT * FROM caixa WHERE id_caix = @id";
                    query.Parameters.AddWithValue("@id", id);

                    MySqlDataReader reader = query.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            caixa = new Caixa
                            {
                                Id = reader.GetInt32("id_caix"),
                                UsuarioCaixa = reader.GetString("usuario_caix"),
                                DataInicio = reader.GetDateTime("data_inicio_caix"),
                                ValorInicial = reader.GetDouble("valor_inicial_caix"),
                                EntradaCaixa = reader.GetDouble("entrada_caix"),
                                SaidaCaixa = reader.GetDouble("saida_caix"),
                                SaldoFinal = reader.GetDouble("saldo_final_caix")

                            };
                        }
                    }

                    return caixa;
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

            public void Update(Caixa caixa)
            {
                try
                {
                    var query = conn.Query();
                    query.CommandText = "UPDATE caixa SET usuario_caix = @Usuario, data_inicio_caix = @DataInic, " +
                                        "valor_inicial_caix = @ValorInic, entrada_caix = @Entrada, " +
                                        "saida_caix = @Saida, saldo_final_caix = @SaldoFinal";


                    query.Parameters.AddWithValue("@Usuario", caixa.UsuarioCaixa);
                    query.Parameters.AddWithValue("@DataInic", caixa.DataInicio.ToString("yyyy-MM-dd HH:mm:ss"));
                    query.Parameters.AddWithValue("@ValorInic", caixa.ValorInicial);
                    query.Parameters.AddWithValue("@Entrada", caixa.EntradaCaixa);
                    query.Parameters.AddWithValue("@Saida", caixa.SaidaCaixa);
                    query.Parameters.AddWithValue("@SaldoFinal", caixa.SaldoFinal);

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
                    query.CommandText = "DELETE FROM caixa WHERE id_caix = @Id";
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
