using Bank.Application.Queries.BankOperationQueries;
using Bank.Core.Entities;
using Bank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Application.Handlers.BankOperationHandlers.BankOperationQueryHandlers
{
    public class GetBankOperationsByUserIdHandler : IRequestHandler<GetBankOperationsByUserIdQuery, List<BankOperation>>
    {
        private readonly IBankOperationRepository _bankOperationRespository;
        public GetBankOperationsByUserIdHandler(IBankOperationRepository bankOperationRespository)
        {
            _bankOperationRespository = bankOperationRespository;
        }
        public async Task<List<BankOperation>> Handle(GetBankOperationsByUserIdQuery request, CancellationToken cancellationToken)
        {
            List<BankOperation> bankOperations = await _bankOperationRespository.GetBankOperationsByUserId(request.UserId);
            return bankOperations;
        }
    }
}
