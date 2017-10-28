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
//using System.Web.Http;
using Microsoft.AspNetCore.Mvc;

namespace mlm.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        public class MessageSent
        {
            public string MessageText { get; set; }
        }
        
        [HttpPost]
        public Message SendText([FromBody]MessageSent input)
        {
            Message msg = new Message(input.MessageText);
//            Debug.Write(Message.TranslateText(input.MessageText));
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
