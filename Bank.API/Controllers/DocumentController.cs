using Bank.Application.Commands.DocumentCommands;
using iText.Html2pdf;
using iText.Kernel.Pdf;
using MediatR;
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
        [HttpPost]
        [Route("account-contract")]
        public async Task<ActionResult> AccountContract([FromBody] CreateAccountContractCommand command)
        {
            var pdfFile = await _mediator.Send(command);
            return File(pdfFile, "application/pdf", "Document");
        }

    }
}
