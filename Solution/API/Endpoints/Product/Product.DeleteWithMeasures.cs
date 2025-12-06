using API.Endpoints.Validation;
using Application.Command.Interface;

namespace API.Endpoints.Product;

internal partial class ProductGroup{
    private static async Task<IResult> DeleteProductWithMeasures(
        int id, 
        IProductCommandHandler productCommandHandler,
        CancellationToken cancellationToken)
    {
        var response = await productCommandHandler.DeleteWithMeasures(id, cancellationToken);
        return Result.From(response, response.Content);
    }
}