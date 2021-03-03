using EthereumSearcher.Common;
using EthereumSearcher.Common.Models;
using EthereumSearcher.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthereumSearcher.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EthereumController : ControllerBase
    {
        private readonly ILogger<EthereumController> _logger;
        private readonly ISearchService _searchService;

        public EthereumController(ILogger<EthereumController> logger,
            ISearchService searchService)
        {
            _logger = logger;
            _searchService = searchService;
        }

        /// <summary>
        /// Search the Ethereum Blockchain for transactions associated with an address on a specific block
        /// </summary>
        /// <param name="searchAddress"></param>
        /// <param name="blockNumber"></param>
        /// <returns></returns>
        [Route("eth/block")]
        [HttpGet]
        public async Task<IEnumerable<EthereumTransactionDto>> SearchAddresses([FromQuery] string searchAddress, [FromQuery] ulong blockNumber)
        {
            return await _searchService.SearchEthereumTransactionsAsync(searchAddress, blockNumber);
        }
        //todo: fix routing
    }
}
