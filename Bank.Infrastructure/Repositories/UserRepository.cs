using Bank.Core.Entities;
using Bank.Core.Repositories;
using Bank.Infrastructure.Data;
using Bank.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public User FindUserByCardNumber(string cardNumber)
        {
            var user = _context.Users.FirstOrDefault(e => e.CardNumber == cardNumber);
            return user;
        }

        public User FindUserByIIN(string IIN)
        {
            var user =  _context.Users.FirstOrDefault(e => e.IIN == IIN);
            return user;
        }

        public User FindUserByPhoneNumber(string phoneNumber)
        {
            var user = _context.Users.FirstOrDefault(e => e.PhoneNumber == phoneNumber);
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.Include(e => e.Accounts).FirstAsync(e => e.UserId == id);
            return user;
        }

    }
}
