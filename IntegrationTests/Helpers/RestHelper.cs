using Gherkin;
using IntegrationTests.Config;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.RestHelpers
{

    public interface IRestHelper
    {
        RestResponse GetQuery(string query);
        
    }

    internal class RestHelper : IRestHelper
    {
        private readonly TestSettings _testSettings;
  

        public RestHelper(TestSettings testSettings)
        {
            _testSettings = testSettings;
        }

        public RestResponse GetQuery(string query)
        {
            RestClient restClient = new RestClient(_testSettings.ApiUrl);
            var request = new RestRequest(query, Method.Get);
            request.AddHeader("cache-control", "no-cache");

            var response = restClient.Execute(request);
            return response;
        }


    }
}
