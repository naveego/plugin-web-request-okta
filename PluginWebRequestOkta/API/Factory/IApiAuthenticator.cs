using System.Threading.Tasks;

namespace PluginWebRequestOkta.API.Factory
{
    public interface IApiAuthenticator
    {
        Task<string> GetToken();
    }
}