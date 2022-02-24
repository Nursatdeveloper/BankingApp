using Bank.Application.Queries.AccountQueries;
using Bank.Core.Entities;
using Bank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Application.Handlers.AccountHandlers.AccountQueryHandlers
{
    public class GetAccountsByUserIdHandler : IRequestHandler<GetAccountsByUserIdQuery, List<Account>>
    {
        private readonly IUserRepository _userRepository;
        public GetAccountsByUserIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<Account>> Handle(GetAccountsByUserIdQuery request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetUserById(request.UserId);
            List<Account> accounts = user.Accounts;
            return accounts;

        }
    }
}
