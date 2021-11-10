using System.Collections.Generic;
using PluginWebRequestOkta.Helper;
using Xunit;

namespace PluginWebRequestOktaTest.Helper
{
    public class SettingsTest
    {
        [Fact]
        public void ValidateValidTest()
        {
            // setup
            var settings = new Settings
            {
                ClientId = "Client",
                ClientSecret = "Secret",
                TokenUrl = "URL",
                RequestBody = new List<RequestBodyKeyValue>()
            };

            // act
            settings.Validate();

            // assert
        }
    }
}