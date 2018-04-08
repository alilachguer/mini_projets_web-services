using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TP3_REST.Models
{
    public class Commentaire
    {
        static int count = 0;
        string id;

        [Key]
        public string IdCommentaire {
            get { return this.id; }
            set { this.id = value; }
        }
        
        public int idLivre { get; set; }
        public string commentaire { get; set; }

        public Commentaire(int idlivre, string commentaire)
        {
            this.id = idLivre.ToString() + count++;
            this.idLivre = idlivre;
            this.commentaire = commentaire;
        }


        public Commentaire() { }
    }
}
