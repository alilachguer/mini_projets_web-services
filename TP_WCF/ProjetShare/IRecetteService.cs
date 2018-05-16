using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjetShare
{
    [ServiceContract]
    public interface IRecetteService
    {
        [OperationContract]
        void AjouterRecette(Recette recette);

        [OperationContract]
        void AjouterIngredient(string recette, string ingredient);

        [OperationContract]
        List<Recette> GetRecettes();

        [OperationContract]
        Recette GetRecetteByNom(string nom);

        [OperationContract]
        List<Recette> GetRecettesByIngredient(string ingredient);

        [OperationContract]
        void DeleteRecette(string recette);

        [OperationContract]
        void RemoveFormCurrentSelection(Recette recette);

        [OperationContract]
        List<Recette> GetCurrentSelection();

        [OperationContract]
        void SaveAsCurrentSelection(List<Recette> recettes);

    }

    [DataContract]
    public class Recette
    {
        [DataMember]
        public string Nom { get; set; }

        [DataMember]
        public List<string> Ingredients { get; set; }

        public Recette(string name, List<string> ingred)
        {
            Nom = name;
            Ingredients = ingred;
        }

        public override string ToString()
        {
            string mystring = "Nom recette: " + Nom + "\n";
            mystring += "Ingredients: ";
            foreach (string ing in Ingredients)
                mystring += ing + ", ";

            return mystring;
        }
    }
}
