using System;
using System.Collections.Generic;
using System.Text;


    public class UtilisateurAbonne
    {
        string nom, numero, password;

        public UtilisateurAbonne(string nom)
        {
            //numero généré a partir du numero du jour, l'heure, et la seconde de la creation du user
            this.numero = nom + DateTime.Now.ToString("ddHHmmss");
            // mot de passe par defaut généré aleatoirement
            this.password = new Random().Next(1, 5000).ToString();
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

