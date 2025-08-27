using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoWebApp.DAL
{
    public class PacienteDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DadosClinicaConnectionString"].ConnectionString;

        // CRUD - CREATE - Cadastro.aspx.cs
        public void InserirPaciente(string nome, decimal valor)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string query = "InserirPaciente";

                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Paciente", nome);
                        sqlCommand.Parameters.AddWithValue("@Valor", valor);

                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            } 
            catch (Exception ex)
            {
                // em um sistema real, registra-se o erro em algum lugar (log de erros)
                throw new Exception("Erro ao inserir paciente: " + ex.Message);
            }
        }

        // CRUD - READ - Dashboard.aspx.cs
        public DataTable ObterTodosPacientes()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string query = "ObterTodosPacientes";

                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlConnection.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                        adapter.Fill(dt);
                    }
                }
            } 
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter pacientes: " + ex.Message);
            }
            return dt;
        }

        // CRUD - UPDATE - Dashboard.aspx.cs
        public void AtualizarPaciente(int id, string nome, decimal valor)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string query = "AtualizarPaciente";

                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@ID", id);
                        sqlCommand.Parameters.AddWithValue("@Paciente", nome);
                        sqlCommand.Parameters.AddWithValue("@Valor", valor);

                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o paciente: " + ex.Message);
            }
        }

        // CRUD - DELETE - Dashboard.aspx.cs
        public void DeletarPaciente(int id)
        {
            try
            {
                // use a instrução using para garantir que a conexão seja fechada
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string query = "DeletarPaciente";

                    // use a instrução using para garantir que o comando seja descartado
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@ID", id);

                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar paciente: " + ex.Message);
            }
        }
    }
}