
<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Mestra.Master" AutoEventWireup="true" CodeBehind="analytics.aspx.cs" Inherits="Pollo.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="../estilos/analytics.css" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   
    <div id="grafico"></div>

    <div class="medias">
        <div class="info">
            <asp:Button Text="Analytics" ID="btnTempo" class="lbl" runat="server"/>
            <br /><br />
            <div class="lblTexto">
                Gerando dados por <asp:Label Text="" ID="lblTempo" runat="server" />.
            </div>
        </div>
        <div class="info">
            <asp:Button Text="Max." ID="btnMax" class="lbl" runat="server"/>
            <br /><br />
            <asp:Label Text="" class="lblTemp" ID="lblMax" runat="server" />
        </div>

        <div class="info">
            <asp:Button Text="Min." ID="btnMin" class="lbl" runat="server"/>
            <br /><br />
            <asp:Label Text="" class="lblTemp" ID="lblMin" runat="server" />
        </div>
        
        <div class="info">
            <asp:Button Text="1° Quartil" ID="btnPQuartil" class="lbl" runat="server"/>
            <br /><br />
            <asp:Label Text="" class="lblTemp" ID="lblPQuartil" runat="server" />
        </div>
            
        <div class="info">
            <asp:Button Text="3° Quartil" ID="btnTQuartil" class="lbl" runat="server"/>
            <br /><br />
            <asp:Label Text="" class="lblTemp" ID="lblTQuartil" runat="server" />
        </div>
            
        <div class="info">
            <asp:Button Text="Média" ID="btnMedia" class="lbl" runat="server" />
            <br /><br />
            <asp:Label Text="" class="lblTemp" ID="lblMedia" runat="server" />
        </div>

        <div class="info">
            <asp:Button Text="Mediana" ID="btnMediana" class="lbl" runat="server" />
            <br /><br />
            <asp:Label Text="" class="lblTemp" ID="lblMediana" runat="server" />
        </div>
           
        <div class="info">
            <asp:Button Text="Desv. Padrão" ID="btnDesv" class="lbl" runat="server" />
            <br /><br />
            <asp:Label Text="" class="lblTemp" ID="lblDesv" runat="server" />
        </div>
            
        <div class="info">
            <asp:Button Text="Moda" ID="btnModa" class="lbl" runat="server" />
            <br /><br />
            <asp:Label Text="" class="lblTemp" ID="lblModa" runat="server" />
        </div>
    </div>

     <label class="lbl_ddl">
        Parâmetro: 
        <asp:DropDownList ID="ddlTempo" runat="server" OnLoad="ddlTempo_Load">
            <asp:ListItem Text="Minuto" Value="0"/>
            <asp:ListItem Text="Hora" Value="1"/>
            <asp:ListItem Text="Dia" Value="2"/>
        </asp:DropDownList>
         <asp:Button ID="btnParametro" Text="Ver" runat="server"  OnClick="btnParametro_Click" />
    </label>
   
    <%--SCRIPTS--%>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script src="http://code.jquery.com/jquery-1.8.2.js"> </script>
	<script type="text/java" src="https://www.gstatic.com/charts/loader.js"></script>
    
   <script type="text/javascript"> 

       google.charts.load('current', { packages: ['corechart', 'line'] });
       google.charts.setOnLoadCallback(drawChart);

        var chart = null, data;

        function drawChart() {

            var options = {
                title: 'Temperaturas',
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

            <% Listar(); %>

            data = google.visualization.arrayToDataTable([
                ['', 'Temp'],
			    <%for (int i = 0; i < Temperaturas.Count; i++){%>
                [<%=Minutos[i]%>,<%=Temperaturas[i].ToString(System.Globalization.CultureInfo.InvariantCulture)%>],
			    <%}%>
            ]);

            chart = new google.visualization.LineChart(document.getElementById('grafico'));
            chart.draw(data, options);

            setTimeout(function () {
                $("#grafico").load;
                $("#medias").load;
                drawChart();
            }, 1000);
        }
    </script>

</asp:Content>
