using API.Endpoints.Validation;
using Application.Query.Interface;

namespace API.Endpoints.Product;

internal partial class ProductGroup
{
    private static async Task<IResult> GetByIdWithMeasures(
        IProductQueryHandler productQueryHandler,
        int id,
        CancellationToken cancellationToken)
    {
        var response = await productQueryHandler.GetById(id, cancellationToken);
        return Result.From(response, response.Content);
    }
}