using System;
using System.IO;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Web;
using mlm.Controllers;

namespace mlm
{
    public class Message
    {
        public Message(string msgIn)
        {
            MessageTime = DateTime.Now;
            MessageText = msgIn;
            MessageTextTranslated = TranslateText(msgIn);
        }
        public DateTime MessageTime { get; set; }
        public string MessageText { get; set; }
        public string MessageTextTranslated{ get; set;}

        public string TranslateText(string msgIn)
        {
            MessageTextTranslated = msgIn;
            if (msgIn == null)
            {
                return "Error, input can't be empty";
            }

            AuthToken authToken = AuthToken.Instance;   // creates the instance from the singleton
            // string text = "Hello, I am trying to translate";
            string from = "en";
            string to = "fr";

            // string text;

            string uri = "https://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + HttpUtility.UrlEncode(msgIn) + "&from=" + from + "&to=" + to;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Headers.Add("Authorization", AuthToken.Instance.GetTokenAsync());

            using (WebResponse response = httpWebRequest.GetResponse())
            using (Stream stream = response.GetResponseStream())
            {
                DataContractSerializer dcs = new DataContractSerializer(Type.GetType("System.String"));
                string translation = (string)dcs.ReadObject(stream);
            //This should return the translated text
               return translation;
            }
        }
        
}
    
}