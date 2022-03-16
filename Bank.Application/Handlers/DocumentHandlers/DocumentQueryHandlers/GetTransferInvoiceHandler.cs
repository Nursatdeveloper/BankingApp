using Bank.Application.Queries.DocumentQueries;
using Bank.Application.Services.PdfService;
using Bank.Core.Entities;
using Bank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Application.Handlers.DocumentHandlers.DocumentQueryHandlers
{
    public class GetTransferInvoiceHandler : IRequestHandler<GetTransferInvoiceQuery, byte[]>
    {
        private readonly IBankOperationRepository _bankOperationRepository;
        private readonly IPdfService _pdfService;
        public GetTransferInvoiceHandler(IBankOperationRepository bankOperationRepository, IPdfService pdfService)
        {
            _bankOperationRepository = bankOperationRepository;
            _pdfService = pdfService;
        }
        public async Task<byte[]> Handle(GetTransferInvoiceQuery request, CancellationToken cancellationToken)
        {
            BankOperation operation = await _bankOperationRepository.GetByIdAsync(request.BankOperationId);

            string HTML = $"<!DOCTYPE html><html lang='en'><head> <meta charset='UTF-8'> <meta http-equiv='X-UA-Compatible' content='IE=edge'> <meta name='viewport' content='width=device-width, initial-scale=1.0'> <title>Document</title> <link rel='stylesheet' href='style.css'/></head><body> <div class='logo__wrapper'> <img class='logo' src='../images/logo.jpg'/> </div><div class='header'>Квитанция</div><div class='sub__header'>Перевод клиенту Nursat Bank</div><div class='border'> <div class='status'> <div class='fs-20 mg-b-10'>Перевод успешно совершен!</div></div><div class='invoice'> <div class='border-bottom w-70'> Номер квитанции </div><div class='border-bottom w-30'> {operation.BankOperationId} </div></div><div class='invoice'> <div class='border-bottom w-70'> Дата и время </div><div class='border-bottom w-30'> {operation.BankOperationTime.ToLocalTime()} </div></div><div class='invoice'> <div class='border-bottom w-70'> Сумма перевода </div><div class='border-bottom w-30'> {operation.BankOperationMoneyAmount} {operation.CurrencyType} </div></div><div class='invoice'> <div class='border-bottom w-70'> Комиссия </div><div class='border-bottom w-30'> 0 KZT </div></div><div class='invoice'> <div class='border-bottom w-70'> Отправитель </div><div class='border-bottom w-30'> {operation.BankOperationMaker} </div></div><div class='invoice'> <div class='border-bottom w-70'> Откуда </div><div class='border-bottom w-30'> {operation.FromAccount} </div></div><div class='invoice'> <div class='border-bottom w-70'> Получатель </div><div class='border-bottom w-30'> {operation.BankOperationParticipant} </div></div></div></body></html>";
            byte[] pdfBytes = _pdfService.GetPdfBytes(HTML);
            return pdfBytes;
        }
    }
}
