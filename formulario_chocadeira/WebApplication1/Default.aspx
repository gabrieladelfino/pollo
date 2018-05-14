<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div> 
            Cadastro Chocadeira <br />
            Nome Chocadeira: <asp:TextBox runat="server" ID="txtNomeChocadeira" />
            
            <br />

            Codigo do dispositivo: 
            <asp:DropDownList runat="server" ID="ddlCod_dispositivo">  
            <asp:ListItem Text="" />
            <asp:ListItem Text="dispositivo 1" />
            </asp:DropDownList>

            <br />

            Codigo do ovo: 
            <asp:DropDownList runat="server" ID="ddlCod_ovo">  
            <asp:ListItem Text="" />
            <asp:ListItem Text="ovo 1" />
            </asp:DropDownList>

            <br />

            Quantidade de ovos abrigados: <asp:TextBox runat="server" ID="txtQtdOvos"  /> <br />
            <asp:Button Text="prosseguir" runat="server" ID= "btnProsseguir_chocadeira" onclick="btnProsseguir_chocadeira_Click"/>
            <asp:Label Text="" runat="server" ID="lblErro" />

        </div>
        <br />
        <div> 
            Cadastro Dispositivo <br />
            Código do Dispositivo:<asp:TextBox runat="server" ID="txtCodDispositivo" /><br />
            Nome Dispositivo: <asp:TextBox runat="server" ID="txtNomeDispositivo" /> <br />
            Data de Conexão: <asp:TextBox runat="server" ID="dateConexao"  /> <br />

            <asp:Button Text="prosseguir" runat="server" ID= "btnProsseguir_dispositivo" OnClick="btnProsseguir_dispositivo_Click" />
            <asp:Label Text="" runat="server" ID="lblErro2" />

        </div> 
        <br />
        <div> 
            Cadastro Sensor <br />
            Código do Sensor:<asp:TextBox runat="server" ID="txtCodSensor" /><br />
            Tipo do Sensor: <asp:TextBox runat="server" ID="txtTipoSensor" /> <br />
            Entrada: <asp:TextBox runat="server" ID="txtEntrada"  /> <br />

            <asp:Button Text="prosseguir" runat="server" ID= "btnProsseguir_sensor" OnClick="btnProsseguir_sensor_Click" />
            <asp:Label Text="" runat="server" ID="lblErro3" />

        </div>
    </form>
</body>
</html>
