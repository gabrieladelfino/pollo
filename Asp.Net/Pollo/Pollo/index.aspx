<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Pollo.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="estilos/login.css" />
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
				        <img src="imagens/logo_pollo.PNG"/>
		            </div>
                    
                    <%--<p class="pollo">Pollo</p>--%>
			       
                    <div class="comp">
                        <label class="lbl">Digite seu nome</label>
			            <br/>
			            <asp:TextBox runat="server" class="txt" ID="txtUser"/>
			            <br/>
				 
			            <br/>
			            <label class="lbl">Digite sua senha</label>
			            <br/>
			            <asp:TextBox runat="server" type="password" class="txt" ID="txtSenha"/>
			            <br/>
			            <br/>

			            <asp:Button runat="server" text="Login" ID="btnLogar" class="btn" OnClick="btnLogin_Click"/>
			            <br/><br />
			            <label  class="lbl"><a href="../area_usuario/cadastro.aspx">Não é cadastrado ainda?</a></label>
                    </div>
                </div>
            </main>
            <footer>

            </footer>
        </div>
    </form>
</body>
</html>
