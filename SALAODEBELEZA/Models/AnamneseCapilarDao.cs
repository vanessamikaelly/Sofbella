using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;
using SALAODEBELEZA.Models;
using SOFBELLASALAOOO.Models;
using System;
using System.Collections.Generic;

namespace SALAODEBELEZA.Models
{
    public class AnamneseCapilarDao
    {
        private static ConnectionMysql conn;

        public AnamneseCapilarDao()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(AnamneseCapilar anamnese)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO anamnese (id_anamcap, tipo_cabelo_anamcap, caracteristica_anamcap, " +
                                    "comprimento_anamcap, pigmentacao_anamcap, elasticidade_anamcap ," +
                                    "expessura_anamcap, volume_anamcap, resistencia_anamcap, condicao_anamcap, observacoes_anamcap," +
                                    "atendentes_alergicos_anamcap)"+
                                    "VALUES (@TipoCabelo, @Caracteristica, @Comprimento, @Pigmentacao, @Elasticidade, @Espessura"
                                    + "@Volume, @Condicao, @Observacoes, @Antecedentes, @Resistencia)";

                query.Parameters.AddWithValue("@TipoCabelo", anamnese.TipoCabelo);
                query.Parameters.AddWithValue("@Caracteristica", anamnese.Caracteristica);
                query.Parameters.AddWithValue("@Comprimento", anamnese.Comprimento);
                query.Parameters.AddWithValue("@Pigmentacao", anamnese.Pigmentacao);
                query.Parameters.AddWithValue("@Elasticidade", anamnese.Elasticidade);
                query.Parameters.AddWithValue("@Espessura", anamnese.Espessura);
                query.Parameters.AddWithValue("@Volume", anamnese.Volume);
                query.Parameters.AddWithValue("@Condicao", anamnese.Condicao);
                query.Parameters.AddWithValue("@Observacoes", anamnese.Observacoes);
                query.Parameters.AddWithValue("@Antecedentes", anamnese.AntecedentesAlerg);
                query.Parameters.AddWithValue("@Resistencia", anamnese.Resistencia);


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

        public List<AnamneseCapilar> List()
        {
            List<AnamneseCapilar> lista = new List<AnamneseCapilar>();

            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM anamnese";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new AnamneseCapilar
                    {
                        Id = reader.GetInt32("id_caix"),
                        TipoCabelo = reader.GetBoolean("tipo_cabelo_anamcap"),
                        Caracteristica = reader.GetString("caracteristica_anamcap"),
                        Comprimento = reader.GetString("comprimento_anamcap"),
                        Pigmentacao = reader.GetString("pigmentacao_anamcap"),
                        Elasticidade = reader.GetString("elasticidade_anamcap"),
                        Espessura = reader.GetString("expessura_anamcap"),
                        Volume = reader.GetString("volume_anamcap"),
                        Condicao = reader.GetString("condicao_anamcap"),
                        Observacoes = reader.GetString("observacoes_anamcap"),
                        AntecedentesAlerg = reader.GetString("atendentes_alergicos_anamcap"),
                        Resistencia = reader.GetString("resistencia_anamcap")

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

        public AnamneseCapilar GetById(int id)
        {
            try
            {
                AnamneseCapilar anamnese = null;

                var query = conn.Query();
                query.CommandText = "SELECT * FROM anamnese WHERE id_anamcap = @id";
                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        anamnese = new AnamneseCapilar
                        {
                            Id = reader.GetInt32("id_anamcap"),
                            TipoCabelo = reader.GetBoolean("tipo_cabelo_anamcap"),
                            Caracteristica = reader.GetString("caracteristica_anamcap"),
                            Comprimento = reader.GetString("comprimento_anamcap"),
                            Pigmentacao = reader.GetString("pigmentacao_anamcap"),
                            Elasticidade = reader.GetString("elasticidade_anamcap"),
                            Espessura = reader.GetString("expessura_anamcap"),
                            Volume = reader.GetString("volume_anamcap"),
                            Condicao = reader.GetString("condicao_anamcap"),
                            Observacoes = reader.GetString("observacoes_anamcap"),
                            AntecedentesAlerg = reader.GetString("atendentes_alergicos_anamcap"),
                            Resistencia = reader.GetString("resistencia_anamcap")

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

        public void Update(AnamneseCapilar anamnese)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE anamnese SET tipo_cabelo_anamcap = @TipoCabelo, caracteristica_anamcap = @Caracteristica, " +
                                    "comprimento_anamcap = @Comprimento, pigmentacao_anamcap = @Pigmentacao, " +
                                    "elasticidade_anamcap = @Elasticidade, expessura_anamcap = @Espessura" +
                                    "volume_anamcap = @Volume, resistencia_anamcap = @Resistencia" +
                                    "condicao_anamcap = @Condicao, observacoes_anamcap = @Observacoes, atendentes_alergicos_anamcap = @Antecedentes" +



                query.Parameters.AddWithValue("@TipoCabelo", anamnese.TipoCabelo);
                query.Parameters.AddWithValue("@Caracteristica", anamnese.Caracteristica);
                query.Parameters.AddWithValue("@Comprimento", anamnese.Comprimento);
                query.Parameters.AddWithValue("@Pigmentacao", anamnese.Pigmentacao);
                query.Parameters.AddWithValue("@Elasticidade", anamnese.Elasticidade);
                query.Parameters.AddWithValue("@Espessura", anamnese.Espessura);
                query.Parameters.AddWithValue("@Volume", anamnese.Volume);
                query.Parameters.AddWithValue("@Condicao", anamnese.Condicao);
                query.Parameters.AddWithValue("@Observacoes", anamnese.Observacoes);
                query.Parameters.AddWithValue("@Antecedentes", anamnese.AntecedentesAlerg);
                query.Parameters.AddWithValue("@Resistencia", anamnese.Resistencia);

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
                query.CommandText = "DELETE FROM anamnese WHERE id_anamcap = @Id";
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
