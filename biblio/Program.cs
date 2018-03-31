using System;

namespace biblio
{
    class Program
    {
        static void Main(string[] args)
        {
            Biblio biblio = new Biblio("bibliotheque");

            biblio.ajouterLivre(new Livre("harry potter", "jk rowling", "poche", 12345, 12));
            biblio.ajouterLivre(new Livre("lord of the rings", "Tolkien", "ace books", 87452, 6));
            biblio.ajouterLivre(new Livre("don quixote", "de cervantes", "glenat", 25478, 8));

            Console.WriteLine(biblio.GetLivreByAuteur("Tolkien"));

            biblio.ajouterUtilisateurAbonne(new UtilisateurAbonne("ali"));
            biblio.ajouterUtilisateurAbonne(new UtilisateurAbonne("thomas"));

            foreach (var item in biblio.getUtilisateurs())
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
