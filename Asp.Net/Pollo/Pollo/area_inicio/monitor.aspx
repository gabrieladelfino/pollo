<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Mestra.Master" AutoEventWireup="true" CodeBehind="monitor.aspx.cs" Inherits="Pollo.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../estilos/monitor.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="botao-add">
        <img class="img-botao-add" src="../imagens/area_inicial/add/add.png" />
    </div>
   
    <script type="text/javascript">
        var id = <% int idc = idChocadeira.Count(); %>
        alert(id);

        var nome = <% int nomec = nomeChocadeira.Count; %>
        alert(nome);
    </script>

</asp:Content>
