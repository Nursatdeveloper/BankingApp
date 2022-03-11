using Bank.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Commands.BankOperationCommands
{
    public class MakeTransferToMyAccountCommand :IRequest<BankOperationResponse>
    {
        public int UserId { get; set; }
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public int TransferAmount { get; set; }
        public string CurrencyType { get; set; }

    }
}
