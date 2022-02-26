using Bank.Application.Commands.UserCommands;
using Bank.Core.Entities;

namespace Bank.Application.Validations
{
    public interface IUserValidator
    {
        bool ValidateCardNumberForUniqueness(string cardNumber);
        bool ValidateIIN(string IIN);
        bool ValidatePhoneNumber(string phoneNumber);
        User ValidateLogin(LoginUserCommand request);
    }
}
