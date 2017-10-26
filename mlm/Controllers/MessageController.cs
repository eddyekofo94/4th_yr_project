using System;
using System.Net;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.IO;
using mlm;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mlm.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
       
        [HttpPost]
        public string SendText(string msgIn)
        {
            
            Message msg = new Message();
            Console.WriteLine("Texy Message: "+msgIn);
            
//            string textIn = "Hello, testing this";

            if (!ModelState.IsValid)            {
//                return false;
                return "Error: Must enter a text";
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
                Debug.WriteLine(translation);
                msg.MessageTextTranslated = translation;
                Console.WriteLine(msg.MessageTextTranslated);
//                return true;
                return translation;
            }

        }   // End of SendText methos!!

        [HttpGet("[action]")]
        public string Get(int id)
        {
            return "value";
        }
        
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
