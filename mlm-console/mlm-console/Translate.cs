using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Web;

namespace mlm_console
{
    public class Translate
    {
        public static void TextTranslate(String authToken)
        {
//            string text = "Hello, I am trying to translate";
            string from = "en";
            string to = "fr";
            
            string text;
            Console.WriteLine("Enter one or more lines of text (press CTRL+C to exit):");
            Console.WriteLine();
            do { 
//                Console.Write("   ");
                text = Console.ReadLine();
//                if (text != null) 
//                    Console.WriteLine("      => " + text);
            
                string uri = "https://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + HttpUtility.UrlEncode(text) + "&from=" + from + "&to=" + to;
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                httpWebRequest.Headers.Add("Authorization", authToken);
                using (WebResponse response = httpWebRequest.GetResponse())
                using (Stream stream = response.GetResponseStream())
                {
                    DataContractSerializer dcs = new DataContractSerializer(Type.GetType("System.String"));
                    string translation = (string)dcs.ReadObject(stream);
//                    Console.WriteLine("Translation for source text '{0}' from {1} to {2} is", text, "en", "fr");
                    Console.WriteLine("{0}: {1} => {2}: {3}", from, text, to, translation);
                }
            } while (text != null);   
            Console.Write("You've exited"); // Not working, must exit properly

        }
        
    }
}