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
            <label class="lbl">< Max ></label>
            <br />
            <asp:Label Text="" class="lblTemp" ID="max" runat="server" />
        </div>
        <div class="info">
            <label class="lbl">< 1° Quartil ></label>
            <br />
            <asp:Label Text="" class="lblTemp" ID="pQuartil" runat="server" />
        </div>
        <div class="info">
            <label class="lbl">Média</label>
            <br />
            <asp:Label Text="" class="lblTemp" ID="media" runat="server" />
        </div>
        <div class="info">
            <label class="lbl">Mediana</label>
            <br />
            <asp:Label Text="" class="lblTemp" ID="mediana" runat="server" />
        </div>
        <div class="info">
            <label class="lbl">Desv. Padrão</label>
            <br />
            <asp:Label Text="" class="lblTemp" ID="desvPadrao" runat="server" />
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

