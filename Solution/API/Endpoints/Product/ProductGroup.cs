namespace API.Endpoints.Product;

internal partial class ProductGroup
{
    internal static void Map(WebApplication app)
    {
        app.MapPost("/api/v1/product", CreateProduct)
            .AllowAnonymous();
    }
}
