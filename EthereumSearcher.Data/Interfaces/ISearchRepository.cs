using EthereumSearcher.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EthereumSearcher.Data.Interfaces
{
    public interface ISearchRepository<T> where T : TransactionBase
    {
        Task<IList<T>> GetTransactionsAsync(string searchAddress, long blockNumber);
    }
}
