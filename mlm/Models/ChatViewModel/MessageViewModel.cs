using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using mlm.Models.ChatModel.mlm;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.Internal.Networking;

// This class is for the View, we don't wan
// t all the data to be sent to the user

namespace mlm.Models.ChatViewModel
{
    public class MessageViewModel
    {
        public MessageViewModel()
        {
        }

        public MessageViewModel(MessageModel msg)
        {
            Content = msg.MessageText;
            ContentTranslated = msg.MessageTranslated;
            Author = msg.User.UserName;
            Timestamp = msg.DateCreated;
        }

        [Required]
        public string Content { get; set; }
        [Required]
        public string ContentTranslated { get; set; }

        [Required]
       
        public string Author { get; set; }    //    name of the author

        [Required]
        [DataType(DataType.Date)]
        public DateTime Timestamp { get; set; }
    }
}