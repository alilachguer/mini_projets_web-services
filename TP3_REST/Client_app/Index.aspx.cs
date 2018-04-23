using System;
using Client_app.App_Code;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using RestSharp;


public partial class Index : System.Web.UI.Page
{
    public List<Livre> livres = new List<Livre>();
    public Livre livre = new Livre();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void button_livre_isbn_Click(object sender, EventArgs e)
    {
        var client = new RestClient("http://localhost:49616/api/Biblio/");
        var request = new RestRequest("", Method.GET);

        IRestResponse response = client.Execute(request);
        var content = response.Content;

        livres = JsonConvert.DeserializeObject<List<Livre>>(content);


        //Rest_Client restClient = new Rest_Client();
        //if (livre_isbn.Text == string.Empty)
        //{
        //    restClient.endPoint = "http://localhost:49616/api/Biblio/" + livre_isbn.Text;
        //    livres = JsonConvert.DeserializeObject<List<Livre>>(restClient.makeRequest());
        //}
        //else
        //{
        //    restClient.endPoint = "http://localhost:49616/api/Biblio/livres/isbn/" + livre_isbn.Text;
        //    livre = JsonConvert.DeserializeObject<Livre>(restClient.makeRequest());
        //}
    }

    protected void button_livre_auteur_Click(object sender, EventArgs e)
    {
        Rest_Client restClient = new Rest_Client();
        if (livre_auteur.Text == string.Empty)
        {
            restClient.endPoint = "http://localhost:49616/api/Biblio/" + livre_isbn.Text;
            livres = JsonConvert.DeserializeObject<List<Livre>>(restClient.makeRequest());
        }
        else
        {
            restClient.endPoint = "http://localhost:49616/api/Biblio/livres/auteur/" + livre_auteur.Text;
            livres = JsonConvert.DeserializeObject<List<Livre>>(restClient.makeRequest());
        }
    }
}