using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Responses
{
    public class BankOperationResponse
    {
        public int BankOperationId { get; set; }
        public string BankOperationType { get; set; }
        public string BankOperationMaker { get; set; }
        public string BankOperationParticipant { get; set; }
        public DateTime BankOperationTime { get; set; }
        public int BankOperationMoneyAmount { get; set; }
        public int BankOperationMakerId { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
