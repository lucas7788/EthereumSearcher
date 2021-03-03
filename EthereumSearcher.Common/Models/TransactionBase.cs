using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace EthereumSearcher.Common.Models
{
    public class TransactionBase
    {
        public string BlockHash { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string TransactionHash { get; set; }
    }
}
