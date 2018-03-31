using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWebsite
{
    public partial class RechercheLivre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void recherche_Click(object sender, EventArgs e)
        {
            BiblioService.ServiceSoapClient soapClient = new BiblioService.ServiceSoapClient();
            int ISBN;

            if(isbn.Text != string.Empty)
            {
                if (int.TryParse(isbn.Text, out ISBN))
                {
                    if (soapClient.LivreExists(Int32.Parse(isbn.Text)))
                    {
                        resultat.Text = "isbn : " + soapClient.GetLivreByISBN(Int32.Parse(isbn.Text)).ISBN.ToString();
                        resultat.Text += ", titre: " + soapClient.GetLivreByISBN(Int32.Parse(isbn.Text)).Titre.ToString();
                        resultat.Text += ", auteur: " + soapClient.GetLivreByISBN(Int32.Parse(isbn.Text)).Auteur.ToString();
                        resultat.Text += ", editeur: " + soapClient.GetLivreByISBN(Int32.Parse(isbn.Text)).Editeur.ToString();
                        resultat.Text += ", nb exemplaires: " + soapClient.GetLivreByISBN(Int32.Parse(isbn.Text)).NbExemplaires.ToString();
                    }
                }
                else
                {
                    resultat.Text = "le livre n'existe pas";
                }

            } else if(auteur.Text != string.Empty)
            {
                if(soapClient.GetLivreByAuteur(auteur.Text) != null)
                {
                    int isbn = soapClient.GetLivreByAuteur(auteur.Text).ISBN;
                    resultat.Text = "isbn : " + soapClient.GetLivreByISBN(isbn).ISBN.ToString();
                    resultat.Text += ", titre: " + soapClient.GetLivreByISBN(isbn).Titre.ToString();
                    resultat.Text += ", auteur: " + soapClient.GetLivreByISBN(isbn).Auteur.ToString();
                    resultat.Text += ", editeur: " + soapClient.GetLivreByISBN(isbn).Editeur.ToString();
                    resultat.Text += ", nb exemplaires: " + soapClient.GetLivreByISBN(isbn).NbExemplaires.ToString();

                }
                else
                {
                    resultat.Text = "le livre n'existe pas";
                }

            }
            else
            {
                resultat.Text = "input vide";
            }

        }
    }
}