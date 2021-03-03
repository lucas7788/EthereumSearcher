using AutoMapper;
using EthereumSearcher.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EthereumSearcher.Common.MappingProfiles
{
	public class EthereumTransactionMappingProfile : Profile
	{
		public EthereumTransactionMappingProfile()
		{
            CreateMap<EthereumTransaction, EthereumTransactionDto>()
                .ForMember(destination => destination.BlockNumber, map => map.MapFrom(source => source.BlockNumber.ToString()))
                .ForMember(destination => destination.Gas, map => map.MapFrom(source => source.Gas.ToString()));
        }
	}
}
