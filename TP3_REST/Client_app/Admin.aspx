<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Ajouter un livre</h1>
        <div>
            <asp:Label ID="Label1" runat="server" Text="isbn "></asp:Label>
            <asp:TextBox ID="isbn" runat="server" placeholder="isbn"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Titre "></asp:Label>
            <asp:TextBox ID="titre" runat="server" placeholder="titre"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Auteur "></asp:Label>
            <asp:TextBox ID="auteur" runat="server" placeholder="auteur"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Editeur "></asp:Label>
            <asp:TextBox ID="edition" runat="server" placeholder="edition"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" Text="Nombre exemplaires "></asp:Label>
            <asp:TextBox ID="nbExemplaires" runat="server" placeholder="nombre exemplaires"></asp:TextBox>
        </div>
        
        <asp:Button ID="ajouter_livre" runat="server" Text="ajouter" />
        

        <p>
            <%: res %>
        </p>

    </form>
</body>
</html>
