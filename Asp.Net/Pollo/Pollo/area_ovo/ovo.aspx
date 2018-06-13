<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Mestra.Master" AutoEventWireup="true" CodeBehind="ovo.aspx.cs" Inherits="Pollo.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../estilos/cadastro.css" type="text/css" />
     <script type="text/javascript" src="../js/cadastro_usuario.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div id="cadastrados" class="painel" runat="server">  
        <h3 class="titulo-painel">Ovos já cadastradas</h3>
    </div>

    <div class="componente">
        <div class="comp">
            <label class="lbl">Tipo</label>
            <asp:TextBox runat="server" ID="txtTipo" class="txt" onkeyup="verificar(this)" onkeypress="return somenteLetras(event)" /> 
        </div>

         <div class="comp">
            <label class="lbl">Tamanho</label>
            <asp:DropDownList runat="server" ID="ddlTamanho" class="ddl" onkeyup="verificar(this)" onclick="verificar(this)">
            <asp:ListItem Text="" />
            </asp:DropDownList> 
        </div>

         <div class="comp">
            <label class="lbl">Temperatura</label>
            <asp:TextBox runat="server" ID="txtTemperatura" class="txt" onkeyup="verificar(this)" onkeypress="return somenteNumeros(event)" />
        </div>

         <div class="comp">
             <label class="lbl">Tempo de incubação (dias)</label>
             <asp:TextBox runat="server" ID="txtTempo" class="txt" onkeyup="verificar(this)" onkeypress="return somenteNumeros(event)" />
        </div>
   
        <div class="comp">
            <asp:Button Text="Limpar" runat="server" ID="btnLimpar" class="btn" OnClick="btnLimpar_Click"/>
            <asp:Button Text="" runat="server" ID="btnCadastrar" class="btn" OnClick="btnCadastrar_Click"/>
            <asp:Label Text="" runat="server" ID="lblErro" class="lbl"/>
        </div>
    </div>

</asp:Content>
