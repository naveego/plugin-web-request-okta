using System.Net.Http;
using PluginWebRequestOkta.DataContracts;
using PluginWebRequestOkta.Helper;

namespace PluginWebRequestOkta.API.Factory
{
    public class ApiClientFactory: IApiClientFactory
    {
        private HttpClient Client { get; set; }

        public ApiClientFactory(HttpClient client)
        {
            Client = client;
        }

        public IApiClient CreateApiClient(ConfigureWriteFormData settings, Settings connectSettings)
        {
            return new ApiClient(Client, settings, connectSettings);
        }

        public IApiClient CreateApiClient(Settings connectSettings)
        {
            return new ApiClient(Client, connectSettings);
        }
    }
}