using PluginWebRequestOkta.DataContracts;
using PluginWebRequestOkta.Helper;

namespace PluginWebRequestOkta.API.Factory
{
    public interface IApiClientFactory
    {
        IApiClient CreateApiClient(ConfigureWriteFormData settings, Settings connectSettings);
        IApiClient CreateApiClient(Settings connectSettings);
    }
}