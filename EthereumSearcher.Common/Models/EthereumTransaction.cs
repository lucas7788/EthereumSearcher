using System;
using System.Numerics;

namespace EthereumSearcher.Common.Models
{
    public class EthereumTransaction : TransactionBase
    {
        public BigInteger GasPrice { get; set; }
        public BigInteger Nonce { get; set; }
        public BigInteger BlockNumber { get; set; }
        public BigInteger Gas { get; set; }
    }
}
