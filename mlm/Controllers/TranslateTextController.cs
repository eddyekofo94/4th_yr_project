using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace mlm.Controllers
{
    [Route("api/[controller]")]
    public class TextTranslate : Controller
    {
        // [HttpPost]
        // public string TextTranslate([FromBody] string textIn)
        // {
        //     if (textIn == null)
        //     {
        //         return "Error: Must enter a text";
        //     }

        //     AuthToken authToken = AuthToken.Instance;   // creates the instance from the singleton
        //     // string text = "Hello, I am trying to translate";
        //     string from = "en";
        //     string to = "fr";

        //     // string text;

        //     string uri = "https://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + HttpUtility.UrlEncode(textIn) + "&from=" + from + "&to=" + to;
        //     HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
        //     httpWebRequest.Headers.Add("Authorization", authToken.GetAccessToken());

        //     using (WebResponse response = httpWebRequest.GetResponse())
        //     using (Stream stream = response.GetResponseStream())
        //     {
        //         DataContractSerializer dcs = new DataContractSerializer(Type.GetType("System.String"));
        //         string translation = (string)dcs.ReadObject(stream);
            

        //         return translation;
        //     }

        // }   // End of TranslateText methos!!

        //        [HttpGet("[action]")]
        //        public Message MyMessage()
        //        {
        //            return _message;
        //        }

        // GET api/values/5
        [HttpGet("[action]")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        // [HttpPost]
        // public IActionResult SendText()
        // {
            
        // }

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

    }   // end of TranslateText class

}