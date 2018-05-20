<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastro_chocadeira.aspx.cs" Inherits="Pollo.area_chocadeira.cadastro_chocadeira" %>

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

            Ovo Abrigado:  
            <asp:DropDownList runat="server" ID="ddlCod_ovo">  
            <asp:ListItem Text="" />
            </asp:DropDownList>

            <br />

            Quantidade de ovos abrigados: <asp:TextBox runat="server" ID="txtQtdOvos"  /> <br />
            <asp:Button Text="prosseguir" runat="server" ID= "btnCadastrar" onclick="btnCadastrar_Click"/>
            <asp:Label Text="" runat="server" ID="lblErro" />
        </div>
    </form>
</body>
</html>
