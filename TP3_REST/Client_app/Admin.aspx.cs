using Client_app.App_Code;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{

    public Livre livre = new Livre();
    public string res = "res";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ajouter_livre_Click(object sender, EventArgs e)
    {
        var client = new RestClient("http://localhost:49616/api/Biblio/");
        var request = new RestRequest("", Method.POST);
        //request.RequestFormat = DataFormat.Json;
        Livre livre = new Livre(titre.Text, auteur.Text, edition.Text, Int32.Parse(isbn.Text), Int32.Parse(nbExemplaires.Text));

        string json = JsonConvert.SerializeObject(livre);
        //request.AddBody(livre);

        request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
        request.RequestFormat = DataFormat.Json;

        IRestResponse response = client.Execute(request);


        //client.ExecuteAsync(request, response => {
        //    Console.WriteLine(response.Content);
        //});

        this.res = response.Content;
        
    }
    
}