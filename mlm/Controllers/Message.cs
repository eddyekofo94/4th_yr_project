using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using mlm.Controllers;

namespace mlm
{
    public class Message
    {
        public string MessageTime { get; set; }
        public string MessageText { get; set; }
        public string MessageTextTranslated{get; set;}

        public void TranslateText(Message msgIn)
        {
            if (msgIn == null)
            {
                throw new ArgumentNullException();
            }

            AuthToken authToken = AuthToken.Instance;   // creates the instance from the singleton
            // string text = "Hello, I am trying to translate";
            string from = "en";
            string to = "fr";

            // string text;

            string uri = "https://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + HttpUtility.UrlEncode(msgIn.MessageText) + "&from=" + from + "&to=" + to;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Headers.Add("Authorization", AuthToken.Instance.GetTokenAsync());

            using (WebResponse response = httpWebRequest.GetResponse())
            using (Stream stream = response.GetResponseStream())
            {
                DataContractSerializer dcs = new DataContractSerializer(Type.GetType("System.String"));
                string translation = (string)dcs.ReadObject(stream);
            

                MessageTextTranslated = translation;
            }
        }
        
}
    
}