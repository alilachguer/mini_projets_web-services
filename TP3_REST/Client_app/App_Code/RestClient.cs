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

public class RestClient
{

    public string endPoint { get; set; }
    public httpVerb httpMethod { get; set; }

    public RestClient()
    {
        endPoint = string.Empty;
        httpMethod = httpVerb.GET;
    }

    public string makeRequest()
    {
        string response = string.Empty;

        HttpWebRequest request = (HttpWebRequest) WebRequest.Create(endPoint);
        request.Method = httpMethod.ToString();

        using (HttpWebResponse res = (HttpWebResponse) request.GetResponse())
        {
            if(res.StatusCode != HttpStatusCode.OK)
            {
                throw new ApplicationException("error: " + res.StatusCode.ToString());
            }

            using (Stream responseStream = res.GetResponseStream())
            {
                if(responseStream != null)
                {
                    using(StreamReader reader = new StreamReader(responseStream))
                    {
                        response = reader.ReadToEnd();
                    }
                }
            }
        }

        return response;
    }
}