using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;
using SALAODEBELEZA.Models;
using System;
using System.Collections.Generic;

namespace SALAODEBELEZA.Models
{
    public class AnamneseFacialDAO
    {
        private static ConnectionMysql conn;

        public AnamneseFacialDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(AnamneseFacial anamnese)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO anamnese_facial (gestante_anamfac, quedadecabelo_anamfac, alergia_anamfac, medicacao_anamfac, tipo_pele_anamfac) " +
                                    "VALUES (@Gestante, @QuedaCabelo, @Alergia, @Medicacao, @TipoPele)";

                query.Parameters.AddWithValue("@Gestante", anamnese.Gestante);
                query.Parameters.AddWithValue("@QuedaCabelo", anamnese.Queda_Cabelo);
                query.Parameters.AddWithValue("@Alergia", anamnese.Alergia);
                query.Parameters.AddWithValue("@Medicacao", anamnese.Medicacao);
                query.Parameters.AddWithValue("@TipoPele", anamnese.TipodePele);

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

        public List<AnamneseFacial> List()
        {
            List<AnamneseFacial> lista = new List<AnamneseFacial>();

            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM anamnese_facial";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new AnamneseFacial
                    {
                        Id = reader.GetInt32("id_anamfac"),
                        Gestante = reader.GetBoolean("gestante_anamfac"),
                        Queda_Cabelo = reader.GetBoolean("quedadecabelo_anamfac"),
                        Alergia = reader.GetBoolean("alergia_anamfac"),
                        Medicacao = reader.GetBoolean("medicacao_anamfac"),
                        TipodePele = reader.GetString("tipo_pele_anamfac")
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

        public AnamneseFacial GetById(int id)
        {
            try
            {
                AnamneseFacial anamnese = new AnamneseFacial();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM anamnese_facial WHERE id_anamfac = @id";
                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    anamnese.Id = reader.GetInt32("id_anamfac");
                    anamnese.Gestante = reader.GetBoolean("gestante_anamfac");
                    anamnese.Queda_Cabelo = reader.GetBoolean("quedadecabelo_anamfac");
                    anamnese.Alergia = reader.GetBoolean("alergia_anamfac");
                    anamnese.Medicacao = reader.GetBoolean("medicacao_anamfac");
                    anamnese.TipodePele = reader.GetString("tipo_pele_anamfac");
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


        public void Update(AnamneseFacial anamnese)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE anamnese_facial SET gestante_anamfac = @Gestante, quedadecabelo_anamfac = @QuedaCabelo, " +
                                    "alergia_anamfac = @Alergia, medicacao_anamfac = @Medicacao, tipo_pele_anamfac = @TipoPele " +
                                    "WHERE id_anamfac = @Id";

                query.Parameters.AddWithValue("@Gestante", anamnese.Gestante);
                query.Parameters.AddWithValue("@QuedaCabelo", anamnese.Queda_Cabelo);
                query.Parameters.AddWithValue("@Alergia", anamnese.Alergia);
                query.Parameters.AddWithValue("@Medicacao", anamnese.Medicacao);
                query.Parameters.AddWithValue("@TipoPele", anamnese.TipodePele);
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
                query.CommandText = "DELETE FROM anamnese_facial WHERE id_anamfac = @Id";
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
