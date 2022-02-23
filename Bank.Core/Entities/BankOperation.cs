﻿using System;
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
    }
}