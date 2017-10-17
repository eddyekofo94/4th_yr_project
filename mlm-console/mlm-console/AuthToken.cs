using System;
using System.Net;
//using System.Web.Http;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;

namespace mlm_console
{
    public class AuthToken
    {
        private static AuthToken instance;
        private AuthToken(){}
        
        public static AuthToken Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new AuthToken();
                }
                return instance;
            }
        }
        
        // URL of the token service
        private static readonly Uri ServiceUrl = new Uri("https://api.cognitive.microsoft.com/sts/v1.0/issueToken");
        
        // Name of header used to pass the subscription key to the token service
        private const string OcpApimSubscriptionKeyHeader = "Ocp-Apim-Subscription-Key";
        
        /// After obtaining a valid token, this class will cache it for this duration.
        /// Use a duration of 5 minutes, which is less than the actual token lifetime of 10 minutes.
        private static readonly TimeSpan TokenCacheDuration = new TimeSpan(0, 5, 0);
        
        /// Cache the value of the last valid token obtained from the token service.
        private string _storedTokenValue = string.Empty;
        
        /// When the last valid token was obtained.
        private DateTime _storedTokenTime = DateTime.MinValue;

        /// Gets the subscription key.
        public string SubscriptionKey { get; set; }
        
        /// Gets the HTTP status code for the most recent request to the token service.
        public HttpStatusCode RequestStatusCode { get; private set; }
        
        /// <param name="key">Subscription key to use to get an authentication token.</param>
        public void AzureAuthToken(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key), "A subscription key is required");
            }

            this.SubscriptionKey = key;    // Gave an error there must be a setter, added it where it is initialised.
            this.RequestStatusCode = HttpStatusCode.InternalServerError;

        }
        
        public async Task<string> GetAccessTokenAsync()
        {
            if (string.IsNullOrWhiteSpace(this.SubscriptionKey))
            {
                return string.Empty;
            }

            // Re-use the cached token if there is one.
            if ((DateTime.Now - _storedTokenTime) < TokenCacheDuration)
            {
                return _storedTokenValue;
            }

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = ServiceUrl;
                request.Content = new StringContent(string.Empty);
                request.Headers.TryAddWithoutValidation(OcpApimSubscriptionKeyHeader, this.SubscriptionKey);
                client.Timeout = TimeSpan.FromSeconds(2);
                var response = await client.SendAsync(request);
                this.RequestStatusCode = response.StatusCode;
                response.EnsureSuccessStatusCode();
                var token = await response.Content.ReadAsStringAsync();
                _storedTokenTime = DateTime.Now;
                _storedTokenValue = "Bearer " + token;
                return _storedTokenValue;
            }
        }
        
    }
}