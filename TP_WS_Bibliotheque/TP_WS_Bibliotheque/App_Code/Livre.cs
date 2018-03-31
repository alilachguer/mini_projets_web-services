using System;
using System.Collections.Generic;
using System.Text;

namespace biblio
{
    public class Livre
    {
        string titre, auteur, editeur;
        int isbn, nbExemplaires;
        List<string> commentaires;

        public Livre()
        {
            commentaires = new List<string>();
        }

        public Livre(string titre, string auteur, string editeur, int ISBN, int nbexemplaires)
        {
            commentaires = new List<string>();
            this.titre = titre;
            this.auteur = auteur;
            this.editeur = editeur;
            this.isbn = ISBN;
            this.nbExemplaires = nbexemplaires;
        }

        public int ISBN
        {
            get { return this.isbn; }
            set { this.isbn = value; }
        }

        public string Titre
        {
            get { return this.titre; }
            set { this.titre = value; }
        }

        public int NbExemplaires
        {
            get { return this.nbExemplaires; }
            set { this.nbExemplaires = value; }
        }

        public string Auteur
        {
            get { return this.auteur; }
            set { this.auteur = value; }
        }

        public string Editeur
        {
            get { return this.editeur; }
            set { this.editeur = value; }
        }

        public List<string> Commentaires
        {
            get { return this.commentaires; }
            set { this.commentaires = value; }
        }

        
        public void addCommentaire(string commentaire)
        {
            this.commentaires.Add(commentaire);
        }

        public string Afficher()
        {
            string livre = "titre: " + this.titre;
            livre += ", auteur: " + this.auteur;
            livre += ", editeur: " + this.editeur;
            livre += ", ISBN: " + this.isbn;
            livre += ", nombre exemplaires: " + this.nbExemplaires;
            return livre;
        }
    }
}
