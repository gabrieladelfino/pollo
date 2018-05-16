<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="consulta.aspx.cs" Inherits="Pollo.area_consulta.consulta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <h1>Média das temperaturas por hora</h1>
             <asp:Button Text="Gerar grafico" runat="server" OnClick="criarGrafico"/></asp:button>
             <div runat="server" id="chart_div"></div>
        </div>
    </form>
</body>
</html>
