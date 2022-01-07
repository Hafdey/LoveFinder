using LoveFinder.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LoveFinder.Logic
{
    public class KanyeLogic
    {
        public static Quote GetRandomQuote()
        {
            Quote quote = new Quote();
            var url = Kanye.GenerateRandom();
            WebRequest request = HttpWebRequest.Create(url);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();
            quote = Newtonsoft.Json.JsonConvert.DeserializeObject<Quote>(json);
            return quote;
        }
    }
}
