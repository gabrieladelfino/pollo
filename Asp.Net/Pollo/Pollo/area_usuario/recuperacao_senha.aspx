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
            <asp:ScriptManager ID='ScriptManager1' runat='server' EnablePageMethods='true' />

            <div id="logo">
				<img src="../imagens/logo_pollo.PNG"/>
		    </div>

            <label class="lbl">Email/User</label>
            <asp:TextBox class="txt"  runat="server" ID="txtUsuario" OnTextChanged="txtUsuario_TextChanged"/>
            <br />
          
            <label class="lbl">Pergunta</label>
            <asp:TextBox class="txt"  runat="server" ID="txtPergunta" />
            <br />

            <label class="lbl">Resposta</label>
            <asp:TextBox class="txt"  runat="server" ID="txtResposta" OnTextChanged="txtResposta_TextChanged" AutoPostBack="true"/>
            <br />
            <asp:Label Text="text" ID="lblResp" runat="server"/>

            <label class="lbl">Nova senha</label>
            <asp:TextBox class="txt" type="password" runat="server" ID="txtNovaSenha" />
            <br />

            <label class="lbl">Confirmar senha</label>
            <asp:TextBox class="txt" type="password" runat="server" ID="txtConfirmarSenha" />
            <br />

            <asp:Button Text="Recuperar" class="btn" runat="server" ID="btnRecuperar" Onclick="btnRecuperar_Click"/>
            <asp:Label Text="" ID="lblErro" runat="server" />
        </div>
            
    </form>
</body>
</html>
