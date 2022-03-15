using Bank.Core.Entities;
using Bank.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Repositories
{
    public interface IDocumentRepository : IRepository<Document>
    {
        Task<List<Document>> GetAllDocumentsByIdAsync(int usedId);
        Task<Document> FindByDocumentNameAndUserIdAsync(int userId, string documentName);
    }
}
