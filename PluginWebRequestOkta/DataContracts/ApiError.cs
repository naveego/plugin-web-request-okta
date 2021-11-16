using Newtonsoft.Json;

namespace PluginWebRequestOkta.DataContracts
{
    public class ApiError
    {
        [JsonProperty("error")]
        public string Error { get; set; }
        
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}