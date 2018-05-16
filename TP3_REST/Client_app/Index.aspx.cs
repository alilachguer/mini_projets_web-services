using System;
using Client_app.App_Code;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using RestSharp;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    public List<Livre> livres = new List<Livre>();
    public Livre livre = new Livre();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public string getContent(string url)
    {
        var client = new RestClient(url);
        var request = new RestRequest("", Method.GET);
        IRestResponse response = client.Execute(request);
        return response.Content;
    }

    protected void button_livre_isbn_Click(object sender, EventArgs e)
    {
        
        if (livre_isbn.Text == string.Empty)
        {
            var content = getContent("http://localhost:49616/api/Biblio/");
            livres = JsonConvert.DeserializeObject<List<Livre>>(content);
        }
        else
        {
            var content = getContent("http://localhost:49616/api/Biblio/livres/isbn/" + livre_isbn.Text);
            if (content != "")
            {
                livre = JsonConvert.DeserializeObject<Livre>(content);
                message.Text = "";
            }
                
            else
                message.Text = "livre not found";
        }
    }

    protected void button_livre_auteur_Click(object sender, EventArgs e)
    {
        Rest_Client restClient = new Rest_Client();
        if (livre_auteur.Text == string.Empty)
        {
            var content = getContent("http://localhost:49616/api/Biblio/");
            livres = JsonConvert.DeserializeObject<List<Livre>>(content);
        }
        else
        {
            var content = getContent("http://localhost:49616/api/Biblio/livres/auteur/" + livre_auteur.Text);
            if (content != "")
            {
                livres = JsonConvert.DeserializeObject<List<Livre>>(content);
                message.Text = "";
            }
            else
                message.Text = "auteur does not exist";
        }
    }


    protected void getLivre_Click(object sender, CommandEventArgs e)
    {
        Response.Redirect("Book.Aspx?isbn=" + e.CommandArgument.ToString());
    }
}