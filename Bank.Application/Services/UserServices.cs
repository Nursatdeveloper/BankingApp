﻿using Bank.Application.Commands.UserCommands;
using Bank.Application.Validations;
using Bank.Core.Entities;
using Bank.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserValidator _userValidator;
        public UserServices(IUserValidator userValidator)
        {
            _userValidator = userValidator;
        }

        public User FindUserForLogin(LoginUserCommand request)
        {
            User user = _userValidator.ValidateLogin(request);
            return user;
        }

        public async Task<string> GenerateCardNumber()
        {
            string visa = "4";
            string bankNumber = "00175";
            string individualIdentNumberForUser = "";
            Random random = new();
            for(int i = 0; i < 10; i++)
            {
                int number = random.Next(10);
                individualIdentNumberForUser += $"{number}";
            }
            string cardNumber = visa + bankNumber + individualIdentNumberForUser;
            bool IsUnique = _userValidator.ValidateCardNumberForUniqueness(cardNumber);
            if (!IsUnique)
            {
                await GenerateCardNumber();
            }
            return cardNumber;
        }

        public ClaimsIdentity GenerateClaimsIdentity(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
