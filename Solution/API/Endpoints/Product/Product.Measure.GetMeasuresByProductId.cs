using API.Endpoints.Validation;
using Application.Query.Interface;

namespace API.Endpoints.Product;

internal partial class ProductGroup
{
    private static async Task<IResult> GetMeasuresByProductId(
        int id,
        IMeasureQueryHandler measureQueryHandler,
        CancellationToken cancellationToken)
    {
        var response = await measureQueryHandler.GetMeasuresByProductId(id, cancellationToken);
        return Result.From(response, response.Content);
    }
}