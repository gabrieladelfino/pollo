<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pollo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           Colocar aqui toda a pagina inicial da code <br />   
            if(pagina>1) <br />  
            {<br />  
             Colocar as subpaginas dentro da pasta area_code<br />  
            }<br />  
            <asp:Button Text="Pollo" runat="server" ID="btnPollo" OnClick="btnPollo_Click"/>
        </div>
    </form>
</body>
</html>
