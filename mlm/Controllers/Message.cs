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

namespace mlm
{
    public class Message
    {

        // curl -i -H "Content-Type: application/json" -d {"MessageText" : "Hello Terry this is not working"} http://localhost:5000/api/Message/

        // Class constructor
        public Message(string msgIn, long timeIn)
        {
            // Date format "02:14 28-Oct-17"
            // TODO: Date according to each region?
            //            MessageTime = DateTime.UtcNow.ToString("HH:mm dd-MMM-yy", DateTimeFormatInfo.InvariantInfo);
            // Translate's JavaScript's time to C#'s DateTime.
            MessageTime = new DateTime(1970, 1, 1).AddTicks(timeIn * 10000).ToString("HH:mm ddd dd-MM-yyyy ", DateTimeFormatInfo.InvariantInfo);
            MessageText = msgIn;
            MessageTranslated = TranslateText(MessageText);
        }

        public string MessageTime { get; set; }
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