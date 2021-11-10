using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Naveego.Sdk.Logging;
using Newtonsoft.Json;
using PluginWebRequestOkta.DataContracts;
using PluginWebRequestOkta.Helper;

namespace PluginWebRequestOkta.API.Factory
{
    public class ApiAuthenticator: IApiAuthenticator
    {
        private HttpClient Client { get; set; }
        private Settings ConnectSettings { get; set; }
        private string Token { get; set; }
        private DateTime ExpiresAt { get; set; }

        public ApiAuthenticator(HttpClient client, Settings connectSettings)
        {
            Client = client;
            ConnectSettings = connectSettings;
            ExpiresAt = DateTime.Now;
            Token = "";
        }

        public async Task<string> GetToken()
        {
            // check if token is expired or will expire in 5 minutes or less
            if (DateTime.Compare(DateTime.Now.AddMinutes(5), ExpiresAt) >= 0)
            {
                return await GetNewToken();
            }

            return Token;
        }

        private async Task<string> GetNewToken()
        {
            var formData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
            };
            
            foreach (var keyValue in ConnectSettings.RequestBody)
            {
                formData.Add(new KeyValuePair<string, string>(keyValue.Key, keyValue.Value));
            }

            var body = new FormUrlEncodedContent(formData);
                
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(ConnectSettings.TokenUrl),
                Content = body
            };

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
            var authenticationString = $"{ConnectSettings.ClientId}:{ConnectSettings.ClientSecret}";
            var base64EncodedAuthenticationString =
                Convert.ToBase64String(Encoding.UTF8.GetBytes(authenticationString));
                
            request.Headers.Authorization =
                new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);

            var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();
                    
            var content = JsonConvert.DeserializeObject<TokenResponse>(await response.Content.ReadAsStringAsync());
                    
            // update expiration and saved token
            ExpiresAt = DateTime.Now.AddSeconds(content.ExpiresIn);
            Token = content.AccessToken;

            return Token;
        }
    }
}