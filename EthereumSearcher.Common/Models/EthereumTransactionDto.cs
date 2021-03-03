using System;
using System.Collections.Generic;
using System.Text;

namespace EthereumSearcher.Common.Models
{
    public class EthereumTransactionDto : TransactionBase
    {
        public string BlockNumber { get; set; }
        public string Gas { get; set; }
    }
}
