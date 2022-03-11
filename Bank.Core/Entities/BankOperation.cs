using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Entities
{
    public class BankOperation
    {
        public int BankOperationId { get; set; }
        public string BankOperationType { get; set; }
        public string BankOperationMaker { get; set; }
        public string BankOperationParticipant { get; set; }
        public DateTime BankOperationTime { get; set; }
        public int BankOperationMoneyAmount { get; set; }
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public string CurrencyType { get; set; }
        public int BankOperationMakerId { get; set; }
    }
}
