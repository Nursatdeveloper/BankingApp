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
    public class GetAllAccountsHandler : IRequestHandler<GetAllAccountsQuery, IReadOnlyList<Account>>
    {
        private readonly IAccountRepository _accountRepository;
        public GetAllAccountsHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<IReadOnlyList<Account>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Account> accounts = await _accountRepository.GetAllAsync();
            return accounts;
        }
    }
}
