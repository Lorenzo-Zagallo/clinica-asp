using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoWebApp.DAL;

namespace ProjetoWebApp
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                PacienteDAL pacienteDAL = new PacienteDAL();
                pacienteDAL.InserirPaciente(txtNome.Text, decimal.Parse(txtValor.Text));

                // lblMensagem.Text = "Novo paciente salvo com sucesso!";
                Response.Redirect("~/Dashboard.aspx");
            }
        }
    }
}