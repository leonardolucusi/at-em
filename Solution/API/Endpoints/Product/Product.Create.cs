using Application.Command.Interface;
using Application.DTO.Product.Create;
using Application.ResponseUtility;

namespace API.Endpoints.Product;

internal partial class ProductGroup
{
    private static async Task<Response> CreateProduct(
        ProductCreateDto productCreateDto,
        IProductHandler productHandler,
        CancellationToken cancellationToken)
    {
        var response = await productHandler.HandleAdd(productCreateDto, cancellationToken);
        return response;
    }
}