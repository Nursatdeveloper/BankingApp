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
    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {
        public DocumentRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Document> FindByDocumentNameAndUserIdAsync(int userId, string documentName)
        {
            Document document = await _context.Documents.FirstOrDefaultAsync(doc => doc.UserId == userId && doc.DocumentName == documentName);
            return document;
        }

        public async Task<List<Document>> GetAllDocumentsByIdAsync(int usedId)
        {
            var allDocuments = await _context.Documents.ToListAsync();
            var selectedDocuments = from document in allDocuments
                                    where document.UserId == usedId
                                    select document;
            return selectedDocuments.ToList();
        }
    }
}
