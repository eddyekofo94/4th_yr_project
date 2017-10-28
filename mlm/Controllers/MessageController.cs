using System;
using System.Net;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.IO;
using mlm;
using System.Threading.Tasks;
//using System.Web.Http;
using Microsoft.AspNetCore.Mvc;

namespace mlm.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        // The message sent to be translated by the user
        public class MessageSent
        {
            public string MessageText { get; set; }
        }
        
        [HttpPost]
        public Message SendText([FromBody]MessageSent input)
        {
            // Thr Message Buble is the data returned from this
            //post request.
            Message msg = new Message(input.MessageText);
            return msg;
        }   // End of SendText methos!!

        [Microsoft.AspNetCore.Mvc.HttpGet("[action]")]
        public string GetMsg(int id)
        {
            return "value";
        }
        
        // PUT api/values/5
        [Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
        public void PutMsg(int id, [Microsoft.AspNetCore.Mvc.FromBody] string value)
        {
        }

        // DELETE api/values/5
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public void DeleteMsg(int id)
        {
        }
    }
}
