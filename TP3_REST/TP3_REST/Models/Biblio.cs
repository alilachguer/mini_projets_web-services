using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// Description résumée de Biblio
/// </summary>
/// 

namespace TP3_REST.Models
{
    
    public class Biblio
    {
        public List<UtilisateurAbonne> utilisateurs = new List<UtilisateurAbonne>();
        public List<Livre> livres = new List<Livre>();

        public Biblio()
        {
            ////bibliotheque = new Biblio("ma bibliotheque");

            //livres.Add(new Livre("harry potter", "jk rowling", "poche", 12345, 12));
            //livres.Add(new Livre("lord of the rings", "Tolkien", "ace books", 87452, 6));
            //livres.Add(new Livre("don quixote", "de cervantes", "glenat", 25478, 8));

            utilisateurs.Add(new UtilisateurAbonne("ali"));
            utilisateurs.Add(new UtilisateurAbonne("thomas"));

        }


        public List<UtilisateurAbonne> getUtilisateurs()
        {
            return utilisateurs;
        }

        public List<Livre> getLivres()
        {
            return livres;
        }

        public void ajouterLivre(string titre, string auteur, string editeur, int isbn, int nbexemplaires)
        {
            livres.Add(new Livre(titre, auteur, editeur, isbn, nbexemplaires));
        }

        public void ajouterUtilisateurAbonne(UtilisateurAbonne user)
        {
            utilisateurs.Add(user);
        }

        public Livre GetLivreByISBN(int isbn)
        {
            Livre lvr = null;
            foreach (Livre item in livres)
            {
                if (item.ISBN == isbn)
                    lvr = item;
                else
                    lvr = null;
            }
            return lvr;
        }

        public Livre GetLivreByAuteur(string auteur)
        {
            Livre livre = null;
            foreach (Livre lvr in livres)
            {
                if (lvr.Auteur == auteur)
                    livre = lvr;
            }
            return livre;
        }


        public UtilisateurAbonne getUserById(string numero)
        {
            UtilisateurAbonne util = null;
            foreach (UtilisateurAbonne user in utilisateurs)
            {
                if (user.Numero == numero)
                    util = user;
            }
            return util;
        }

        public bool utilisateurExist(string numero)
        {
            bool util = false;
            foreach (UtilisateurAbonne user in utilisateurs)
            {
                if (user.Numero == numero)
                    util = true;
            }
            return util;
        }

        public void ajouterCommentaire(Commentaire commentaire, Livre livre, string numero, string password)
        {
            foreach (Livre item in livres)
            {
                if (item == livre && getUserById(numero).Password == password && utilisateurExist(numero))
                {
                    GetLivreByISBN(livre.ISBN).addCommentaire(commentaire);
                    Console.WriteLine("commentaire ajouté");
                }

            }
        }

        public List<Commentaire> getCommentairesByLivre(Livre livre)
        {
            if (livres.Contains(livre))
                return livre.Commentaires;
            else
                return null;
        }

        public void changeUserPassword(string numero, string oldpass, string newpass)
        {
            if (utilisateurExist(numero))
            {
                getUserById(numero).changerPassword(oldpass, newpass);
            }
        }

    }
}

