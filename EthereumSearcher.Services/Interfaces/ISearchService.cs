using EthereumSearcher.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EthereumSearcher.Services.Interfaces
{
    public interface ISearchService
    {
        Task<IEnumerable<EthereumTransactionDto>> SearchEthereumTransactionsAsync(string searchAddress, ulong blockNumber);
    }
}
