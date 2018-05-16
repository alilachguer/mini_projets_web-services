using ProjetShare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IRecetteService recetteProxy =
                new ChannelFactory<IRecetteService>("RecetteServiceConfiguration").CreateChannel();


            Console.WriteLine("liste des recettes: ");
            foreach(Recette recette in recetteProxy.GetRecettes())
            {
                Console.WriteLine(recette.ToString());
            }

            Console.WriteLine("ajouter une recette: ");
            recetteProxy.AjouterRecette(new Recette("recette 5", new List<string> { "ingredient7", "ingredient8", "ingredient9" }));

            Console.WriteLine("ajouter un ingredeint a la recette: ");
            recetteProxy.AjouterIngredient("recette 5", "ingredient10");

            Console.WriteLine("affichage: ");
            Console.WriteLine(recetteProxy.GetRecetteByNom("recette 5").ToString());

            Console.ReadLine();

            //string func = "";

            //while(func != "5")
            //{
            //    Console.WriteLine("ajouter une nouvelle recette: 1");
            //    Console.WriteLine("affichier ma selection de recettes: 2");
            //    Console.WriteLine("chercher recettes par ingredients: 3");
            //    Console.WriteLine("modifier une recette: 4");
            //    Console.WriteLine("sortir: 5");

            //    func = Console.ReadLine();

            //    switch (func)
            //    {
            //        case "1":
            //            Console.WriteLine("entrer le nom de la recette: ");
            //            string nom = Console.ReadLine();
            //            foreach (Recette recette in recetteProxy.GetRecettes())
            //            {
            //                if (recette.Nom == nom)
            //                {
            //                    Console.WriteLine("la recette existe deja");
            //                    break;
            //                }
            //            }

            //            Console.WriteLine("entrer les ingredients (q pour quitter): ");
            //            string ingred = "";
            //            List<string> ingredients = new List<string>();
            //            while (ingred != "q")
            //            {
            //                Console.WriteLine("ingredient: ");
            //                ingred = Console.ReadLine();
            //                if (ingred != "q")
            //                    ingredients.Add(ingred);
            //            }
            //            recetteProxy.AjouterRecette(new Recette(nom, ingredients));
            //            Console.WriteLine("recette ajoutee avec succes");

            //            break;
            //        case "2":
            //            foreach(Recette recette in recetteProxy.GetRecettes())
            //            {
            //                Console.WriteLine(recette.ToString());
            //            }
            //            break;
            //        case "4":
            //            Console.WriteLine("nom de la recette a modifier: ");
            //            string name = Console.ReadLine();
            //            foreach (Recette recette in recetteProxy.GetRecettes())
            //            {
            //                if (recette.Nom == name)
            //                {
            //                    string ingr = "";
            //                    Console.WriteLine("ajouter ingredient: 1, enlever ingredient: 2");
            //                    string modifie = Console.ReadLine();
            //                    if(modifie == "1")
            //                    {
            //                        Console.WriteLine("entrer les ingredients (q pour quitter): ");
            //                        while (ingr != "q")
            //                        {
            //                            Console.WriteLine("ingredient: ");
            //                            ingr = Console.ReadLine();
            //                            if (ingr != "q")
            //                                recette.Ingredients.Add(ingr);
            //                        }
            //                    }
            //                    if(modifie == "2")
            //                    {
            //                        Console.WriteLine("nom de l'ingredient a enelver: ");
            //                        ingr = Console.ReadLine();
            //                        if (recette.Ingredients.Contains(ingr))
            //                        {
            //                            recette.Ingredients.Remove(ingr);
            //                        }
            //                        else
            //                        {
            //                            Console.WriteLine("cet ingredeint n'existe pas");
            //                        }
            //                    }
            //                    break;
            //                }
            //                else
            //                {
            //                    Console.WriteLine("le nom de la recette n'exite");
            //                    break;
            //                }
            //            }
            //            break;
            //    }

            //}
        }
    }
}
