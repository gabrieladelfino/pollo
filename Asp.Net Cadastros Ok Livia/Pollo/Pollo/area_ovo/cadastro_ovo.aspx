<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastro_ovo.aspx.cs" Inherits="Pollo.area_ovo.cadastro_ovo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Cadastro Novo Tipo de Ovo</h1> <br />
            
            Tipo: <asp:TextBox runat="server" ID="txtTipo" /> <br /><br />
            
            Tamanho: 
            <asp:DropDownList runat="server" ID="ddlTamanho">
                <asp:ListItem Text="" />
                <asp:ListItem Text="Pequeno" />
                <asp:ListItem Text="Medio" />
                <asp:ListItem Text="Grande" />
            </asp:DropDownList> <br /><br />

            Temperatura:<asp:TextBox runat="server" ID="txtTemperatura" /><br /><br />

            Tempo de Incubação (Dias): <asp:TextBox runat="server" ID="txtTempo"/><br /><br />
            
            <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" OnClick="btnCancelar_Click" />
            <asp:Button Text="Prosseguir" runat="server" ID="btnCadastrar" OnClick="btnCadastrar_Click" />
            <asp:Label Text="" runat="server" ID="lblErro"/>
        </div>
    </form>
</body>
</html>
