﻿using Bank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Services
{
    public interface IUserServices
    {
        Task<string> GenerateCardNumber();
    }
}
