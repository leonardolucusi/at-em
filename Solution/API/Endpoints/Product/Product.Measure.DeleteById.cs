using API.Endpoints.Validation;
using Application.Command.Interface;

namespace API.Endpoints.Product;

internal partial class ProductGroup
{
    private static async Task<IResult> DeleteMeasureById(
        int id,
        IMeasureCommandHandler measureCommandHandler,
        CancellationToken cancellationToken)
    {
        var response = await measureCommandHandler.DeleteById(id, cancellationToken);
        return Result.From(response, response.Content);
    }
}