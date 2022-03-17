using Bank.Core.Entities;
using Bank.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Repositories
{
    public interface IPhotoRepository : IRepository<Photo>
    {
        Task<Photo> GetByUserIdAsync(int userId);
    }
}
