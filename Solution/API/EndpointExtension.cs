using API.Endpoints.Customer;
using API.Endpoints.Pdf;
using API.Endpoints.Product;

namespace API
{
    internal static class EndpointExtension
    {
        internal static WebApplication MapEndpoints(this WebApplication app)
        {
            ProductGroup.Map(app);
            PdfGroup.Map(app);
            CustomerGroup.Map(app);
            return app;
        }

    }
}
