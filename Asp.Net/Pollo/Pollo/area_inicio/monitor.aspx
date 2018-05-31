<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Mestra.Master" AutoEventWireup="true" CodeBehind="monitor.aspx.cs" Inherits="Pollo.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../estilos/monitor.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="monitores" runat="server">
        <div class="botao-add">
            <img class="img-botao-add" src="../imagens/area_inicial/add/add.png" />
        </div>
    </div>
</asp:Content>
