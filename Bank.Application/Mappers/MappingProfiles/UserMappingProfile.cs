using AutoMapper;
using Bank.Application.Commands.UserCommands;
using Bank.Application.Responses;
using Bank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Mappers.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
        }
    }
}
