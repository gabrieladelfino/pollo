<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Pollo.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            User <asp:TextBox runat="server" ID="txtUser" class="txt"/> <br />
            Senha <asp:TextBox runat="server" ID="txtSenha" class="txt"/> <br />
            <asp:Button Text="Login" runat="server" ID="btnLogin" class="btn" OnClick="btnLogin_Click"/>
            <asp:Button Text="Cadastrar" runat="server" ID="btnCadastrar"  class="btn" OnClick="btnCadastrar_Click"/>
            <asp:Label Text="" runat="server" ID="lblErro" />
        </div>
    </form>
</body>
</html>
