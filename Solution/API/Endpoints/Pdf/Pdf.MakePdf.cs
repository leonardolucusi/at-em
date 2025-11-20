using Application;

namespace API.Endpoints.Pdf
{
    internal partial class PdfGroup
    {
        private static IResult GeneratePdf(
            CancellationToken cancellationToken)
        {
            var pdfBytes = PdfService.GeneratePdf("Olá, PDF gerado direto da API!");
            return Results.File(pdfBytes, "application/pdf", "arquivo.pdf");
        }
    }
}
