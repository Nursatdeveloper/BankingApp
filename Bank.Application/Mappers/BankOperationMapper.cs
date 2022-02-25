using AutoMapper;
using Bank.Application.Mappers.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Mappers
{
    public class BankOperationMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(conf =>
            {
                conf.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                conf.AddProfile<BankOperationMappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
}
