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
				        <img src="../imagens/logo.PNG"/>
		            </div>
                  
                    <div class="comp" id="info-usuario">
                        <label class="lbl">Nome Completo</label>
                        <asp:TextBox class="txt" runat="server" ID="txtNome" onkeyup="verificar(this)" onkeypress="return somenteLetras(event)"/>
                        <br />

                        <label class="lbl">Data nascimento</label>
                        <asp:TextBox class="txt" runat="server"  maxlength="10" ID="txtNasc" onkeyup="mascara_data(this),verificar(this)" onkeypress="return somenteNumeros(event)"/>
                        <br />
                        
                        <label class="lbl">Sexo</label>
                        <asp:DropDownList class="ddl" runat="server" ID="ddlSexo" onkeyup="verificar(this)">
                            <asp:ListItem            Text=""  />
                            <asp:ListItem Value= "F" Text="Feminino"  />
                            <asp:ListItem Value= "M" Text="Masculino" />
                            <asp:ListItem Value= "O" Text="Outro" />
                        </asp:DropDownList>
                        <br />
                        
                        <label class="lbl">Celular</label> 
                        <asp:TextBox class="txt" runat="server" ID="txtCelular" maxlength="14" onclick="clicou_telefone(this)" onkeyup="mascara_telefone(this),verificar(this)" onkeypress="return somenteNumeros(event)"/>
                        <br />
                        <button type="button" class="btn" id="btnProximo_0" onclick="mostra_info_login()">Prosseguir</button>
                    </div>

                    <div class="comp" id="info-login">
                        <label class="lbl">User</label>
                        <asp:TextBox class="txt" runat="server" ID="txtUser" maxlength="10" onkeyup="verificar(this)" onkeypress="return somenteLetras(event)"/>
                        <br />
                        
                        <label class="lbl">Email</label>
                        <asp:TextBox class="txt" runat="server" ID="txtEmail" onkeyup="verificar(this)"/>
                        <br />

                        <label class="lbl">Senha</label>
                        <asp:TextBox class="txt" type="password" maxlength="8" runat="server" ID="txtSenha" onkeyup="verificar(this)" />
                        <br /> 
                        
                        <label class="lbl">Confirmação de senha</label>
                        <asp:TextBox class="txt" type="password" maxlength="8" runat="server" ID="txtSenhaConfirm" onkeyup="verificar(this)" />
                        <br />
                        <button type="button" class="btn" id="btnAnterior_1" onclick="mostra_info_usuario()">Voltar</button>
                        <button type="button" class="btn" id="btnProximo_1" onclick="mostra_info_recuperacao_senha()">Prosseguir</button>
                    </div>

                    <div class="comp" id="info-recuperacao-senha">
                        <label class="lbl">Pergunta para recuperação</label>
                        <asp:DropDownList class="ddl" runat="server" ID="ddlPergunta" onkeyup="verificar(this)">
                            <asp:ListItem Text="" />
                            </asp:DropDownList>
                        <br />

                        <label class="lbl">Resposta</label>
                        <asp:TextBox class="txt" runat="server"  maxlength="20" ID="txtResposta" onkeyup="verificar(this)"/>
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
