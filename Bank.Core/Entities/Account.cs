using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string OwnerName { get; set; }
        public string OwnerIIN { get; set; }
        public string AccountType { get; set; }
        public int Balance { get; set; }
        public string CurrencyType { get; set; }
        public DateTime ActivatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlocked { get; set; }
        public List<BankOperation> BankOperations { get; set; }
    }
}
