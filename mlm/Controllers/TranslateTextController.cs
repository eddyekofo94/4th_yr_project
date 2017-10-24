using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace mlm.Controllers
{
    [Route("api/[controller]")]
    public class TranslateText : Controller
    {
        public static void TextTranslate()
        {
            AuthToken authToken = AuthToken.Instance;   // creates the instance from the singleton
            string text = "Hello, I am trying to translate";
            string from = "en";
            string to = "fr";

            // string text;

            string uri = "https://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + HttpUtility.UrlEncode(text) + "&from=" + from + "&to=" + to;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Headers.Add("Authorization", authToken.GetAccessToken());
            using (WebResponse response = httpWebRequest.GetResponse())
            using (Stream stream = response.GetResponseStream())
            {
                DataContractSerializer dcs = new DataContractSerializer(Type.GetType("System.String"));
                string translation = (string)dcs.ReadObject(stream);
            }
        }

//        [HttpGet("[action]")]
//        public Message MyMessage()
//        {
//            return _message;
//        }

    }   // end of TranslateText class

}
