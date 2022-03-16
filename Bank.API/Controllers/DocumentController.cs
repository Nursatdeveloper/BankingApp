using Bank.Application.Commands.DocumentCommands;
using Bank.Application.Queries.DocumentQueries;
using Bank.Core.Entities;
using iText.Html2pdf;
using iText.Kernel.Pdf;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DocumentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("get-account-contract-template")]
        [Authorize(Roles = "Пользователь")]
        public async Task<ActionResult> GetAccontContractTemplate()
        {
            var pdfFile = await _mediator.Send(new GetAccountContractTemplateCommand());
            return File(pdfFile, "application/pdf", "Образец_договора");
        }

        [HttpGet]
        [Route("get-all-documents/{userId}")]
        [Authorize(Roles = "Пользователь")]
        public async Task<JsonResult> GetAllDocuments(int userId)
        {
            var documentList = await _mediator.Send(new GetAllDocumentsQuery(userId));
            return new JsonResult(documentList);
        }

        [HttpPost]
        [Route("find-pdf-document")]
        [Authorize(Roles = "Пользователь")]
        public async Task<ActionResult<Document>> FindDocument([FromBody] FindDocumentCommand command)
        {
            var pdfDocument = await _mediator.Send(command);
            return File(pdfDocument.DocumentBytes, "application/pdf", pdfDocument.DocumentName);
        }

        [HttpGet]
        [Route("get-transfer-invoice/{id}")]
        //[Authorize(Roles = "Пользователь")]
        public async Task<ActionResult> GetTransferInvoice(int id)
        {
            var pdfDocument = await _mediator.Send(new GetTransferInvoiceQuery(id));
            return File(pdfDocument, "application/pdf", "Квитанция");
        }

        [HttpPost]
        [Route("account-contract")]
        public async Task<ActionResult> AccountContract([FromBody] CreateAccountContractCommand command)
        {
            var pdfFile = await _mediator.Send(command);
            return File(pdfFile, "application/pdf", "Document");
        }

    }
}
