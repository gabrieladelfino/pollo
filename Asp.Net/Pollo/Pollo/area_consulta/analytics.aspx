<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Mestra.Master" AutoEventWireup="true" CodeBehind="analytics.aspx.cs" Inherits="Pollo.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="../estilos/analytics.css" type="text/css" />
     <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
     <script type="text/javascript" src="../js/grafico.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div id="chart_div"></div>
    
    <div class="medias">
        <div class="info">
            <asp:Button Text="< Max >" ID="btnMaxMin" class="lbl" OnClick="btnMaxMin_Click"  runat="server"/>
            <br />
            <asp:Label Text="" class="lblTemp" ID="lblMaxMin" runat="server" />
        </div>
        <div class="info">
            <asp:Button Text="< 1° Quartil >" ID="btnQuartil" class="lbl" OnClick="btnQuartil_Click" runat="server"/>
            <br />
            <asp:Label Text="" class="lblTemp" ID="lblQuartil" runat="server" />
        </div>
        <div class="info">
            <asp:Button Text="< Média >" ID="btnMedia" class="lbl" OnClick="btnMedia_Click" runat="server" />
            <br />
            <asp:Label Text="" class="lblTemp" ID="lblMedia" runat="server" />
        </div>
        <div class="info">
            <asp:Button Text="< Desv. Padrão >" ID="btnDesv" class="lbl" OnClick="btnDesv_Click" runat="server" />
            <br />
            <asp:Label Text="" class="lblTemp" ID="lblDesv" runat="server" />
        </div>
    </div>

    <%--SCRIPTS--%>

    <script type="text/javascript"> 
        var dados = [
            ['Minuto', 'Temp.  '],
            <% for (int i = 0; i < Temperaturas.Count; i++) { %>
                [ <%=Minutos[i] %>, <%=Temperaturas[i].ToString(System.Globalization.CultureInfo.InvariantCulture) %> ],
            <%} %>
        ];
    </script>

</asp:Content>

