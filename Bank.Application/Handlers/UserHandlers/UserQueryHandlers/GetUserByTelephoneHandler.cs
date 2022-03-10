using Bank.Application.Mappers;
using Bank.Application.Queries.UserQueries;
using Bank.Application.Responses;
using Bank.Core.Entities;
using Bank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Application.Handlers.UserHandlers.UserQueryHandlers
{
    public class GetUserByTelephoneHandler : IRequestHandler<GetUserByTelephoneQuery, UserResponse>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByTelephoneHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserResponse> Handle(GetUserByTelephoneQuery request, CancellationToken cancellationToken)
        {
            User user =  _userRepository.FindUserByPhoneNumber(request.Telephone);
            UserResponse userResponse = UserMapper.Mapper.Map<UserResponse>(user);
            return userResponse;
        }
    }
}
