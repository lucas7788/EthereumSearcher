using EthereumSearcher.Common.Models;
using EthereumSearcher.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Nethereum.Web3;

namespace EthereumSearcher.Data
{
    public class EthereumRepository : SearchRepositoryBase<EthereumTransaction> 
    {
        private readonly IConfiguration _configurationManager;
        private readonly IHttpClientFactory _httpClientFactory;

        public EthereumRepository(IConfiguration configurationManager,
                                  IHttpClientFactory httpClientFactory) : base("ethereumApi")
        {
            _configurationManager = configurationManager;
            _httpClientFactory = httpClientFactory;
        }

        public override async Task<IList<EthereumTransaction>> GetTransactionsAsync(string searchAddress, long blockNumber)
        {
            //use getBlockByNumber to get list of transactions back on the block
            var web3 = new Web3("https://mainnet.infura.io/v3/7238211010344719ad14a89db874158c");

            // Check the balance of one of the accounts provisioned in our chain, to do that, 
            // we can execute the GetBalance request asynchronously:
            var balance = await web3.Eth.GetBalance.SendRequestAsync("0xde0b295669a9fd93d5f28d9ec85e40f4cb697bae");
            Console.WriteLine("Balance of Ethereum Foundation's account: " + balance.Value);
            return null;
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://mainnet.infura.io/qhggowRXK7HIgXB0NEyw");
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //var requestBody = new
            //{
            //    jsonrpc = "2.0",
            //    method = "eth_blockNumber",
            //    @params = new int[] { },
            //    id = 83,
            //};

            //    HttpResponseMessage apiResponse = await client.PostAsJsonAsync(client.BaseAddress, requestBody);

            ////    if (apiResponse.IsSuccessStatusCode)
            ////    {
            ////        var documentResponse = await apiResponse.Content.ReadAsStringAsync();
            ////        dynamic response = JsonConvert.DeserializeObject(documentResponse);
            ////    }
            ////}
        }

        //private Task<IList<EthereumTransaction>> QueryBlockchain(string methodName)
        //{
        //    using (var httpClient = _httpClientFactory.CreateClient("ethereumApi"))
        //    {

        //    }
        //    var values = new Dictionary<string, string>
        //    {
        //       { "param1", "value1" },
        //       { "param2", "value2" }
        //    };
        //    *var content = new FormUrlEncodedContent(values);
        //    var response = await client.PostAsync("https://mainnet.infura.io/qhggowRXK7HIgXB0NEyw", content);
        //    var responseString = await response.Content.ReadAsStringAsync();
        //}

    }
}
