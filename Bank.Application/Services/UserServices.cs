using Bank.Core.Entities;
using Bank.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> GenerateCardNumber()
        {
            string visa = "4";
            string bankNumber = "00175";
            string individualIdentNumberForUser = "";
            Random random = new();
            for(int i = 0; i < 12; i++)
            {
                int number = random.Next(10);
                individualIdentNumberForUser += $"{number}";
            }
            string cardNumber = visa + bankNumber + individualIdentNumberForUser;
            bool IsUnique =  _userRepository.VerifyForUniqueness(cardNumber);
            if (!IsUnique)
            {
                await GenerateCardNumber();
            }
            return cardNumber;
        }
    }
}
