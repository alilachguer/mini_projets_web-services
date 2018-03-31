using System;
using System.Collections.Generic;
using System.Text;

namespace biblio
{
    public class UtilisateurAbonne
    {
        string nom, numero, password;
        int count = 0;

        public UtilisateurAbonne()
        {

        }

        public UtilisateurAbonne(string nom)
        {
            string num = nom + count++;
            this.numero = num;
            this.password = num;
            this.nom = nom;
        }

        public string Numero
        {
            get { return this.numero; }
            set { this.numero = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public string getPasswordById(string numero)
        {
            if (this.numero == numero)
                return this.password;
            else
                return null;
        }

        public void changerPassword(string oldpass, string newpass)
        {
            if(this.password == oldpass)
            {
                this.password = newpass;
                Console.WriteLine("le mot de passe a ete modifie");
            }
               
            else
                Console.WriteLine("ancien mot de passe incorrecte");
        }

        public override string ToString()
        {
            string user = "nom: " + this.nom;
            user += ", numero: " + this.numero;
            user += ", mot de passe: " + this.password;
            return user;
        }
    }
}
