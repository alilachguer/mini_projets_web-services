<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #Text1 {
            width: 181px;
        }
        #Button1 {
            width: 63px;
        }
    </style>
</head>
<body>
    <form id="form_livre" runat="server">
        <h1>Chercher un livre</h1>
        <div>
            <div>
                <asp:Label ID="isbnlabel" runat="server" Text="recherche par ISBN: "></asp:Label>
            </div>
            <asp:TextBox runat="server" ID="livre_isbn" type="text" placeholder="numero isbn"/>
            <asp:Button ID="button_livre_isbn" runat="server" Text="chercher" Height="24px" Width="89px" OnClick="button_livre_isbn_Click" />
        </div>
        <div>
            <div>
                <asp:Label ID="Label1" runat="server" Text="recherche par auteur: "></asp:Label>
            </div>
            <asp:TextBox runat="server" ID="livre_auteur" type="text" placeholder="nom auteur"/>
            <asp:Button ID="button_livre_auteur" runat="server" Text="chercher" Height="24px" Width="89px" OnClick="button_livre_auteur_Click" />
        </div>
        
        <div>
         <table border="1">
              <tr>
                <th>ISBN</th>
                <th>Titre</th>
                <th>Auteur</th>
                <th>Edition</th>
                <th>Nombre exemplaires</th>
              </tr>
             <%if(livres.Count >= 1){ %>
              <% foreach (var res in livres) { %>
              <tr>
                <td><%: res.ISBN %></td>
                <td><%: res.Titre %></td>
                <td><%: res.Auteur %></td>
                <td><%: res.Editeur %></td>
                <td><%: res.NbExemplaires %></td>
              </tr>
             <% } }%>
             <%else{%>
                <tr>
                <td><%: livre.ISBN %></td>
                <td><%: livre.Titre %></td>
                <td><%: livre.Auteur %></td>
                <td><%: livre.Editeur %></td>
                <td><%: livre.NbExemplaires %></td>
              </tr>
             <%} %>
         </table> 
    </div>
        <a href="User.aspx">se connecter</a>
    </form>
    
</body>
</html>
