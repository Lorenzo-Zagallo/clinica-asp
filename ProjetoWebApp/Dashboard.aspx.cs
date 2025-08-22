using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ProjetoWebApp
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // a propriedade IsPostBack é verdadeira apenas se a página está sendo recarregada
            // após um evento do usuário (como um clique em um botão).
            // se for o primeiro carregamento da página, IsPostBack é falso.
            if (!IsPostBack)
            {
                // se a página for carregada pela primeira vez (ou após um redirect)
                gdvDados.DataSource = CarregarDadosDoBanco();
                gdvDados.DataBind();
                gdvDados.Visible = true;
            }
        }

        protected DataTable CarregarDadosDoBanco()
        {
            DataTable dt = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["DadosClinicaConnectionString"].ConnectionString;
            string query = "SELECT ID, Paciente, Valor FROM [Pacientes]";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlConnection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        // CRUD - READ
        protected void btnCarregarDados_Click(object sender, EventArgs e)
        {
            // pega a tabela de dados simulados
            DataTable dados = CarregarDadosDoBanco();

            // conecta a tabela ao GridView
            gdvDados.DataSource = dados;

            // vincula o DataSource ao controle GridView
            gdvDados.DataBind();

            // torna o gridView visível
            gdvDados.Visible = true;

            // exibe uma mensagem
            lblMensagem.Text = "Dados carregados com sucesso!";
        }

        // CRUD - UPDATE
        // 1. evento para salvar a edição da linha
        protected void gdvDados_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // obtém o ID da linha que está sendo atualizada a partir do DataKeys
            int id = Convert.ToInt32(gdvDados.DataKeys[e.RowIndex].Value);

            // obtém os dados da linha que está sendo editada no GridView
            GridViewRow row = gdvDados.Rows[e.RowIndex];

            // encontra os TextBoxes dentro das células da linha em edição
            // as células são numeradas a partir de 0. 
            // supondo que Paciente é a 2ª coluna e Valor é a 3ª (depois do Editar e Deletar)
            string novoNome = ((TextBox)row.Cells[2].Controls[0]).Text;
            string novoValorTexto = ((TextBox)row.Cells[3].Controls[0]).Text;

            // verifica se o valor é válido antes de converter
            decimal novoValor;
            if (!decimal.TryParse(novoValorTexto, out novoValor))
            {
                lblMensagem.Text = "O valor inserido é inválido. Tente novamente.";
                // não sai do modo de edição
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["DadosClinicaConnectionString"].ConnectionString;
            string query = "UPDATE [Pacientes] SET Paciente = @Paciente, Valor = @Valor WHERE ID = @ID";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    // adiciona os parâmetros com os valores dos TextBoxes da linha em edição
                    sqlCommand.Parameters.AddWithValue("@ID", id);
                    sqlCommand.Parameters.AddWithValue("@Paciente", novoNome);
                    sqlCommand.Parameters.AddWithValue("Valor", novoValor);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }

            // sai do modo de edição
            gdvDados.EditIndex = -1;

            // recarrega os dados do banco para atualizar o GridView com as mudanças
            gdvDados.DataSource = CarregarDadosDoBanco();
            gdvDados.DataBind();

            lblMensagem.Text = "Registro atualizado com sucesso!";
        }

        // CRUD - DELETE
        // 2. evento para deletar a linha
        protected void gdvDados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // obtém o ID da linha a partir da coleção DataKeys do GridView
            int id = Convert.ToInt32(gdvDados.DataKeys[e.RowIndex].Value);

            string connectionString = ConfigurationManager.ConnectionStrings["DadosClinicaConnectionString"].ConnectionString;

            // use a instrução using para garantir que a conexão seja fechada
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                // use a instrução using para garantir que o comando seja descartado
                string query = "DELETE FROM [Pacientes] WHERE ID = @ID";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    // adicione o parâmetro de forma correta
                    sqlCommand.Parameters.AddWithValue("@ID", id);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery(); // executa o comando DELETE
                }
            }

            // recarrega os dados do banco para atualizar no GridView
            gdvDados.DataSource = CarregarDadosDoBanco();
            gdvDados.DataBind();

            lblMensagem.Text = "Registro removido com sucesso!";
        }

        // 3. evento para entrar no modo de edição da linha
        protected void gdvDados_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // define o índice na linha que está sendo editada
            gdvDados.EditIndex = e.NewEditIndex;

            // atualiza o gridvew para refletir o modo de edição
            DataTable dados = CarregarDadosDoBanco();
            gdvDados.DataSource = dados;
            gdvDados.DataBind();
        }

        // 4. evento para cancelar a edição da linha
        protected void gdvDados_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // sai do modo de edição
            gdvDados.EditIndex = -1;

            // reverte a exibição do GridView
            DataTable dados = CarregarDadosDoBanco();
            gdvDados.DataSource = dados;
            gdvDados.DataBind();
        }
    }
}
