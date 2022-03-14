using Bank.Application.Commands.DocumentCommands;
using Bank.Application.Services.PdfService;
using Bank.Core.Repositories;
using iText.Html2pdf;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
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
    public class CreateAccountContractHandler : IRequestHandler<CreateAccountContractCommand, byte[]>
    {
        private readonly IPdfService _pdfService;
        private readonly IUserRepository _userRepository;
        public CreateAccountContractHandler(IPdfService pdfService, IUserRepository userRepository)
        {
            _pdfService = pdfService;
            _userRepository = userRepository;
        }
        public async Task<byte[]> Handle(CreateAccountContractCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.UserId);
            byte[] pdfFileBytes;
            using (var stream = new MemoryStream())
            using (var writer = new PdfWriter(stream))
            {
                string HTML = "<!DOCTYPE html><html lang='en'><head> <meta charset='UTF-8'> <meta http-equiv='X-UA-Compatible' content='IE=edge'> <meta name='viewport' content='width=device-width, initial-scale=1.0'> <title>Document</title></head><body> <div style='text-align:center; font-weight:600;'>ДОГОВОР БАНКОВСКОГО СЧЕТА</div><div>Для упрощения ситуации данные пользователей определены в виде простого списка. Для поиска пользователя в этом списке по логину и паролю определен метод GetIdentity(), который возвращает объект ClaimsIdentity. Принцип создания ClaimsIdentity здесь тот же, что и при аутентификации с помощью кук: создается набор объектов Claim, которые включают различные данные о пользователе, например, логин, роль и т.д. Для обработки запроса в контроллере создан метод Token, который сопоставлен с маршрутом '/token'. Этот метод обрабатывает запросы POST и через параметры принимает логин и пароль пользователя. Сам токен представляет объект JwtSecurityToken, для инициализации которого применяются все те же константы и ключ безопасности, которые определены в классе AuthOptions и которые использовались в классе Startup для настройки JwtBearerAuthenticationMiddleware. Важно, чтобы эти значения совпадали. С помощью параметра claims: identity.Claims в токен добавляются набор объектов Claim, которые содержат информацию о логине и роли пользователя. Далее посредством метода JwtSecurityTokenHandler().WriteToken(jwt) создается Json-представление токена. И в конце он сериализуется и отправляет клиенту с помощью метода Json().</div></body></html>";
                //HtmlConverter.ConvertToPdf(HTML, writer);
                string baseUri = @".\resources\static";
                ConverterProperties properties = new ConverterProperties();
                properties.SetBaseUri(baseUri);
                HtmlConverter.ConvertToPdf(new FileStream(@".\resources\static\document.html", FileMode.Open), writer, properties);

            pdfFileBytes = stream.ToArray();
            }
            return pdfFileBytes;
            /*using (var stream = new MemoryStream())
            using (var writer = new PdfWriter(stream))
            using (var pdf = new PdfDocument(writer))
            using (var document = new Document(pdf))
            {
                 string FONT_FILENAME = @".\resources\fonts\arial.ttf";
                 PdfFont arial = PdfFontFactory.CreateFont(FONT_FILENAME, PdfEncodings.IDENTITY_H);
                 document.SetFont(arial);

                 Table table = new Table(1, true)
                     .SetBorder(Border.NO_BORDER);
                 table.AddCell(_pdfService.GetBankLogo());
                 table.AddCell(_pdfService.CreateTextCell("ДОГОВОР БАНКОВСКОГО СЧЕТА", 14));

                 document.Add(table);
                 document.Close();
                 pdfFileBytes = stream.ToArray();
                //ConverterProperties properties = new ConverterProperties();
                //properties.SetBaseUri(baseUri);
                string html = "<!DOCTYPE html><html lang='en'><head> <meta charset='UTF-8'> <meta http-equiv='X-UA-Compatible' content='IE=edge'> <meta name='viewport' content='width=device-width, initial-scale=1.0'> <title>Document</title></head><body> <div style='text-align:center; font-weight:600;'>ДОГОВОР БАНКОВСКОГО СЧЕТА</div><div>Для упрощения ситуации данные пользователей определены в виде простого списка. Для поиска пользователя в этом списке по логину и паролю определен метод GetIdentity(), который возвращает объект ClaimsIdentity. Принцип создания ClaimsIdentity здесь тот же, что и при аутентификации с помощью кук: создается набор объектов Claim, которые включают различные данные о пользователе, например, логин, роль и т.д. Для обработки запроса в контроллере создан метод Token, который сопоставлен с маршрутом '/token'. Этот метод обрабатывает запросы POST и через параметры принимает логин и пароль пользователя. Сам токен представляет объект JwtSecurityToken, для инициализации которого применяются все те же константы и ключ безопасности, которые определены в классе AuthOptions и которые использовались в классе Startup для настройки JwtBearerAuthenticationMiddleware. Важно, чтобы эти значения совпадали. С помощью параметра claims: identity.Claims в токен добавляются набор объектов Claim, которые содержат информацию о логине и роли пользователя. Далее посредством метода JwtSecurityTokenHandler().WriteToken(jwt) создается Json-представление токена. И в конце он сериализуется и отправляет клиенту с помощью метода Json().</div></body></html>";
                HtmlConverter.ConvertToPdf(html, writer);
            }
            return pdfFileBytes;*/
        }
    }
}
