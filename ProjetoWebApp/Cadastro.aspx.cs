using System;
using System.Collections.Generic;
using System.Configuration;
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
                string query = "INSERT INTO [Pacientes] (Paciente, Valor) VALUES (@Paciente, @Valor)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Paciente", txtNome.Text);
                        cmd.Parameters.AddWithValue("@Valor", decimal.Parse(txtValor.Text));
                        conn.Open();
                        cmd.ExecuteNonQuery();
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