<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recuperacao_senha.aspx.cs" Inherits="Pollo.area_usuario.recuperacao_senha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../estilos/login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="form">
            <div id="logo">
				<img src="../imagens/logo_pollo.PNG"/>
		    </div>

            <label class="lbl">Pergunta para recuperação</label>
            <asp:DropDownList class="ddl" runat="server" ID="ddlPergunta">
                <asp:ListItem Text="" />
                <asp:ListItem Text="Qual o nome do seu primeiro animal de estimação?" />
                <asp:ListItem Text="Qual o nome da sua primeira professora?" />
                <asp:ListItem Text="Qual o nome de solteira da sua mãe?" />
                <asp:ListItem Text="Qual o nome do seu filme preferido?" />
            </asp:DropDownList>

            <label class="lbl">Resposta</label>
            <asp:TextBox class="txt" type="password" runat="server" ID="txtResposta" />
            <br />

            <label class="lbl">Nova senha</label>
            <asp:TextBox class="txt" type="password" runat="server" ID="txtNovaSenha" />
            <br />

            <label class="lbl">Confirmar senha</label>
            <asp:TextBox class="txt" type="password" runat="server" ID="txtConfirmarSenha" />
            <br />

            <asp:Button Text="Recuperar" class="btn" runat="server" ID="btnRecuperar" Onclick="btnRecuperar_Click"/>
        </div>
    </form>
</body>
</html>
