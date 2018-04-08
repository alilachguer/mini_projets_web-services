using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TP3_REST.Models
{
    public class Livre
    {
        string titre, auteur, editeur;
        int isbn, nbExemplaires;
        List<Commentaire> comments;

        public Livre()
        {
            comments = new List<Commentaire>();
        }

        public Livre(string titre, string auteur, string editeur, int ISBN, int nbexemplaires)
        {
            comments = new List<Commentaire>();
            this.titre = titre;
            this.auteur = auteur;
            this.editeur = editeur;
            this.isbn = ISBN;
            this.nbExemplaires = nbexemplaires;
        }

        [Key]
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

        public List<Commentaire> Commentaires
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        
        public void addCommentaire(Commentaire commentaire)
        {
            this.comments.Add(commentaire);
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
