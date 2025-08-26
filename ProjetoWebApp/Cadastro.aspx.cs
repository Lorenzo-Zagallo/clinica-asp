using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoWebApp
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // CRUD - CREATE
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DadosClinicaConnectionString"].ConnectionString;

                //string query = "INSERT INTO [Pacientes] (Paciente, Valor) VALUES (@Paciente, @Valor)";
                string query = "InserirPaciente";

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        // adiciona os parâmetros
                        sqlCommand.Parameters.AddWithValue("@Paciente", txtNome.Text);
                        sqlCommand.Parameters.AddWithValue("@Valor", decimal.Parse(txtValor.Text));

                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                }

                // exibe uma mensagem de sucesso no mesmo método
                lblMensagem.Text = "Novo paciente salvo com sucesso!";

                // em seguida, redireciona o usuário de volta para o dashboard.
                // o Dashboard.aspx irá recarregar a GridView automaticamente.
                Response.Redirect("~/Dashboard.aspx");

                // define a tabela como visível e vincula a tabela atualizada ao gridView
                // gdvDados.Visible = true;
                // gdvDados.DataSource = CarregarDadosDoBanco(); // recarrega os dados do banco
                // gdvDados.DataBind();
                // lblMensagem.Text = "Novo paciente salvo com sucesso!";
            }
        }
    }
}