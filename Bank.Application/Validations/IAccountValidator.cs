using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Validations
{
    public interface IAccountValidator
    {
        bool ValidateIIN(string IIN);
        bool ValidateAccountNumber(string accountNumber);
    }
}
