<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Mestra.Master" AutoEventWireup="true" CodeBehind="monitor.aspx.cs" Inherits="Pollo.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../estilos/monitor.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="botao-add">
        <img class="img-botao-add" src="../imagens/area_inicial/add/add.png" />
    </div>
    
    <div class="monitor" onmouseover="mostrar(this)" onmouseout="esconder(this)">
        <asp:Label class="titulos_monitor" ID="lblNomeChocadeira" Text="" runat="server" />
        <asp:Label class="titulos_monitor_temp" ID="lblTemp" Text="" runat="server" />
        <asp:Label class="titulos_monitor" ID="lblDiasRestantes" Text="" runat="server" />
    </div>

    <%  double temperatura = Convert.ToDouble(lblTemp.Text);
        if (temperatura > 25) {
            %>
            <style>
                titulos_monitor_temp {
                    background: -webkit-linear-gradient(top, #FA1905, #F99201);
                    background: linear-gradient(top, #878787, #000);
                    -webkit-background-clip: text;
                    -webkit-text-fill-color: transparent;
                }
            </style>
        <%}
            else{%>
                <style>
                titulos_monitor_temp {
                    background: #fc0093;
                    background: -webkit-linear-gradient(top, #C71585, #00BFFF);
                    background: linear-gradient(top, #878787, #000);
                    -webkit-background-clip: text;
                    -webkit-text-fill-color: transparent;
                }
                </style>
            <%}%>
</asp:Content>
