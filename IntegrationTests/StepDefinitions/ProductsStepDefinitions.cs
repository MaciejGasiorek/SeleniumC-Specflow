using IntegrationTests.RestHelpers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace IntegrationTests.StepDefinitions
{
    [Binding]
    public sealed class ProductsStepDefinitions
    {
        private readonly IRestHelper _restHelper;
        private RestResponse _response;

        public ProductsStepDefinitions(IRestHelper restHelper)
        {
            _restHelper = restHelper;
        }

     

        [When(@"I send a Get request to get product lists")]
        public void WhenISendAGetRequestToGetProductLists()
        {
            _response = _restHelper.GetQuery("productsList");
        }

        [Then(@"I should get list of products and response should contains '([^']*)'")]
        public void ThenIShouldGetListOfProductsAndResponseShouldContains(string product)
        {
            Assert.NotNull(_response);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, _response.StatusCode);
            Assert.IsNotEmpty(_response.Content);

            Assert.IsTrue(_response.Content.Contains(product));
        }


    }
}
