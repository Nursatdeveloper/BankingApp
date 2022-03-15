using Bank.Application.Queries.DocumentQueries;
using Bank.Core.Entities;
using Bank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Application.Handlers.DocumentHandlers.DocumentQueryHandlers
{
    public class GetAllDocumentsHandler : IRequestHandler<GetAllDocumentsQuery, List<Document>>
    {
        private readonly IDocumentRepository _documentRepository;
        public GetAllDocumentsHandler(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
        public async Task<List<Document>> Handle(GetAllDocumentsQuery request, CancellationToken cancellationToken)
        {
            List<Document> documents = await _documentRepository.GetAllDocumentsByIdAsync(request.UserId);
            return documents;
        }
    }
}
