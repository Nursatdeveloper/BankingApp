using AutoMapper;
using Bank.Application.Responses;
using Bank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Mappers.MappingProfiles
{
    public class BankOperationMappingProfile : Profile
    {
        public BankOperationMappingProfile()
        {
            CreateMap<BankOperation, BankOperationResponse>().ReverseMap();
        }
    }
}
