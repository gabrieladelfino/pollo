<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Mestra.Master" AutoEventWireup="true" CodeBehind="analytics.aspx.cs" Inherits="Pollo.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="../estilos/analytics.css" type="text/css" />
     <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="comp">
        <asp:Label Text="" ID="txtChocadeira" runat="server" class="lbl"/>
        <asp:Label Text="" ID="txtDiasRestantes" runat="server" class="lbl"/>
    </div>

    <div id="chart_div"></div>
    
    <div class="medias">
        <div class="info-media" id="media">
            <label class="lbl">Média</label>
        </div>
        <div class="info-media" id="mediana">
            <label class="lbl">Mediana</label>
        </div>
        <div class="info-media" id="p-quartil">
             <label class="lbl">1° Quartil</label>
        </div>
        <div class="info-media" id="s-quartil">
            <label class="lbl">2° Quartil</label>
        </div>
        <div class="info-media" id="t-quartil">
            <label class="lbl">3° Quartil</label>
        </div>
        <div class="info-media" id="min">
            <label class="lbl">Min.</label>
        </div>
        <div class="info-media" id="max">
            <label class="lbl">Max</label>
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
    <script type="text/javascript" src="../js/grafico.js"></script>

</asp:Content>

