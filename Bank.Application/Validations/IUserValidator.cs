using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Validations
{
    public interface IUserValidator
    {
        bool ValidateCardNumberForUniqueness(string cardNumber);
        bool ValidateIIN(string IIN);
    }
}
