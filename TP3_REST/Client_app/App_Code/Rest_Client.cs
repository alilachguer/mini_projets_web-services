using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

/// <summary>
/// Description résumée de RestClient
/// </summary>
/// 

public enum httpVerb
{
    GET, POST, PUT, DELETE
}

public class Rest_Client
{

    public string endPoint { get; set; }
    public httpVerb httpMethod { get; set; }
    public string postJSON { get; set; }

    public Rest_Client()
    {
        endPoint = string.Empty;
        httpMethod = httpVerb.GET;
    }

    public string makeRequest()
    {
        string strResponseValue = string.Empty;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
        request.Method = httpMethod.ToString();
        

        //********* NEW CODE TO SUPPORT POSTING *********
        if (request.Method == "POST" && postJSON != string.Empty)
        {
            request.ContentType = "application/json"; //Really Important
            using (StreamWriter swJSONPayload = new StreamWriter(request.GetRequestStream()))
            {
                swJSONPayload.Write(postJSON);
                swJSONPayload.Close();
            }
        }

        HttpWebResponse response = null;

        try
        {
            response = (HttpWebResponse)request.GetResponse();
            //Proecess the resppnse stream... (could be JSON, XML or HTML etc..._
            using (Stream responseStream = response.GetResponseStream())
            {
                if (responseStream != null)
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        strResponseValue = reader.ReadToEnd();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
        }
        finally
        {
            if (response != null)
            {
                ((IDisposable)response).Dispose();
            }
        }
        return strResponseValue;
    }
}