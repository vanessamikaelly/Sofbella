using MySql.Data.MySqlClient;
using SALAODEBELEZA.DataBase;
using SALAODEBELEZA.Models;
using System;
using System.Collections.Generic;

namespace SALAODEBELEZA.Models
{
    public class PerfilDAO
    {
        private static ConnectionMysql conn;

        public PerfilDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Perfil perfil)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO perfil (tipo_perf, agenda_perf, comissoes_perf, financeiro_perf) " +
                                    "VALUES (@TipoPerfil, @Agenda, @Comissoes, @Financeiro)";

                query.Parameters.AddWithValue("@TipoPerfil", perfil.Tipo_perfil);
                query.Parameters.AddWithValue("@Agenda", perfil.Agenda);
                query.Parameters.AddWithValue("@Comissoes", perfil.Comissoes);
                query.Parameters.AddWithValue("@Financeiro", perfil.Financeiro);

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

        public List<Perfil> List()
        {
            List<Perfil> lista = new List<Perfil>();

            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM perfil";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Perfil
                    {
                        Id = reader.GetInt32("id_perf"),
                        Tipo_perfil = reader.GetString("tipo_perf"),
                        Agenda = reader.GetString("agenda_perf"),
                        Comissoes = reader.GetString("comissoes_perf"),
                        Financeiro = reader.GetString("financeiro_perf")
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

        public Perfil GetById(int id)
        {
            try
            {
                Perfil perfil = new Perfil();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM perfil WHERE id_perf = @id";
                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    perfil.Id = reader.GetInt32("id_perf");
                    perfil.Tipo_perfil = reader.GetString("tipo_perf");
                    perfil.Agenda = reader.GetString("agenda_perf");
                    perfil.Comissoes = reader.GetString("comissoes_perf");
                    perfil.Financeiro = reader.GetString("financeiro_perf");
                }

                return perfil;
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

        public void Update(Perfil perfil)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE perfil SET tipo_perf = @TipoPerfil, agenda_perf = @Agenda, " +
                                    "comissoes_perf = @Comissoes, financeiro_perf = @Financeiro " +
                                    "WHERE id_perf = @Id";

                query.Parameters.AddWithValue("@TipoPerfil", perfil.Tipo_perfil);
                query.Parameters.AddWithValue("@Agenda", perfil.Agenda);
                query.Parameters.AddWithValue("@Comissoes", perfil.Comissoes);
                query.Parameters.AddWithValue("@Financeiro", perfil.Financeiro);
                query.Parameters.AddWithValue("@Id", perfil.Id);

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
                query.CommandText = "DELETE FROM perfil WHERE id_perf = @Id";
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
