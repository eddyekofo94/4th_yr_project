using System;
using System.ComponentModel.DataAnnotations;
// using System.Web.Http.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace mlm.Controllers
{
    // TODO: implement all the APIs
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        // The message sent to be translated by the user
        public class MessageSent
        {
            [Required]    // This attribute is required
            public string MessageText { get; set; }
            public long MessageTime { get; set; }
        }

        /*
         * In order for binding to happen the class must have a public
         * default constructor and member to be bound must be public
         * writable properties. When model binding happens the class
         * will only be instantiated using the public default constructor,
         * then the properties can be set.
         */
        [HttpPost]
        // [Produces(typeof(Message))]
        public IActionResult SendText([FromBody] MessageSent msgIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            /*
             * You can query for model state errors by checking
             * the ModelState.IsValid property
             */
            // The Message Buble is the data returned from this
            // POST request.
            Message msg = new Message(msgIn.MessageText, msgIn.MessageTime);
            return Ok(msg);
        } // End of SendText methos!!

        // TODO: Make a list of messages and be able to retrieve them
        [HttpGet("[action]")]
        public string GetMsg(int id)
        {
            return "value";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void PutMsg(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeleteMsg(int id)
        {
        }
    }
}