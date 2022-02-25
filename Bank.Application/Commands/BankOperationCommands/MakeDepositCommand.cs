﻿using Bank.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Commands.BankOperationCommands
{
    public class MakeDepositCommand :IRequest<BankOperationResponse>
    {
        public string DepositMaker { get; set; }
        public int DepositAmount { get; set; }
        public string DepositAccountType { get; set; }
        public string DepositMakerCardNumber { get; set; }
        public string DepositMakerTelephone { get; set; }
    }
}
