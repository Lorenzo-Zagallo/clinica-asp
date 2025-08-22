<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="ProjetoWebApp.Cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
    <asp:Panel ID="pnlCadastro" runat="server" Height="60px">
        <asp:Label ID="lblNome" runat="server" Text="Nome:"></asp:Label>
        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNome0" runat="server" ControlToValidate="txtNome" ErrorMessage="O nome é obrigatório." ValidationGroup="CadastroGroup"></asp:RequiredFieldValidator>

        <asp:Label ID="lblValor" runat="server" Text="Valor:"></asp:Label>
        <asp:TextBox ID="txtValor" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvValor" runat="server" ControlToValidate="txtValor" ErrorMessage="O valor é obrigatório." ValidationGroup="CadastroGroup"></asp:RequiredFieldValidator>
    </asp:Panel>

    <asp:Button ID="btnSalvar" runat="server" Text="Salvar Paciente" OnClick="btnSalvar_Click" ValidationGroup="CadastroGroup"/>
</asp:Content>
