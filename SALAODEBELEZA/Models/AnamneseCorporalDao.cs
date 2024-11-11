using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;
using SALAODEBELEZA.Models;
using System;
using System.Collections.Generic;

namespace SALAODEBELEZA.Models
{
    public class AnamneseCorporalDAO
    {
        private static ConnectionMysql conn;

        public AnamneseCorporalDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(AnamneseCorporal anamnese)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO anamnese_corporal (depilacao_anamcorp, alergia_anamcorp, tipo_alergia_anamcorp, " +
                                    "problema_pele_anamcorp, tratamento_dermatologico_anamcorp, gestante_anamcorp, tipo_pele_anamcorp, " +
                                    "vasos_varicosos_anamcorp, metodos_utilizados_anamcorp, areas_anamcorp) " +
                                    "VALUES (@Depilacao, @Alergia, @TipoAlergia, @ProblemaPele, @TratamentoDermatologico, @Gestante, " +
                                    "@TipoPele, @VasosVarizes, @MetodosUtilizados, @Areas)";

                query.Parameters.AddWithValue("@Depilacao", anamnese.Depilacao);
                query.Parameters.AddWithValue("@Alergia", anamnese.Alergia);
                query.Parameters.AddWithValue("@TipoAlergia", anamnese.TipoAlergia);
                query.Parameters.AddWithValue("@ProblemaPele", anamnese.ProblemaPele);
                query.Parameters.AddWithValue("@TratamentoDermatologico", anamnese.TratamentoDermatologico);
                query.Parameters.AddWithValue("@Gestante", anamnese.Gestante);
                query.Parameters.AddWithValue("@TipoPele", anamnese.TipoPele);
                query.Parameters.AddWithValue("@VasosVarizes", anamnese.VasosVarizes);
                query.Parameters.AddWithValue("@MetodosUtilizados", anamnese.MetodosUtilizados);
                query.Parameters.AddWithValue("@Areas", anamnese.Areas);

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

        public List<AnamneseCorporal> List()
        {
            List<AnamneseCorporal> lista = new List<AnamneseCorporal>();

            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM anamnese_corporal";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new AnamneseCorporal
                    {
                        Id = reader.GetInt32("id_anamcorp"),
                        Depilacao = reader.GetBoolean("depilacao_anamcorp"),
                        Alergia = reader.GetBoolean("alergia_anamcorp"),
                        TipoAlergia = reader.GetString("tipo_alergia_anamcorp"),
                        ProblemaPele = reader.GetBoolean("problema_pele_anamcorp"),
                        TratamentoDermatologico = reader.GetBoolean("tratamento_dermatologico_anamcorp"),
                        Gestante = reader.GetBoolean("gestante_anamcorp"),
                        TipoPele = reader.GetString("tipo_pele_anamcorp"),
                        VasosVarizes = reader.GetBoolean("vasos_varicosos_anamcorp"),
                        MetodosUtilizados = reader.GetString("metodos_utilizados_anamcorp"),
                        Areas = reader.GetString("areas_anamcorp")
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

        public AnamneseCorporal GetById(int id)
        {
            try
            {
                AnamneseCorporal anamnese = null;

                var query = conn.Query();
                query.CommandText = "SELECT * FROM anamnese_corporal WHERE id_anamcorp = @id";
                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        anamnese = new AnamneseCorporal
                        {
                            Id = reader.GetInt32("id_anamcorp"),
                            Depilacao = reader.GetBoolean("depilacao_anamcorp"),
                            Alergia = reader.GetBoolean("alergia_anamcorp"),
                            TipoAlergia = reader.GetString("tipo_alergia_anamcorp"),
                            ProblemaPele = reader.GetBoolean("problema_pele_anamcorp"),
                            TratamentoDermatologico = reader.GetBoolean("tratamento_dermatologico_anamcorp"),
                            Gestante = reader.GetBoolean("gestante_anamcorp"),
                            TipoPele = reader.GetString("tipo_pele_anamcorp"),
                            VasosVarizes = reader.GetBoolean("vasos_varicosos_anamcorp"),
                            MetodosUtilizados = reader.GetString("metodos_utilizados_anamcorp"),
                            Areas = reader.GetString("areas_anamcorp")
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

        public void Update(AnamneseCorporal anamnese)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE anamnese_corporal SET depilacao_anamcorp = @Depilacao, alergia_anamcorp = @Alergia, " +
                                    "tipo_alergia_anamcorp = @TipoAlergia, problema_pele_anamcorp = @ProblemaPele, " +
                                    "tratamento_dermatologico_anamcorp = @TratamentoDermatologico, gestante_anamcorp = @Gestante, " +
                                    "tipo_pele_anamcorp = @TipoPele, vasos_varicosos_anamcorp = @VasosVarizes, metodos_utilizados_anamcorp = @MetodosUtilizados, " +
                                    "areas_anamcorp = @Areas WHERE id_anamcorp = @Id";

                query.Parameters.AddWithValue("@Depilacao", anamnese.Depilacao);
                query.Parameters.AddWithValue("@Alergia", anamnese.Alergia);
                query.Parameters.AddWithValue("@TipoAlergia", anamnese.TipoAlergia);
                query.Parameters.AddWithValue("@ProblemaPele", anamnese.ProblemaPele);
                query.Parameters.AddWithValue("@TratamentoDermatologico", anamnese.TratamentoDermatologico);
                query.Parameters.AddWithValue("@Gestante", anamnese.Gestante);
                query.Parameters.AddWithValue("@TipoPele", anamnese.TipoPele);
                query.Parameters.AddWithValue("@VasosVarizes", anamnese.VasosVarizes);
                query.Parameters.AddWithValue("@MetodosUtilizados", anamnese.MetodosUtilizados);
                query.Parameters.AddWithValue("@Areas", anamnese.Areas);
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
                query.CommandText = "DELETE FROM anamnese_corporal WHERE id_anamcorp = @Id";
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
