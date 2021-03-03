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
        private readonly IConfiguration _configurationManager;

        public EthereumRepository(IConfiguration configurationManager)
        {
            _configurationManager = configurationManager;
        }

        public override async Task<IList<EthereumTransaction>> GetTransactionsAsync(string searchAddress, ulong blockNumber)
        {
            var web3 = new Web3(_configurationManager.GetSection("InfuraSettings").GetSection("EthereumEndpoint").Value);
            var blockWithTransactions = await web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(new BlockParameter(blockNumber));
            if (blockWithTransactions == null)
            {
                throw new BlockDoesNotExistException($"Block {blockNumber} does not exist on ethereum mainnet");
            }

            //todo: use automapper
            var transactions = blockWithTransactions.Transactions
                                .ToList()
                                .Where(t => t.To == searchAddress || t.From == searchAddress)
                                .Select(c => new EthereumTransaction
                                 {
                                    BlockHash = c.BlockHash,
                                    BlockNumber = c.BlockNumber,//
                                    FromAddress = c.From,
                                    Gas = c.Gas,//
                                    GasPrice = c.GasPrice,//
                                    Nonce = c.Nonce,
                                    ToAddress = c.To,
                                    TransactionHash = c.TransactionHash
                                }).ToList();

            return transactions;

            //test: what if theres no transactions is an empty list always returned? YES
            //test: does an exception get thrown?
            //what happens with shit input

        }
    }
}
