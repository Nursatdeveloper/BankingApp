using Bank.Core.Entities;
using Bank.Core.Repositories;
using Bank.Core.Repositories.Base;
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
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        
        public PhotoRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Photo> GetByUserIdAsync(int userId)
        {
            return await _context.Photos.FirstOrDefaultAsync(p => p.UserId == userId);
        }
    }
}
