<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grafico_google.aspx.cs" Inherits="Pollo.area_consulta.grafico_google" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="Chocadeira: " runat="server" />
            <asp:Label Text="Data conexão: " runat="server" />
            <asp:Label Text="Dia(s) restantes: " runat="server" />
            <div id="chart_div" style="width: 100%; height: 500px;"></div>
            <select>
                <option value="value">Minuto</option>
                 <option value="value">Hora</option>
                 <option value="value">Dia</option>
                 <option value="value">Mês</option>
            </select>
            <script type="text/javascript">
                var dados = [
                    ['Minuto', 'Temperatura'],
                    <% for (int i = 0; i < Temperaturas.Count; i++) { %>
                    [ <%=Minutos[i] %>, <%=Temperaturas[i] %> ],
                    <% } %>
                ];
            </script>
            <script type="text/javascript" src="../js/grafico.js"></script>
        </div>
    </form>
</body>
</html>
