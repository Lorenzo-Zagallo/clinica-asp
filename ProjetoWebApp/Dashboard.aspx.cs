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
using ProjetoWebApp.DAL;

namespace ProjetoWebApp
{
    public partial class _Default : System.Web.UI.Page
    {
        PacienteDAL pacienteDAL = new PacienteDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            // a propriedade IsPostBack é verdadeira apenas se a página está sendo recarregada
            // após um evento do usuário (como um clique em um botão).
            // se for o primeiro carregamento da página, IsPostBack é falso.
            if (!IsPostBack)
            {
                // se a página for carregada pela primeira vez (ou após um redirect)
                gdvDados.DataSource = pacienteDAL.ObterTodosPacientes();
                gdvDados.DataBind();
                gdvDados.Visible = true;
            }
        }

        protected void btnCarregarDados_Click(object sender, EventArgs e)
        {
            DataTable dados = pacienteDAL.ObterTodosPacientes();

            // conecta a tabela ao GridView e vincula o DataSource ao controle GridView
            gdvDados.DataSource = dados;
            gdvDados.DataBind();

            gdvDados.Visible = true;
            lblMensagem.Text = "Dados carregados com sucesso!";
        }

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

            pacienteDAL.AtualizarPaciente(id, novoNome, novoValor);

            // sai do modo de edição
            gdvDados.EditIndex = -1;

            // recarrega os dados do banco para atualizar o GridView com as mudanças
            gdvDados.DataSource = pacienteDAL.ObterTodosPacientes();
            gdvDados.DataBind();

            lblMensagem.Text = "Registro atualizado com sucesso!";
        }

        protected void gdvDados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // obtém o ID da linha a partir da coleção DataKeys do GridView
            int id = Convert.ToInt32(gdvDados.DataKeys[e.RowIndex].Value);

            pacienteDAL.DeletarPaciente(id);

            // recarrega os dados do banco para atualizar no GridView
            gdvDados.DataSource = pacienteDAL.ObterTodosPacientes();
            gdvDados.DataBind();

            lblMensagem.Text = "Registro removido com sucesso!";
        }

        // 3. evento para entrar no modo de edição da linha
        protected void gdvDados_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // define o índice na linha que está sendo editada
            gdvDados.EditIndex = e.NewEditIndex;

            // atualiza o gridvew para refletir o modo de edição
            DataTable dados = pacienteDAL.ObterTodosPacientes();
            gdvDados.DataSource = dados;
            gdvDados.DataBind();
        }

        // 4. evento para cancelar a edição da linha
        protected void gdvDados_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // sai do modo de edição
            gdvDados.EditIndex = -1;

            // reverte a exibição do GridView
            DataTable dados = pacienteDAL.ObterTodosPacientes();
            gdvDados.DataSource = dados;
            gdvDados.DataBind();
        }
    }
}
