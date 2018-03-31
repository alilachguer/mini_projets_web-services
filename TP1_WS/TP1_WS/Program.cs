using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Xml;

namespace TP1_WS
{
    class Program
    {
        static void Main(string[] args)
        {

            //le programme rend les villes d'un pays entré par l'utilisateur
            globalweather.GlobalWeatherSoapClient soapClient = new globalweather.GlobalWeatherSoapClient();
            Console.Write("entrez le nom d'un pays: ");
            string pays = Console.ReadLine();
            string cities = soapClient.GetCitiesByCountry(pays);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(cities);
            
            XmlNodeList elemList = doc.GetElementsByTagName("City");
            if (elemList.Count == 0)
                Console.Write("donnees introuvables");
            else
            {
                Console.WriteLine("les villes sont: ");
                for (int i = 0; i < elemList.Count; i++)
                {
                    Console.WriteLine(elemList[i].InnerXml);
                }
            }

            //la fonction GetWeather ne marche pas
            Console.WriteLine(soapClient.GetWeather("Beijing", "china"));
            
                
        }
    }
}
