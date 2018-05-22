<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Mestra.Master" AutoEventWireup="true" CodeBehind="analytics.aspx.cs" Inherits="Pollo.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="../estilos/analytics.css" type="text/css" />
     <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="comp">
        <asp:Label Text="Chocadeira: " runat="server" class="lbl"/>
        <asp:Label Text="Data conexão: " runat="server" class="lbl"/>
        <asp:Label Text="Dia(s) restantes: " runat="server" class="lbl"/>
    </div>
   
    <div class="comp" id="parametro">
        <label id="param">Parâmetro</label>
        <asp:DropDownList runat="server" ID="ddlParametro" class="ddl">
            <asp:ListItem Text="" />
            <asp:ListItem Text="Minuto" />
            <asp:ListItem Text="Hora" />
            <asp:ListItem Text="Dia" />
            <asp:ListItem Text="Mês" />
        </asp:DropDownList> 
    </div>

    <div id="chart_div" style="width: 60%; height: 450px;"></div>
    
    <script type="text/javascript">
        var dados = [
            ['Minuto', 'Temperatura'],
            <% for (int i = 0; i < Temperaturas.Count; i++) { %>
                    [ <%=Minutos[i] %>, <%=Temperaturas[i].ToString(System.Globalization.CultureInfo.InvariantCulture) %> ],
            <%} %>
            ];
    </script>

    <script type="text/javascript" src="../js/grafico.js"></script>
</asp:Content>

