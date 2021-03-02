using EthereumSearcher.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EthereumSearcher.Data.Interfaces
{
    public abstract class SearchRepositoryBase<T> : ISearchRepository<T> where T : TransactionBase
    {
        internal string _httpClientName { get; set; }
        public SearchRepositoryBase(string httpClientName)
        {
            _httpClientName = httpClientName;
        }
        
        public abstract Task<IList<T>> GetTransactionsAsync(string searchAddress, long blockNumber);

    }
}
