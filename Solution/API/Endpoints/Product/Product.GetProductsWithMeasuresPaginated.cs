using API.Endpoints.Validation;
using Application.Query.Interface;

namespace API.Endpoints.Product;

internal partial class ProductGroup
{
    private static async Task<IResult> GetProductsWithMeasuresPaginated(
        int pageNumber, 
        int pageSize,
        IProductQueryHandler productQueryHandler,
        CancellationToken cancellationToken)
    {
        var response = await productQueryHandler.GetProductsWithMeasuresPaginated(pageNumber, pageSize, cancellationToken);
        return Result.From(response, response.Content);
    } 
}