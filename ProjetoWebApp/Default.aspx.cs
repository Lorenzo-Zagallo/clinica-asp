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
            // A propriedade IsPostBack é verdadeira apenas se a página está sendo recarregada
            // após um evento do usuário (como um clique em um botão).
            // Se for o primeiro carregamento da página, IsPostBack é falso.
            if (!IsPostBack)
            {
                // Coloque aqui o código que deve ser executado apenas no primeiro carregamento.
                // Por exemplo, carregar dados do banco de dados para um GridView.

                // oculta o gridView na primeira vez que a página é carregada
                gdvDados.Visible = false;

                // carrega os dados na Session
                ObterDados();
            }
        }

        // método para criar dados simulados na tabela - ele retorna dados prontos no DataTable (sem tratamento de exceção)
        private DataTable CriarDadosSimulados()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Paciente", typeof(string));
            dt.Columns.Add("Valor", typeof(decimal));

            dt.Rows.Add(1, "Ana Silva", 150.00);
            dt.Rows.Add(2, "João Pereira", 200.50);
            dt.Rows.Add(3, "Maria Souza", 180.75);

            return dt;
        }


        // método para carregar ou criar os dados na Session - retorna os dados na tabela do DataTable
        private DataTable ObterDados()
        {
            // cria uma session para o DataTable
            DataTable dt = Session["DadosPacientes"] as DataTable;

            // verifica se a tabela é nula OU se ela não contém nenhuma linha
            if (dt == null || dt.Rows.Count == 0)
            {
                // se não estiver nula nem vazia, cria a tabela e a armazena na Session
                dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Paciente", typeof(string));
                dt.Columns.Add("Valor", typeof(decimal));

                // adiciona alguns dados iniciais
                dt.Rows.Add(1, "Ana Silva", 150.00);
                dt.Rows.Add(2, "João Pereira", 200.50);
                dt.Rows.Add(3, "Maria Souza", 180.75);

                // armazena o DataTable na Session criada
                Session["DadosPacientes"] = dt;
            }

            // retorna a tabela armazenada na Session
            return (DataTable)Session["DadosPacientes"];
        }

        // CRUD - CREATE
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // simulação: adicionando um novo paciente à tabela
                DataTable dados = ObterDados(); // (Opcional: você pode criar uma tabela global na classe para não perder os dados)

                // adiciona a nova linha DataRow novaLinha = dados.NewRow();
                DataRow novaLinha = dados.NewRow();
                novaLinha["ID"] = dados.Rows.Count + 1; // ID simples
                novaLinha["Paciente"] = txtNome.Text;
                novaLinha["Valor"] = decimal.Parse(txtValor.Text);
                dados.Rows.Add(novaLinha);

                // define a tabela como visível e vincula a tabela atualizada ao gridView
                gdvDados.Visible = true;
                gdvDados.DataSource = ObterDados(); // recarrega os dados do banco
                gdvDados.DataBind();
                lblMensagem.Text = "Novo paciente salvo com sucesso!";
            }
        }

        // CRUD - READ
        protected void btnCarregarDados_Click(object sender, EventArgs e)
        {
            // pega a tabela de dados simulados
            DataTable dados = ObterDados();

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

            // obtém os dados da linha que está sendo atualizada
            GridViewRow row = gdvDados.Rows[e.RowIndex];

            // pega os novos valores dos controles de edição
            // string novoPaciente = ((TextBox)row.FindControl("txtPaciente")).Text;
            // decimal novoValor = Convert.ToDecimal(((TextBox)row.FindControl("txtValor")).Text);

            // encontra os controls de edição (TextBox) na linha
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

            // obtém a tabela de dados da Session
            DataTable dados = ObterDados();

            // DataTable dados = CarregarDadosDoBanco();

            // encontra a linha na sua tabela de dados na Session
            DataRow linhaParaAtualizar = dados.AsEnumerable().FirstOrDefault(r => r.Field<int>("ID") == id);

            if (linhaParaAtualizar["Paciente"] != null)
            {
                // atualiza os valores da linha Paciente
                linhaParaAtualizar["Paciente"] = novoNome;
            }
            if (linhaParaAtualizar["Valor"] != null)
            {
                // atualiza os valores da linha Valor
                linhaParaAtualizar["Valor"] = novoValor;
            }

            // sai do modo de edição
            gdvDados.EditIndex = -1;

            // rebind para exibir os dados atualizados -- atualiza o gridview para exibir os dados salvos
            gdvDados.DataSource = dados;
            gdvDados.DataBind();

            lblMensagem.Text = "Registro atualizado com sucesso!";
        }

        // CRUD - DELETE
        // 2. evento para deletar a linha
        protected void gdvDados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // simulação antiga: remove a linha da tabela de dados
            // DataTable dados = CriarDadosSimulados(); // (Lembre-se: em um sistema real, você faria isso no banco de dados)

            // o que faz agora: obtem os dados na Session
            DataTable dados = ObterDados(); // (Lembre-se: em um sistema real, você faria isso no banco de dados)

            // remove a linha pelo seu índice na tabela
            dados.Rows.RemoveAt(e.RowIndex);

            // vincula a tabela atualizada ao gridview
            gdvDados.DataSource = dados;
            gdvDados.DataBind();

            lblMensagem.Text = "Registro removido com sucesso!";
        }

        // 3. evento para entrar no modo de edição da linha
        protected void gdvDados_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // define o índice na linha que está sendo editada
            gdvDados.EditIndex = e.NewEditIndex;

            // atualiza o gridvew para refletir o modo de edição
            DataTable dados = ObterDados();
            gdvDados.DataSource = dados;
            gdvDados.DataBind();
        }

        // 4. evento para cancelar a edição da linha
        protected void gdvDados_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // sai do modo de edição
            gdvDados.EditIndex = -1;

            // reverte a exibição do GridView
            DataTable dados = ObterDados();
            gdvDados.DataSource = dados;
            gdvDados.DataBind();
        }
    }
}
