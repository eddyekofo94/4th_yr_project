using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mlm_console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string keyToken = "8fcf5d73e4e94421830b6516342ef7be";
            
            AuthToken.Instance.AzureAuthToken(keyToken);

            Task<string> token = AuthToken.Instance.GetAccessTokenAsync();

            token.GetAwaiter().OnCompleted(() =>
            {
                Console.WriteLine("Token : " + token.Result);
            });
            token.Wait();
            
            //Translate text
            Translate.TextTranslate(token.Result);
        }
    }
}