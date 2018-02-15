using System.ComponentModel.DataAnnotations;

namespace mlm.Models.ChatViewModel
{
    public class NewMessageViewModel
    {
        [Required]
        public string Content { get; set; }

    }
    // which will be sent to the server, from the client side
}