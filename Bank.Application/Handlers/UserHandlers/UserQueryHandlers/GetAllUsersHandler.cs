using Bank.Application.Queries.UserQueries;
using Bank.Application.Responses;
using Bank.Core.Entities;
using Bank.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Application.Handlers.UserQueryHandlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return (List<User>)await _userRepository.GetAllAsync();
        }
    }
}
