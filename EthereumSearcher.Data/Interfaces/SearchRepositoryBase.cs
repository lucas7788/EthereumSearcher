using EthereumSearcher.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EthereumSearcher.Data.Interfaces
{
    public abstract class SearchRepositoryBase<T> : ISearchRepository<T> where T : TransactionBase
    {
        public abstract Task<IList<T>> GetTransactionsAsync(string searchAddress, ulong blockNumber);

    }
}
