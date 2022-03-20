using Bank.Application.Commands.DocumentCommands;
using Bank.Application.Services.PdfService;
using iText.Html2pdf;
using iText.Html2pdf.Resolver.Font;
using iText.IO.Font;
using iText.Kernel.Pdf;
using iText.Layout.Font;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Application.Handlers.DocumentHandlers
{
    public class GetAccountContractTemplateHandler : IRequestHandler<GetAccountContractTemplateCommand, byte[]>
    {
        private readonly IPdfService _pdfService;
        public GetAccountContractTemplateHandler(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }
        public async Task<byte[]> Handle(GetAccountContractTemplateCommand request, CancellationToken cancellationToken)
        {
            string HTML = $"<!DOCTYPE html><html lang='en'><head> <meta charset='UTF-8'> <meta http-equiv='X-UA-Compatible' content='IE=edge'> <meta name='viewport' content='width=device-width, initial-scale=1.0'> <title>Document</title> <link rel='stylesheet' href='style.css'/></head><body> <div class='logo__wrapper'> <img class='logo' src='../images/logo.jpg'/> </div><div class='header'>ДОГОВОР БАНКОВСКОГО СЧЕТА</div><div class='sub__header'>в валюте Республики Казахстан с физическим лицом</div><div>Дата: <span id='date'></span></div><p> <span class='start '>Акционерное общество </span><span class='bold'>'Nursat Bank',</span> именуемое в дальнейшем <span class='bold'>'БАНК'</span>, с одной стороны, и ___________________, именуемый в дальнейшем <span class='bold'>'КЛИЕНТ'</span>, с другой стороны, совместно именуемые <span class='bold'>'Стороны'</span>, заключают Договор о нижеследующем: </p><div class='sub__header'>1. ПРЕДМЕТ ДОГОВОРА</div><p> <span class='start'>1.1 БАНК</span> открывает КЛИЕНТУ (Текущий счет / Депозит) далее - 'счет' и осуществляет банковские операций КЛИЕНТА в тенге РК. </p><p> <span class='start'>1.2 БАНК</span> оказывает услуги КЛИЕНТУ в соответсвии с действующим законадательством РК, а также установленными в соответсвии с ним банкомскими правилами </p><p> <span class='start'>1.3 Операции</span> по счету, связанные с предпренимательской деятельностью КЛИЕНТА, не осуществляются. </p><div class='sub__header'>2. ОБЯЗАННОСТИ БАНКА</div><p> <span class='start'>2.1 Осуществлять</span> услуги предоставленные в приложений Nursat Bank. </p><p> <span class='start'>2.2 Перечислять</span> денежные средства с банка на счет КЛИЕНТА после выполнения операций 'Пополнение'. </p><p> <span class='start'>2.3 Переводить</span> денежные средства со счета КЛИЕНТА на другие счета КЛИЕНТА, а так же на счета других клиентов Nursat Bank после выполнения операций 'Перевод'. </p><p> <span class='start'>2.4 Осуществлять</span> все банковские операций во время и гарантировать конфиденциальность персональных данных и сохранность денежных средств. </p><div class='sub__header'>3. ОБЯЗАННОСТИ КЛИЕНТА</div><p> <span class='start'>3.1 Соблюдать</span> действующее законадательство и иные нормативные акты, регулирующие порядок осуществления безналичных расчетов. </p><p> <span class='start'>3.2 Предоставлять</span> по запросу БАНКА платежные документы, по содержанию и форме соответсвующие положениям действующего законодательсва РК. </p><p> <span class='start'>3.3 Оплачивать</span> услуги, оказываемые БАНКОМ, в соответсвии с Тарифами БАНКА. </p><p> <span class='start'>3.4 При</span> неисполнении вышеуказанных условий, БАНК не несет ответсвенность за возможные последсвия такого неуведомления. </p><div class='sub__header mg-b-10'>ПОДПИСИ СТОРОН</div><div class='col-2'> <div class='width-50 '> <div class='bold mg-b-10 start'>За БАНК</div><div class='start'>Нурсат Зейнолла</div></div><div class='width-50 '> <div class='bold mg-b-10'>За КЛИЕНТА</div><div>________________________</div></div></div></body></html><script>var date=new Date(); document.getElementById('date').innerHTML=date.toLocaleDateString();</script><script src='./script.js'></script>";
            byte[] pdfBytes = _pdfService.GetPdfBytes(HTML);
            return pdfBytes;
        }
    }
}
