using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Application
{
    public static class PdfService
    {
        static PdfService()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public static byte[] GeneratePdf(string texto)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(40);
                    page.Size(PageSizes.A4);

                    page.Content()
                        .Text(texto)
                        .FontSize(20)
                        .FontColor(Colors.Blue.Medium);
                });
            });

            return document.GeneratePdf();
        }
    }
}
