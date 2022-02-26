using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Services.JwtService
{
    public class UserAuthenticationOptions
    {
        public const string ISSUER = "BankServer"; 
        public const string AUDIENCE = "BankClient"; 
        const string KEY = "secret_key_which_is_actually_not_secret";
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
