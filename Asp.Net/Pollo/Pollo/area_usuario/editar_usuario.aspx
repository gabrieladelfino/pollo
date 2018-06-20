<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Mestra.Master" AutoEventWireup="true" CodeBehind="editar_usuario.aspx.cs" Inherits="Pollo.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../estilos/cadastro.css" type="text/css" />
    <script type="text/javascript" src="../js/cadastro_usuario.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="painel-imagem">  
        <div class="lblImagem">
            <asp:Image runat="server" ID="imgUsuario" class="imagem_usuario"/>
        </div>
        <div class="lblNome">
            <asp:Label ID="lblNomeUsuario" runat="server"/>
        </div>
    </div>  

    <div id="painel-upload">
        <div class="lblEditar">
            <asp:Label ID="lblEditar" Text="Editar foto" runat="server"/>
        </div>
        <br />
         <asp:FileUpload  class="btn_escolher" runat="server" ID="fileImagem"/>
         <br />
        <asp:Button ID="btnUpload" class="btn_file" Text="Salvar" runat="server" OnClick="btnUpload_Click" />
        <br />
        <asp:Label ID="lblMessage" Text="" runat="server" class="lblEditar"/>
    </div>

    <div class="componente">
        <div class="comp">
            <label class="lbl">Nome completo</label>
            <asp:TextBox runat="server" ID="txtNome" class="txt" onkeyup="verificar(this)" onkeypress="return somenteLetras(event)"/>    
        </div>

        <div class="comp">
            <label class="lbl">Data nascimento</label> 
            <asp:TextBox runat="server" ID="txtDataNasc" class="txt" maxlength="10" onkeyup="mascara_data(this),verificar(this)" onkeypress="return somenteNumeros(event)"/>
        </div>

            <div class="comp">
            <label class="lbl">Email</label> 
            <asp:TextBox runat="server" ID="txtEmail" class="txt" onkeyup="verificar(this)"/>
        </div>

        <div class="comp">
            <label class="lbl">Celular</label> 
            <asp:TextBox runat="server" ID="txtCelular" class="txt" maxlength="14" onclick="clicou_telefone(this)" onkeyup="mascara_telefone(this),verificar(this)" onkeypress="return somenteNumeros(event)"/>
        </div>

        <div class="comp">
            <label class="lbl">User</label> 
            <asp:TextBox runat="server" ID="txtUser" class="txt"  onkeyup="verificar(this)"/>
        </div>

        <div class="comp">
            <asp:Button Text="Editar" runat="server" ID= "btnEditar" class="btn" OnClick="btnEditar_Click"/>
            <br />
            <asp:Label Text="" runat="server" ID="lblErro" class="lbl"/>
        </div>
    </div>
</asp:Content>
