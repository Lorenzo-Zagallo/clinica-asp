<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="ProjetoWebApp.Cadastro" %>
<%@ Register Src="~/UserControls/MenuSimples.ascx" TagName="MenuSimples" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:MenuSimples ID="MenuSimples1" runat="server" />
    
    <div class="card m-4">

        <div class="card-header bg-primary text-white">
            <h3>Novo Paciente</h3>
        </div>

        <div class="card-body">

            <div class="mb-3">
                <asp:Label ID="lblNome" runat="server" Text="Nome:" 
                    CssClass="form-label" />
                <asp:TextBox ID="txtNome" runat="server" 
                    CssClass="form-control" />

                <asp:RequiredFieldValidator ID="rfvNome0" runat="server" ControlToValidate="txtNome" ErrorMessage="O nome é obrigatório." ValidationGroup="CadastroGroup"
                    CssClass="text-danger" />
            </div>
            
            <div class="mb-3">
                <asp:Label ID="lblValor" runat="server" Text="Valor:" 
                    CssClass="form-label" />
                <asp:TextBox ID="txtValor" runat="server" 
                    CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvValor" runat="server" ControlToValidate="txtValor" ErrorMessage="O valor é obrigatório." ValidationGroup="CadastroGroup" 
                    CssClass="text-danger" />
            </div>
            
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar Paciente" OnClick="btnSalvar_Click" ValidationGroup="CadastroGroup" 
                CssClass="btn btn-primary"/>

            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                HeaderText="Por favor, corrija os seguintes erros:"
                ForeColor="Red"
                ValidationGroup="CadastroGroup" 
                class="alert alert-danger my-2" />
        </div>
    </div>

</asp:Content>
