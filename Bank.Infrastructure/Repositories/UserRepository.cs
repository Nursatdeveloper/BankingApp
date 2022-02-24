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

        public async Task<User> FindUserByCardNumber(string cardNumber)
        {
            var user = await _context.Users.FirstOrDefaultAsync(e => e.CardNumber == cardNumber);
            return user;
        }

        public async Task<User> FindUserByIIN(string IIN)
        {
            var user = await _context.Users.FirstOrDefaultAsync(e => e.IIN == IIN);
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.Include(e => e.Accounts).FirstAsync(e => e.UserId == id);
            return user;
        }

    }
}
