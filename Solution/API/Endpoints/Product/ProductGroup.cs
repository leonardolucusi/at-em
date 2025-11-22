using Application.DTO.Common;
using Application.Responses.Common;

namespace API.Endpoints.Product;

internal static partial class ProductGroup
{
    internal static void Map(WebApplication app)
    {
        app.MapPost("/api/v1/product", CreateProduct)
            .AllowAnonymous()
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status201Created)
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status409Conflict)
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status422UnprocessableEntity)
            .WithTags(nameof(ProductGroup))
            .WithSummary(EndpointsRoutes.SummaryBuilder(typeof(ProductGroup), CreateProduct));
        
        app.MapPut("/api/v1/product", UpdateProduct)
            .AllowAnonymous()
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status201Created)
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status409Conflict)
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status422UnprocessableEntity)
            .WithTags(nameof(ProductGroup))
            .WithSummary(EndpointsRoutes.SummaryBuilder(typeof(ProductGroup), UpdateProduct));
    }
}
