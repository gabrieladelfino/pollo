<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Mestra.Master" AutoEventWireup="true" CodeBehind="ovo.aspx.cs" Inherits="Pollo.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../estilos/cadastro.css" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Cadastro Novo Tipo de Ovo</h1> 
    <br />
   
    <div class="comp">
        <label class="lbl">Tipo</label>
        <asp:TextBox runat="server" ID="txtTipo" class="txt"/> 
    </div>

     <div class="comp">
        <label class="lbl">Tamanho</label>
        <asp:DropDownList runat="server" ID="ddlTamanho" class="ddl">
        <asp:ListItem Text="" />
        <asp:ListItem Text="Pequeno" />
        <asp:ListItem Text="Medio" />
        <asp:ListItem Text="Grande" />
        </asp:DropDownList> 
    </div>

     <div class="comp">
        <label class="lbl">Temperatura</label>
        <asp:TextBox runat="server" ID="txtTemperatura" class="txt" />
    </div>

     <div class="comp">
         <label class="lbl">Tempo de incubação (dias)</label>
         <asp:TextBox runat="server" ID="txtTempo" class="txt"/>
    </div>
   
    <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" class="btn" OnClick="btnCancelar_Click"/>
    <asp:Button Text="Prosseguir" runat="server" ID="btnCadastrar" class="btn" OnClick="btnCadastrar_Click"/>
    <asp:Label Text="" runat="server" ID="lblErro" class="lbl"/>

</asp:Content>
