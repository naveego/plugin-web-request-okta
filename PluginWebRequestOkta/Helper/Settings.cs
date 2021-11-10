using System;
using System.Collections.Generic;

namespace PluginWebRequestOkta.Helper
{
    public class Settings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string TokenUrl { get; set; }
        public List<RequestBodyKeyValue> RequestBody { get; set; } = new List<RequestBodyKeyValue>();

        /// <summary>
        /// Validates the settings input object
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(ClientId))
            {
                throw new Exception("the ClientId property must be set");
            }
            
            if (string.IsNullOrWhiteSpace(ClientSecret))
            {
                throw new Exception("the ClientSecret property must be set");
            }
            
            if (string.IsNullOrWhiteSpace(TokenUrl))
            {
                throw new Exception("the TokenUrl property must be set");
            }
        }
    }
    
    public class RequestBodyKeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}