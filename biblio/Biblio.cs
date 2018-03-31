using System;
using System.Collections.Generic;
using System.Text;

namespace biblio
{
    public class Biblio
    {
        string nom;
        Dictionary<string, UtilisateurAbonne> utilisateurs;
        Dictionary<int, Livre> livres;

        public Dictionary<string, UtilisateurAbonne> getUtilisateurs()
        {
            return this.utilisateurs;
        }

        public Dictionary<int, Livre> getLivres()
        {
            return this.livres;
        }

        public Biblio(string nom)
        {
            this.nom = nom;
            this.livres = new Dictionary<int, Livre>();
            this.utilisateurs = new Dictionary<string, UtilisateurAbonne>();
        }

        public void ajouterLivre(Livre livre) => this.livres.Add(livre.ISBN, livre);
        public void ajouterUtilisateurAbonne(UtilisateurAbonne user) => this.utilisateurs.Add(user.Numero, user);

        public Livre GetLivreByISBN(int isbn)
        {
            return this.livres[isbn];
        }

        public Livre GetLivreByAuteur(string auteur)
        {
            Livre livre = null;
            foreach (KeyValuePair<int, Livre> lvr in this.livres)
            {
                if (lvr.Value.Auteur == auteur)
                    livre = lvr.Value;
            }
            return livre;
        }

        public void ajouterCommentaire(string commentaire, Livre livre, string numero, string password)
        {
            if (this.livres.ContainsValue(livre))
            {
                if (this.utilisateurs.ContainsKey(numero) && this.utilisateurs[numero].Password == password)
                {
                    livres[livre.ISBN].addCommentaire(commentaire);
                }
            }
        }

        public List<string> getCommentairesByLivre(Livre livre)
        {
            if (this.livres.ContainsValue(livre))
                return livre.Commentaires;
            else
                return null;
        }


        public void changeUserPassword(string numero, string oldpass, string newpass)
        {
            if (this.utilisateurs.ContainsKey(numero))
            {
                this.utilisateurs[numero].changerPassword(oldpass, newpass);
            }
        }
    }
}