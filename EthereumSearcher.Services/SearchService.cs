using EthereumSearcher.Common.Models;
using EthereumSearcher.Data.Interfaces;
using EthereumSearcher.Services.Interfaces;
using System.Collections.Generic;
using
    Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using AutoMapper;

namespace EthereumSearcher.Services
{
    public class SearchService : ISearchService
    {
        private readonly ISearchRepository<EthereumTransaction> _ethereumRepository;
        private readonly IMapper _mapper;
        

        public SearchService(ISearchRepository<EthereumTransaction> ethereumRepository,
                             IMapper mapper)
        {
            _ethereumRepository = ethereumRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Searches the ethereum blockchain for transactions involving a specific address in a specific block
        /// </summary>
        /// <param name="searchAddress"></param>
        /// <param name="blockNumber"></param>
        /// <returns></returns>
        public async Task<IEnumerable<EthereumTransactionDto>> SearchEthereumTransactionsAsync(string searchAddress, long blockNumber)
        {
            var response = await _ethereumRepository.GetTransactionsAsync(searchAddress, blockNumber);
            Console.WriteLine();
            //map it
            //_mapper.Map
            
            return null;
        }
    }
}
