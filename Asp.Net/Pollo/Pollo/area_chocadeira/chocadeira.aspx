6<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Mestra.Master" AutoEventWireup="true" CodeBehind="chocadeira.aspx.cs" Inherits="Pollo.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="../estilos/cadastro.css" type="text/css" />
     <script type="text/javascript" src="../js/cadastro_usuario.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <div id="cadastrados" class="painel" runat="server">  
            
        </div>

        <div class="componente">
            <div class="comp">
                <label class="lbl">Chocadeira</label>
                <asp:TextBox runat="server" ID="txtNomeChocadeira" class="txt" onkeyup="verificar(this)" onkeypress="return somenteLetras(event)"/>    
            </div>

            <div class="comp">
                <label class="lbl">Ovo abrigado</label> 
                <asp:DropDownList runat="server" ID="ddlCod_ovo" class="ddl" onclick="verificar(this)" onkeyup="verificar(this)">   
                    <asp:ListItem Text="" />
                </asp:DropDownList> 
             </div>

            <div class="comp">
                <label class="lbl">Quantidade</label> 
                <asp:TextBox runat="server" ID="txtQtdOvos" class="txt" onkeyup="verificar(this)" onkeypress="return somenteNumeros(event)"/>
            </div>

            <div class="comp">
                <asp:Button Text="Limpar" runat="server" ID="btnLimpar" class="btn" OnClick="btnLimpar_Click"/>
                <asp:Button Text="Prosseguir" runat="server" ID= "btnCadastrar" class="btn" onclick="btnCadastrar_Click"/>
                <br />
                <asp:Label Text="" runat="server" ID="lblErro" />
            </div>

        </div>
        
       
</asp:Content>
