using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;
using biblio;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    //Biblio bibliotheque;

    public Service()
    {
        //bibliotheque = new Biblio("ma bibliotheque");

        //bibliotheque.ajouterLivre("harry potter", "jk rowling", "poche", 12345, 12);
        //bibliotheque.ajouterLivre("lord of the rings", "Tolkien", "ace books", 87452, 6);
        //bibliotheque.ajouterLivre("don quixote", "de cervantes", "glenat", 25478, 8);

        //bibliotheque.ajouterUtilisateurAbonne(new UtilisateurAbonne("ali"));
        //bibliotheque.ajouterUtilisateurAbonne(new UtilisateurAbonne("thomas"));
    }

    [WebMethod]
    public List<UtilisateurAbonne> getUtilisateurs()
    {
        return Biblio.utilisateurs;
    }


    //[WebMethod]
    //public Biblio GetBiblio(string nom)
    //{
    //    bibliotheque = new Biblio(nom);
    //    return bibliotheque;
    //}

    [WebMethod]
    public List<Livre> getLivres()
    {
        return Biblio.livres;
    }

    [WebMethod]
    public void ajouterLivre(string titre, string auteur, string editeur, int isbn, int nbexemplaires)
    {
        //this.bibliotheque.ajouterLivre(titre, auteur, editeur, isbn, nbexemplaires);
        if(!LivreExists(isbn))
            Biblio.livres.Add(new Livre(titre, auteur, editeur, isbn, nbexemplaires));
        else
            Console.WriteLine("le livre existe deja");
    }

    [WebMethod]
    public void ajouterUtilisateurAbonne(string nom)
    {
        ////bibliotheque.ajouterUtilisateurAbonne(new UtilisateurAbonne(nom));
        Biblio.utilisateurs.Add(new UtilisateurAbonne(nom));
    }

    [WebMethod]
    public Livre GetLivreByISBN(int isbn)
    {
        foreach (Livre item in Biblio.livres)
        {
            if (item.ISBN == isbn)
                return item;
        }
        return null;
    }

    [WebMethod]
    public Livre GetLivreByAuteur(string auteur)
    {
        foreach (Livre item in Biblio.livres)
        {
            if (item.Auteur == auteur)
                return item;
        }
        return null;
    }

    [WebMethod]
    public UtilisateurAbonne getUserById(string numero)
    {
        foreach (UtilisateurAbonne item in Biblio.utilisateurs)
        {
            if (item.Numero == numero)
                return item;
        }
        return null;
    }

    [WebMethod]
    public bool utilisateurExist(string numero)
    {
        foreach (UtilisateurAbonne item in Biblio.utilisateurs)
        {
            if (item.Numero == numero)
                return true;
        }
        return false;
    }

    [WebMethod]
    public bool LivreExists(int isbn)
    {
        foreach (Livre item in Biblio.livres)
        {
            if (item.ISBN == isbn)
                return true;
        }
        return false;
    }

    [WebMethod]
    public void ajouterCommentaire(string commentaire, Livre livre, string numero, string password)
    {
        if (LivreExists(livre.ISBN) && utilisateurExist(numero) && getUserById(numero).Password==password)
        {
            GetLivreByISBN(livre.ISBN).addCommentaire(commentaire);
        }
    }

    [WebMethod]
    public List<string> getCommentairesByLivre(Livre livre)
    {
        if(LivreExists(livre.ISBN))
            return livre.Commentaires;
        return null;
    }

    [WebMethod]
    public void changeUserPassword(string numero, string oldpass, string newpass)
    {
        Console.WriteLine("changeuserpassword");
        if(utilisateurExist(numero))
        {
            Console.WriteLine("user exists");
            if (getUserById(numero).Password == oldpass)
            {
                Console.WriteLine("password correct");
                getUserById(numero).Password = newpass;
                Console.WriteLine("password modifier");
            }
            else
                Console.WriteLine("erreur password");
        
        }
    }





    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    
}