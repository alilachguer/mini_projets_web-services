using Client_app.App_Code;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{

    public Livre livre = new Livre();
    public string res = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ajouter_livre_Click(object sender, EventArgs e)
    {
        Rest_Client restClient = new Rest_Client();
        restClient.endPoint = "http://localhost:49616/api/Biblio/";

        restClient.httpMethod = httpVerb.POST;
        //restClient.postJSON = titre.Text;
        string json = "{" + "\"isbn\":" + 11111 + ",\"titre\": \"livre ali\",\"nbExemplaires\": " + 12 + ",\"auteur\": \"ali\",\"editeur\": \"livre de poche\",\"commentaires\": []}";
        restClient.postJSON = json;

        //livre = JsonConvert.DeserializeObject<Livre>(restClient.makeRequest());
        res = restClient.makeRequest();
    }
}