using System;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Translate.v2;

namespace mlm_console
{
    class Program
    {
        static void Main(string[] args)
        {

            GoogleCredential credential = GoogleCredential.GetApplicationDefault();

            var compute = new ComputeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential
            });
            var message = "This is some html text to <strong>translate</strong>!";
            string targetLanguage = "fr";
            string sourceLanguage = null; // automatically detected
            var client = Google.Cloud.Translation.V2.TranslationClient.Create();
            try{

            var response = client.TranslateHtml(message, targetLanguage, sourceLanguage);
            Console.WriteLine(response.TranslatedText);
            }catch(Exception ex){
                System.Console.WriteLine("Error: \n" + ex);
            }
        }
    }
}
