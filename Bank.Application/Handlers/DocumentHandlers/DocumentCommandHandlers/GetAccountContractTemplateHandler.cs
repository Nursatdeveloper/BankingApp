using Bank.Application.Commands.DocumentCommands;
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
        public async Task<byte[]> Handle(GetAccountContractTemplateCommand request, CancellationToken cancellationToken)
        {
            byte[] pdfFileBytes;
            using (var stream = new MemoryStream())
            using (var writer = new PdfWriter(stream))
            {
                string FONT_TIMES = @".\resources\fonts\times.ttf";


                string baseUri = @".\resources\static";
                ConverterProperties properties = new ConverterProperties();
                FontProvider fontProvider = new DefaultFontProvider(false, false, false);
                FontProgram fontProgram = FontProgramFactory.CreateFont(FONT_TIMES);
                fontProvider.AddFont(fontProgram);
                properties.SetFontProvider(fontProvider);
                properties.SetBaseUri(baseUri);
                HtmlConverter.ConvertToPdf(new FileStream(@".\resources\static\document.html", FileMode.Open), writer, properties);

                pdfFileBytes = stream.ToArray();
            }
            return pdfFileBytes;
        }
    }
}
