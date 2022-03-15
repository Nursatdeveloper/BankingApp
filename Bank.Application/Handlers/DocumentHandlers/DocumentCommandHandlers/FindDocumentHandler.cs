using Bank.Application.Commands.DocumentCommands;
using Bank.Core.Entities;
using Bank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Application.Handlers.DocumentHandlers.DocumentCommandHandlers
{
    public class FindDocumentHandler : IRequestHandler<FindDocumentCommand, Document>
    {
        private readonly IDocumentRepository _documentRepository;
        public FindDocumentHandler(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
        public async Task<Document> Handle(FindDocumentCommand request, CancellationToken cancellationToken)
        {
            Document document = await _documentRepository.FindByDocumentNameAndUserIdAsync(request.UserId, request.DocumentName);
            return document;
        }
    }
}
