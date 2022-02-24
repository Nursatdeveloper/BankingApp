using Bank.Application.Queries.UserQueries;
using Bank.Core.Entities;
using Bank.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Application.Handlers.UserQueryHandlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserById(request.UserId);
        }
    }
}
