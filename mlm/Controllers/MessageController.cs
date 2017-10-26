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
        public IActionResult SendText([FromBody]string input)
        {
//            input = "Hello, I am Testing";
            Message message = new Message(input);
            Console.WriteLine(message);
            return Json(message);
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
