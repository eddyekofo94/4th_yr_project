using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Translate.v2;
using mlm.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace mlm.Models.ChatModel
{
//    public class MessageModel
//    {
//        
//    }


    namespace mlm
    {
        public class MessageModel
        {
            // curl -i -H "Content-Type: application/json" -d {"MessageText" : "Hello Terry this is not working"} http://localhost:5000/api/Message/

            // Class constructor
            public MessageModel(string msgIn)
            {
                DateCreated = DateTime.Now;
                MessageText = msgIn;
                MessageTranslated = TranslateText(MessageText);
            }

            [Key]
            public Guid MessageId { get; set; }

            [Required]
//            [ForeignKey("User")]    // SQLite does not support this
            public string UserId { get; set; }

            public ApplicationUser User { get; set; }

//            [Required]
            [DataType(DataType.Date)]
//            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public DateTime DateCreated { get; private set; }

            [Required]
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

                GoogleCredential credential = GoogleCredential.GetApplicationDefault();

                var compute = new ComputeService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential
                });
                // var message = "This is some html text to <strong>translate</strong>!";
                string targetLanguage = "fr";
                string sourceLanguage = null; // automatically detected
                var client = Google.Cloud.Translation.V2.TranslationClient.Create();
                try
                {
                    var response = client.TranslateHtml(msgIn, targetLanguage, sourceLanguage);
//                    Console.WriteLine(">>>>>>>>>>>>>>> The translatad text: " + response.TranslatedText);
                    return response.TranslatedText;
                }
                catch (Exception ex)
                {
                    return "Error: \n" + ex;
                }
            }

            public override string ToString()
            {
                return string.Format("Message: {0}", MessageText);
            }
        }
    }
}