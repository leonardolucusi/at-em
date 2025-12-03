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
        var result = await productQueryHandler.GetById(id, cancellationToken);
        return Result.From(result, result.Content);
    }
}