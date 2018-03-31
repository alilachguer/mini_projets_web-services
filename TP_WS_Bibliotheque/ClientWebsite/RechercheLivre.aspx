<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RechercheLivre.aspx.cs" Inherits="ClientWebsite.RechercheLivre" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="isbnlabel" runat="server" Text="recherche par ISBN"></asp:Label>
        </div>
        <asp:TextBox ID="isbn" runat="server" Width="130px"></asp:TextBox>
        <p>
            <asp:Label ID="Label1" runat="server" Text="recherche par auteur"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="auteur" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="recherche" runat="server" OnClick="recherche_Click" Text="chercher" />
        <p>
            <asp:Label ID="resultat" runat="server"></asp:Label>
        </p>
    </form>
    <div id="result">
    </div>
</body>
</html>
