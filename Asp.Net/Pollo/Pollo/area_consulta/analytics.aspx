
<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Mestra.Master" AutoEventWireup="true" CodeBehind="analytics.aspx.cs" Inherits="Pollo.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="../estilos/analytics.css" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div id="grafico"></div>
    
    <div class="medias">
        <div class="info">
            <asp:Button Text="< Max >" ID="btnMaxMin" class="lbl" OnClick="btnMaxMin_Click"  runat="server"/>
            <br /><br />
            <asp:Label Text="" class="lblTemp" ID="lblMaxMin" runat="server" />
        </div>
        <div class="info">
            <asp:Button Text="< 1° Quartil >" ID="btnQuartil" class="lbl" OnClick="btnQuartil_Click" runat="server"/>
            <br /><br />
            <asp:Label Text="" class="lblTemp" ID="lblQuartil" runat="server" />
        </div>
        <div class="info">
            <asp:Button Text="< Média >" ID="btnMedia" class="lbl" OnClick="btnMedia_Click" runat="server" />
            <br /><br />
            <asp:Label Text="" class="lblTemp" ID="lblMedia" runat="server" />
        </div>
        <div class="info">
            <asp:Button Text="< Desv. Padrão >" ID="btnDesv" class="lbl" OnClick="btnDesv_Click" runat="server" />
            <br /><br />
            <asp:Label Text="" class="lblTemp" ID="lblDesv" runat="server" />
        </div>
    </div>

    <%--SCRIPTS--%>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript"> 
        google.charts.load('current', {'packages':['corechart']});
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            var data = google.visualization.arrayToDataTable([
                ['', 'Temp'],
                <%for (int i = 0; i < Temperaturas.Count; i++){%>
                 [<%=Minutos[i]%>,<%=Temperaturas[i].ToString(System.Globalization.CultureInfo.InvariantCulture)%>],
                <%}%>
            ]);

            var options = {
                title: 'Temperaturas cada 1(um) minuto',
                curveType: 'function',
                colors: ['#e2431e'],
                backgroundColor: 'transparent',
                lineWidth: 3,
                titleTextStyle: {
                    color: '#000',
                    fontSize: 20
                },
                hAxis: {
                    baselineColor: '#FFF000',
                    gridlines: { count: 6 }
                },
                legend: {
                    position: 'bottom',
                    textStyle: {
                        color: '#000',
                        fontSize: 16
                    }
                },
                chartArea: {
                    width: '70%',
                    height: '70%'
                }
            };

            var chart = new google.visualization.LineChart(document.getElementById('grafico'));
            chart.draw(data, options);
        }
    </script>

</asp:Content>
