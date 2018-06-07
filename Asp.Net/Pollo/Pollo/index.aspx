<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Pollo.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="estilos/login.css" />
    <link rel="stylesheet" type="text/css" href="estilos/scroll.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login | Pollo</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <header>

            </header>
            <main>
                <div id="form">
                    <div id="logo">
				        <img src="imagens/logo.PNG"/>
		            </div>
                    
                    <div class="comp">
                        <label class="lbl">Digite seu user ou email</label>
			            <br/>
			            <asp:TextBox runat="server" class="txt" ID="txtUser" onkeyup="verificar(this)"/>
			            <br/>
				 
			            <br/>
			            <label class="lbl">Digite sua senha</label>
			            <br/>
			            <asp:TextBox runat="server" type="password" class="txt" ID="txtSenha" onkeyup="verificar(this)"/>
			            <br/>
			            <br/>

			            <asp:Button runat="server" text="Login" ID="btnLogar" class="btn" OnClick="btnLogin_Click"/>
			            <br/><br />
			            <label  class="lbl"><a href="../area_usuario/cadastro.aspx">Não é cadastrado ainda?</a></label>
                        <br />
                          <label  class="lbl"><a href="area_usuario/recuperacao_senha.aspx">Esqueceu sua senha?</a></label>
                    </div>
                </div>
            </main>
            <footer>

            </footer>
        </div>
    </form>
</body>
</html>
