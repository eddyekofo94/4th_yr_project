using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using mlm.Controllers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using mlm;

namespace mlm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        
        public async Task<string> GetTokenAsync()  
        {
            string _keyToken = "8fcf5d73e4e94421830b6516342ef7be";

            AuthToken.Instance.AzureAuthToken(_keyToken);

            Task<string> token = AuthToken.Instance.GetAccessTokenAsync();

            token.GetAwaiter().OnCompleted(() =>
            {
                Console.WriteLine("Token : " + token.Result);
            });
            token.Wait();

            return token.Result;
        }
    }
}
