namespace API.Endpoints.Pdf
{
    internal static partial class PdfGroup
    {
        internal static void Map(WebApplication app)
        {
            app.MapPost("/api/v1/pdf", GeneratePdf)
                .AllowAnonymous();
        }
    }
}
