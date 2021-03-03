using EthereumSearcher.Common.Exceptions;
using EthereumSearcher.Common.Models;
using EthereumSearcher.Data;
using EthereumSearcher.Data.Interfaces;
using Moq;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EthereumSearcher.Services.UnitTests
{
    public class RepositoryTests
    {
        private readonly Mock<IWeb3> _mockRpcClient;
        private ISearchRepository<EthereumTransaction> _ethereumRepository;
        private readonly string _searchAddress = "0xc55eddadeeb47fcde0b3b6f25bd47d745ba7e7fa";

        public RepositoryTests()
        {
            _mockRpcClient = new Mock<IWeb3>();
            _ethereumRepository = new EthereumRepository(_mockRpcClient.Object);
        }

        // Not every block has transactions! Scenarios:
        // Someone was mining and found a solution before it received any transactions in the block
        // No one sent a transaction during that time frame
        [Fact]
        public async Task When_No_Transactions_InBlock_EmptyListReturned()
        {
            ulong blockNumber = 999999999L;
            Mock<BlockParameter> blockParameter = new Mock<BlockParameter>(blockNumber);
            BlockWithTransactions blockWithTransactionsResponse = new BlockWithTransactions
            {
                Transactions = new Transaction[0]
            };

            _mockRpcClient.Setup(c => c.Eth.Blocks.GetBlockWithTransactionsByNumber
                                .SendRequestAsync(It.IsAny<BlockParameter>(), null))
                                .ReturnsAsync(blockWithTransactionsResponse);

            var response = await _ethereumRepository.GetTransactionsAsync(_searchAddress, blockNumber);

            Assert.NotNull(response);
            Assert.Empty(response);
        }

        [Fact]
        public async Task When_Given_InvalidBlockNumber_ExceptionThrown()
        {
            ulong nonExistantBlockNumber = 999999999L;
            Mock<BlockParameter> blockParameter = new Mock<BlockParameter>(nonExistantBlockNumber);
            
            _mockRpcClient.Setup(c => c.Eth.Blocks.GetBlockWithTransactionsByNumber
                                .SendRequestAsync(blockParameter.Object, null))
                                .Returns(Task.FromResult<BlockWithTransactions>(null));

            var response = await Assert.ThrowsAsync<BlockDoesNotExistException>(() => _ethereumRepository.GetTransactionsAsync(_searchAddress, nonExistantBlockNumber));

            Assert.Equal($"Block {nonExistantBlockNumber} does not exist on ethereum mainnet", response.Message);
        }

        [Fact]
        public async Task When_Given_GarbageAddress_NotExistingInBlock_EmptyListReturned()
        {
            var address = "subfluesbfliuesbfliuesbfliuesf";
            ulong blockNumber = 999L;
            Mock<BlockParameter> blockParameter = new Mock<BlockParameter>(blockNumber);
            BlockWithTransactions blockWithTransactionsResponse = new BlockWithTransactions
            {
                Transactions = new Transaction[0]
            };


            _mockRpcClient.Setup(c => c.Eth.Blocks.GetBlockWithTransactionsByNumber
                                .SendRequestAsync(It.IsAny<BlockParameter>(), null))
                                .ReturnsAsync(blockWithTransactionsResponse);

            var response = await _ethereumRepository.GetTransactionsAsync(_searchAddress, blockNumber);

            Assert.NotNull(response);
            Assert.Empty(response);

        }


    }
}
