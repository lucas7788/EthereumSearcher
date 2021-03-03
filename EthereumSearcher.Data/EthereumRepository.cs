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
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Hex.HexTypes;
using System.Linq;
using EthereumSearcher.Common.Exceptions;

namespace EthereumSearcher.Data
{
    public class EthereumRepository : SearchRepositoryBase<EthereumTransaction> 
    {
        private readonly IWeb3 _rpcClient;

        public EthereumRepository(IWeb3 rpcClient)
        {
            _rpcClient = rpcClient;
        }

        public override async Task<IList<EthereumTransaction>> GetTransactionsAsync(string searchAddress, ulong blockNumber)
        {
            var blockWithTransactions = await _rpcClient.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(new BlockParameter(blockNumber), null);
          
            if (blockWithTransactions == null)
            {
                throw new BlockDoesNotExistException($"Block {blockNumber} does not exist on ethereum mainnet");
            }

            var transactions = blockWithTransactions.Transactions
                                .ToList()
                                .Where(t => t.To == searchAddress || t.From == searchAddress)
                                .Select(c => new EthereumTransaction
                                 {
                                    BlockHash = c.BlockHash,
                                    BlockNumber = c.BlockNumber,
                                    FromAddress = c.From,
                                    Gas = c.Gas,
                                    GasPrice = c.GasPrice,
                                    Nonce = c.Nonce,
                                    ToAddress = c.To,
                                    TransactionHash = c.TransactionHash,
                                    Value = c.Value
                                }).ToList();

            return transactions;
        }
    }
}
