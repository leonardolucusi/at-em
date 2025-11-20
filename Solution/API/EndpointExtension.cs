using API.Endpoints.Pdf;

namespace API
{
    internal static class EndpointExtension
    {
        internal static WebApplication MapEndpoints(this WebApplication app)
        {
            PdfGroup.Map(app);
            return app;
        }

    }
}
