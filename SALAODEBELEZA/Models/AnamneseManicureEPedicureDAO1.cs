using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;
using SALAODEBELEZA.Models;
using System;
using System.Collections.Generic;

namespace SALAODEBELEZA.Models
{
    public class AnamneseManicureEPedicureDAO1
    {
        private static ConnectionMysql conn;

        public AnamneseManicureEPedicureDAO1()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(AnamneseManicureEPedicure anamnese)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO anamnese_manicure_pedicure (frequencia_anamncure, retiracuticula_anamncure, roeunhas_anamncure, " +
                                    "alergia_anamncure, tipoalergia_anamncure, formato_unha_anamncure, tonalidade_anamncure, unhaencravada_anamncure, " +
                                    "micose_anamncure, coresmalte_anamncure) " +
                                    "VALUES (@Frequencia, @RetiraCuticula, @RoeUnhas, @Alergia, @TipoAlergia, @FormatoPreferencia, @TonalidadePreferida, " +
                                    "@UnhaEncravada, @Micose, @CorEsmalte)";

                query.Parameters.AddWithValue("@Frequencia", anamnese.Frequenca);
                query.Parameters.AddWithValue("@RetiraCuticula", anamnese.RetiraCuticula);
                query.Parameters.AddWithValue("@RoeUnhas", anamnese.RoeUnhas);
                query.Parameters.AddWithValue("@Alergia", anamnese.Alergia);
                query.Parameters.AddWithValue("@TipoAlergia", anamnese.DescricaoAlergia);
                query.Parameters.AddWithValue("@FormatoPreferencia", anamnese.FormatoPreferencia);
                query.Parameters.AddWithValue("@TonalidadePreferida", anamnese.TonalidadePreferida);
                query.Parameters.AddWithValue("@UnhaEncravada", anamnese.UnhaEncravada);
                query.Parameters.AddWithValue("@Micose", anamnese.Micose);
                query.Parameters.AddWithValue("@CorEsmalte", anamnese.CorEsmalte);

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

        public List<AnamneseManicureEPedicure> List()
        {
            List<AnamneseManicureEPedicure> lista = new List<AnamneseManicureEPedicure>();

            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM anamnese_manicure_pedicure";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new AnamneseManicureEPedicure
                    {
                        Id = reader.GetInt32("id_anamncure"),
                        Frequenca = reader.GetString("frequencia_anamncure"),
                        RetiraCuticula = reader.GetBoolean("retiracuticula_anamncure"),
                        RoeUnhas = reader.GetBoolean("roeunhas_anamncure"),
                        Alergia = reader.GetBoolean("alergia_anamncure"),
                        DescricaoAlergia = reader.GetString("tipoalergia_anamncure"),
                        FormatoPreferencia = reader.GetString("formato_unha_anamncure"),
                        TonalidadePreferida = reader.GetBoolean("tonalidade_anamncure"),
                        UnhaEncravada = reader.GetBoolean("unhaencravada_anamncure"),
                        Micose = reader.GetBoolean("micose_anamncure"),
                        CorEsmalte = reader.GetString("coresmalte_anamncure")
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

        public AnamneseManicureEPedicure GetById(int id)
        {
            try
            {
                AnamneseManicureEPedicure anamnese = null;

                var query = conn.Query();
                query.CommandText = "SELECT * FROM anamnese_manicure_pedicure WHERE id_anamncure = @id";
                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        anamnese = new AnamneseManicureEPedicure
                        {
                            Id = reader.GetInt32("id_anamncure"),
                            Frequenca = reader.GetString("frequencia_anamncure"),
                            RetiraCuticula = reader.GetBoolean("retiracuticula_anamncure"),
                            RoeUnhas = reader.GetBoolean("roeunhas_anamncure"),
                            Alergia = reader.GetBoolean("alergia_anamncure"),
                            DescricaoAlergia = reader.GetString("tipoalergia_anamncure"),
                            FormatoPreferencia = reader.GetString("formato_unha_anamncure"),
                            TonalidadePreferida = reader.GetBoolean("tonalidade_anamncure"),
                            UnhaEncravada = reader.GetBoolean("unhaencravada_anamncure"),
                            Micose = reader.GetBoolean("micose_anamncure"),
                            CorEsmalte = reader.GetString("coresmalte_anamncure")
                        };
                    }
                }

                return anamnese;
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

        public void Update(AnamneseManicureEPedicure anamnese)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE anamnese_manicure_pedicure SET frequencia_anamncure = @Frequencia, retiracuticula_anamncure = @RetiraCuticula, " +
                                    "roeunhas_anamncure = @RoeUnhas, alergia_anamncure = @Alergia, tipoalergia_anamncure = @TipoAlergia, " +
                                    "formato_unha_anamncure = @FormatoPreferencia, tonalidade_anamncure = @TonalidadePreferida, " +
                                    "unhaencravada_anamncure = @UnhaEncravada, micose_anamncure = @Micose, coresmalte_anamncure = @CorEsmalte " +
                                    "WHERE id_anamncure = @Id";

                query.Parameters.AddWithValue("@Frequencia", anamnese.Frequenca);
                query.Parameters.AddWithValue("@RetiraCuticula", anamnese.RetiraCuticula);
                query.Parameters.AddWithValue("@RoeUnhas", anamnese.RoeUnhas);
                query.Parameters.AddWithValue("@Alergia", anamnese.Alergia);
                query.Parameters.AddWithValue("@TipoAlergia", anamnese.DescricaoAlergia);
                query.Parameters.AddWithValue("@FormatoPreferencia", anamnese.FormatoPreferencia);
                query.Parameters.AddWithValue("@TonalidadePreferida", anamnese.TonalidadePreferida);
                query.Parameters.AddWithValue("@UnhaEncravada", anamnese.UnhaEncravada);
                query.Parameters.AddWithValue("@Micose", anamnese.Micose);
                query.Parameters.AddWithValue("@CorEsmalte", anamnese.CorEsmalte);
                query.Parameters.AddWithValue("@Id", anamnese.Id);

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
                query.CommandText = "DELETE FROM anamnese_manicure_pedicure WHERE id_anamncure = @Id";
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
