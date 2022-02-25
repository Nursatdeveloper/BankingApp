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
        public string TransferMaker { get; set; } 
        public int TransferAmount { get; set; } // by user
        public string TransferFromAccountType { get; set; } // by user
        public string TransferMakerCardNumber { get; set; } // choose one this
        public string TransferMakerTelephone { get; set; } // or this
        public string TransferToAccountType { get; set; } // by user
        public string ReceiverCardNumber { get; set; } 
        public string RecerverTelephone { get; set; }
    }
}
