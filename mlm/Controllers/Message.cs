using System;
using System.Globalization;
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
//        curl -i -H "Content-Type: application/json" -d {'MessageText':'Hello, this is a test'} http://localhost:5000/api/Message/
//   curl -i -H "Content-Type: application/json" -d {"MessageText" : "Hello Terry this is not working" http://localhost:5000/api/Message/

        public Message(string msgIn)
        {
            MessageTime = DateTime.UtcNow.ToString("HH:mm dd-MMM-yy", DateTimeFormatInfo.InvariantInfo);
//            Console.WriteLine(MessageTime.ToString("d", DateTimeFormatInfo.InvariantInfo));

            MessageText = msgIn;
            MessageTranslated = TranslateText(MessageText);
        }
 
        public string MessageTime
        {
            get;
            set;
        }

        public string MessageText { get; set; }
        public string MessageTranslated{ get; set;}
        
        // Translates the text to the desired language
        //TODO: Change to the preffered language.
        public static string TranslateText(string msgIn)
        {
            if (msgIn == null)
            {
                return "Error, input can't be empty";
            }

            AuthToken authToken = AuthToken.Instance;   // creates the instance from the singleton

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
                Console.WriteLine(translation);
               return translation;
            }
        }

        public override string ToString()
        {
            return string.Format("Message: {0}", MessageText);
        }
    }
    
}