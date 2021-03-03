using AutoMapper;
using EthereumSearcher.Common.Models;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Text;

namespace EthereumSearcher.Common.MappingProfiles
{
	public class EthereumTransactionMappingProfile : Profile
	{
		public EthereumTransactionMappingProfile()
		{
            _ = CreateMap<EthereumTransaction, EthereumTransactionDto>()
                .ForMember(destination => destination.BlockNumber, map => map.MapFrom(source => source.BlockNumber.ToString()))
                .ForMember(destination => destination.Gas, map => map.MapFrom(source => Web3.Convert.FromWei(source.Gas, 20)))
                .ForMember(destination => destination.Value, map => map.MapFrom(source => Web3.Convert.FromWei(source.Value, 20)));
        }
	}
}
