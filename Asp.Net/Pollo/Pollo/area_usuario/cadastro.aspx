<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Mestra.Master" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="Pollo.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../estilos/cadastro.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label Text="Nome Completo:" runat="server" />
    <asp:TextBox runat="server" ID="txtNome" class="txt"/>
    <br />
    <asp:Button Text="Prosseguir" runat="server" ID="btnProseguir" class="btn" OnClick="btnProsseguir_Click" />
    <br />
    <asp:Label Text="Label" runat="server" ID="Label1" class="lbl"/>
</asp:Content>
