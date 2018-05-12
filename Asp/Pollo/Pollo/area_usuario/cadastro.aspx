<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="Pollo.area_usuario.cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             Cadastre-se:<br /><br />

            Nome Completo:<asp:TextBox runat="server" ID="txtNome" /><br />
            Data de Nascimento:<asp:TextBox runat="server"  ID="txtNasc" placeholder="dd/mm/aaaa"/><br />
            CPF:<asp:TextBox runat="server" ID ="txtCPF" /><br />
            Sexo:<asp:DropDownList runat="server" ID="ddlSexo">
                <asp:ListItem Text="" />
                <asp:ListItem Text="Feminino" />
                <asp:ListItem Text="Masculino" />
                <asp:ListItem Text="Não especificado" />
                </asp:DropDownList><br />
            Telefone: <asp:TextBox runat="server" ID="txtTelefone"/><br />
            
            <asp:Button Text="Prosseguir" runat="server" ID="btnProseguir" OnClick="btnProsseguir_Click" /><br />
            <asp:Label Text="" runat="server" ID="Label1"/><br />

            User: <asp:TextBox runat="server" ID="txtUser"/><br />
            Email:<asp:TextBox runat="server" ID="txtEmail"/><br />
            Senha:<asp:TextBox runat="server" ID="txtSenha" /><br />
           
            Recuperação de senha:<br />

            Pergunta:<asp:DropDownList runat="server" ID="ddlPergunta">
                <asp:ListItem Text="" />
                <asp:ListItem Text="pergunta1" />
                <asp:ListItem Text="pergunta2" />
                </asp:DropDownList><br />
            Resposta:<asp:TextBox runat="server" ID="txtResposta" /><br />


            <asp:Button Text="Cadastar" runat="server" ID="btnCadastrar" Onclick="btnCadastrar_Click"/>
           <asp:Label Text="" runat="server" ID="lblErro"/>

        </div>
    </form>
</body>
</html>
