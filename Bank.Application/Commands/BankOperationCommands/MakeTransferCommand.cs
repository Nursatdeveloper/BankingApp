using Bank.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Commands.BankOperationCommands
{
    public class MakeTransferCommand : IRequest<BankOperationResponse>
    {
        public int TransferAmount { get; set; } // by user
        public string CurrencyType { get; set; }
        public string TransferFromAccountType { get; set; } // by user
        public int TransferMakerId { get; set; } // or this
        public string TransferToAccountType { get; set; } // by user
        public string ReceiverTelephone { get; set; } // 
    }
}
