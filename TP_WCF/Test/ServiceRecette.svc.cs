using ProjetShare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceImplementation
{
    public class ServiceRecette : IRecetteService
    {
        List<Recette> recettes = new List<Recette>(
            new Recette[]
            {
                new Recette("recette1", new List<string>(){"ingredient1", "ingredient2", "ingredient3"}),
                new Recette("recette2", new List<string>(){"ingrxedient1", "ingredient2"}),
                new Recette("recette3", new List<string>(){"ingredient0", "ingredient6", "ingredient5"}),
                new Recette("recette4", new List<string>(){"ingredient1", "ingredient2", "ingredient3", "ingredient4"})
            }
        );
        static List<Recette> currentSelection;

        public static List<Recette> CurrentSelection { get => currentSelection; set => currentSelection = value; }

        public void AjouterIngredient(string recette, string ingredient)
        {
            foreach (Recette rec in recettes)
            {
                if (rec.Nom == recette)
                {
                    rec.Ingredients.Add(ingredient);
                }
            }
        }

        public void AjouterRecette(Recette recette)
        {
            recettes.Add(recette);
        }

        public void DeleteRecette(string recette)
        {
            foreach (Recette rec in recettes)
            {
                if (rec.Nom == recette)
                {
                    if (recettes.Contains(rec))
                        recettes.Remove(rec);
                }
            }
        }

        public List<Recette> GetCurrentSelection()
        {
            return CurrentSelection;
        }

        public List<Recette> GetRecettes()
        {
            return recettes;
        }

        public List<Recette> GetRecettesByIngredient(string ingredient)
        {
            List<Recette> myrecettes = new List<Recette>();
            foreach (Recette recette in recettes)
            {
                if (recette.Ingredients.Contains(ingredient))
                    myrecettes.Add(recette);
            }
            return myrecettes;
        }

        public void RemoveFormCurrentSelection(Recette recette)
        {
            if (CurrentSelection.Contains(recette))
                CurrentSelection.Remove(recette);
        }

        public void SaveAsCurrentSelection(List<Recette> recettes)
        {
            CurrentSelection = recettes;
        }

        public Recette GetRecetteByNom(string nom)
        {
            foreach(Recette recette in recettes)
            {
                if(recette.Nom == nom)
                {
                    return recette;
                }
            }
            return null;
        }
    }
}
