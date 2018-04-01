using System;
using System.Collections.Generic;
using System.Text;


    public class Livre
    {
        string titre, auteur, editeur;
        int isbn, nbExemplaires;
        List<string> commentaires;

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
        }

        public string Auteur
        {
            get { return this.auteur; }
        }

        public List<string> Commentaires
        {
            get { return this.commentaires; }
        }

        public void addCommentaire(string commentaire)
        {
            this.commentaires.Add(commentaire);
        }

        public override string ToString()
        {
            string livre = "titre: " + this.titre;
            livre += ", auteur: " + this.auteur;
            livre += ", editeur: " + this.editeur;
            livre += ", ISBN: " + this.isbn;
            livre += ", nombre exemplaires: " + this.nbExemplaires;
            return livre;
        }
    }

