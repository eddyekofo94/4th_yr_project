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
        
        // curl -i -H "Content-Type: application/json" -d {"MessageText" : "Hello Terry this is not working"} http://localhost:5000/api/Message/
        
        // Class constructor
        public Message(string msgIn, long timeIn)
        {
            // Date format "02:14 28-Oct-17"
            // TODO: Date according to each region?
//            MessageTime = DateTime.UtcNow.ToString("HH:mm dd-MMM-yy", DateTimeFormatInfo.InvariantInfo);
            // Translate's JavaScript's time to C#'s DateTime.
            MessageTime =  new DateTime(1970, 1, 1).AddTicks(timeIn * 10000).ToString("HH:mm ddd dd-MM-yyyy ", DateTimeFormatInfo.InvariantInfo);
            MessageText = msgIn;
            MessageTranslated = TranslateText(MessageText);
        }

        public string MessageTime { get; set; }
        public string MessageText { get; set; }
        public string MessageTranslated { get; set; }

        // Translates the text to the desired language
        //TODO: Change to the preffered language.
        public static string TranslateText(string msgIn)
        {
            
            // If the input is null somehow, throw an exception
            if (msgIn == null)
            {
                throw new ArgumentNullException();
            }

            // creates the instance from the AuthToken singleton
            AuthToken authToken = AuthToken.Instance;

            //TODO: Change accoring to whichever language the user desires
            string from = "en";
            string to = "fr";
            
            //The translator API is used and the from & to determines the translation
            string uri = "https://api.microsofttranslator.com/v2/Http.svc/Translate?text=" +
                         HttpUtility.UrlEncode(msgIn) + "&from=" + from + "&to=" + to;
            HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(uri);
            httpWebRequest.Headers.Add("Authorization", AuthToken.Instance.GetTokenAsync());

            using (WebResponse response = httpWebRequest.GetResponse())
            using (Stream stream = response.GetResponseStream())
            {
                DataContractSerializer dcs = new DataContractSerializer(Type.GetType("System.String"));
                string translation = (string) dcs.ReadObject(stream);

                //This should return the translated text
                return translation;
            }
        }

        public override string ToString()
        {
            return string.Format("Message: {0}", MessageText);
        }
    }
}