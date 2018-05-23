<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="Pollo.area_usuario.cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../estilos/login.css" />
    <script type="text/javascript" src="../js/cadastro_usuario.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <header>

            </header>
            <main>
                <div id="form">
                    <div id="logo">
				        <img src="../imagens/pollo_bundinha.png"/>
		            </div>
                     <%--<p class="pollo">Pollo</p>--%>
			       
                    <div class="comp" id="info-usuario">
                        <label class="lbl">Nome Completo</label>
                        <asp:TextBox class="txt" runat="server" ID="txtNome"/>
                        <br />

                        <label class="lbl">Data nascimento</label>
                        <asp:TextBox class="txt" runat="server"  ID="txtNasc" onkeyup="mascara_data(this)"/>
                        <br />
                        
                        <label class="lbl">CPF</label>
                        <asp:TextBox class="txt" runat="server" ID ="txtCPF" onkeyup="mascara_cpf(this)"/>
                        <br />
                        
                        <label class="lbl">Celular</label> 
                        <asp:TextBox class="txt" runat="server" ID="txtCelular" onclick="clicou_telefone(this)" onkeyup="mascara_telefone(this)"/>
                        <br />
                        <button type="button" class="btn" id="btnProximo_0" onclick="mostra_info_login()">Prosseguir</button>
                    </div>

                    <div class="comp" id="info-login">
                        <label class="lbl">User</label>
                        <asp:TextBox class="txt" runat="server" ID="txtUser"/>
                        <br />
                        
                        <label class="lbl">Email</label>
                        <asp:TextBox class="txt" runat="server" ID="txtEmail"/>
                        <br />

                        <label class="lbl">Senha</label>
                        <asp:TextBox class="txt" type="password" runat="server" ID="txtSenha" />
                        <br /> 
                        
                        <label class="lbl">Confirmação de senha</label>
                        <asp:TextBox class="txt" type="password" runat="server" ID="txtSenhaConfirm" />
                        <br />
                        <button type="button" class="btn" id="btnAnterior_1" onclick="mostra_info_usuario()">Voltar</button>
                        <button type="button" class="btn" id="btnProximo_1" onclick="mostra_info_recuperacao_senha()">Prosseguir</button>
                    </div>

                    <div class="comp" id="info-recuperacao-senha">
                        <label class="lbl">Pergunta para recuperação</label>
                        <asp:DropDownList class="ddl" runat="server" ID="ddlPergunta">
                            <asp:ListItem Text="" />
                            <asp:ListItem Text="Qual o nome do seu primeiro animal de estimação?" />
                            <asp:ListItem Text="Qual o nome da sua primeira professora?" />
                            <asp:ListItem Text="Qual o nome de solteira da sua mãe?" />
                            <asp:ListItem Text="Qual o nome do seu filme preferido?" />
                            </asp:DropDownList>
                        <br />

                        <label class="lbl">Resposta</label>
                        <asp:TextBox class="txt" runat="server" ID="txtResposta" />
                        <br />
                        <button type="button" class="btn" id="btnAnterior_2" onclick="mostra_info_login()">Voltar</button>
                        <asp:Button Text="Cadastar" class="btn" runat="server" ID="btnCadastrar" Onclick="btnCadastrar_Click"/>
                    </div>
                      
               </div>
            </main>
            <footer>

            </footer>
        </div>
    </form>
</body>
</html>
