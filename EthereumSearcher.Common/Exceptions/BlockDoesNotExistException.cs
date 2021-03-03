using System;
using System.Collections.Generic;
using System.Text;

namespace EthereumSearcher.Common.Exceptions
{
    public class BlockDoesNotExistException : Exception
    {
        public BlockDoesNotExistException(string message) : base(message) { }
    }
}
