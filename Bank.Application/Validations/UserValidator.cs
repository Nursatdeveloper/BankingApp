using Bank.Application.Commands.UserCommands;
using Bank.Core.Entities;
using Bank.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Validations
{
    public class UserValidator : IUserValidator
    {
        private readonly IUserRepository _userRepository;
        public UserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool ValidateCardNumberForUniqueness(string cardNumber)
        {
            if(_userRepository.FindUserByCardNumber(cardNumber) is null)
            {
                return true;
            }
            return false;
        }

        public bool ValidateIIN(string IIN)
        {
            if (_userRepository.FindUserByIIN(IIN) is null)
            {
                return true;
            }
            return false;
        }

        public User ValidateLogin(LoginUserCommand request)
        {
            User user = _userRepository.FindUserByPhoneNumber(request.Telephone);
            if(user is null)
            {
                return _userRepository.FindUserByIIN(request.IIN);
            }
            return user;
        }

        public bool ValidatePhoneNumber(string phoneNumber)
        {
            if(_userRepository.FindUserByPhoneNumber(phoneNumber) is null)
            {
                return true;
            }
            return false;
        }
    }
}
