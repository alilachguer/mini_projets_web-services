using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Services;



    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    public class Biblio : System.Web.Services.WebService
    {
        static Biblio instance;
        string nom;
        Dictionary<string, UtilisateurAbonne> utilisateurs;
        Dictionary<int, Livre> livres;

        [WebMethod]
        public Dictionary<string, UtilisateurAbonne> getUtilisateurs()
        {
            return this.utilisateurs;
        }

        [WebMethod]
        public Dictionary<int, Livre> getLivres()
        {
            return this.livres;
        }

        private Biblio(string nom)
        {
            this.nom = nom;
            this.livres = new Dictionary<int, Livre>();
            this.utilisateurs = new Dictionary<string, UtilisateurAbonne>();
        }

        [WebMethod]
        public static Biblio GetBiblio(string nom)
        {
            if (Biblio.instance == null)
            {
                instance = new Biblio(nom);
            }
            return instance;
        }

        [WebMethod]
        public void ajouterLivre(Livre livre)
        {
            this.livres.Add(livre.ISBN, livre);
        }

        [WebMethod]
        public void ajouterUtilisateurAbonne(UtilisateurAbonne user)
        {
            this.utilisateurs.Add(user.Numero, user);
        }

        [WebMethod]
        public Livre GetLivreByISBN(int isbn)
        {
            return this.livres[isbn];
        }

        [WebMethod]
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

        [WebMethod]
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

        [WebMethod]
        public List<string> getCommentairesByLivre(Livre livre)
        {
            if (this.livres.ContainsValue(livre))
                return livre.Commentaires;
            else
                return null;
        }

        [WebMethod]
        public void changeUserPassword(string numero, string oldpass, string newpass)
        {
            if (this.utilisateurs.ContainsKey(numero))
            {
                this.utilisateurs[numero].changerPassword(oldpass, newpass);
            }
        }
    }
