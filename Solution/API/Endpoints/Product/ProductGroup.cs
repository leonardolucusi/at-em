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
        
        app.MapPost("/api/v1/product/measures", CreateProductWithMeasures)
            .AllowAnonymous()
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status201Created)
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status409Conflict)
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status422UnprocessableEntity)
            .WithTags(nameof(ProductGroup))
            .WithSummary(EndpointsRoutes.SummaryBuilder(typeof(ProductGroup), CreateProductWithMeasures));
        
        app.MapPut("/api/v1/product", UpdateProduct)
            .AllowAnonymous()
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status201Created)
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status409Conflict)
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status422UnprocessableEntity)
            .WithTags(nameof(ProductGroup))
            .WithSummary(EndpointsRoutes.SummaryBuilder(typeof(ProductGroup), UpdateProduct));
                
        app.MapDelete("/api/v1/product", DeleteProductWithMeasures)
            .AllowAnonymous()
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status201Created)
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status409Conflict)
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status422UnprocessableEntity)
            .WithTags(nameof(ProductGroup))
            .WithSummary(EndpointsRoutes.SummaryBuilder(typeof(ProductGroup), DeleteProductWithMeasures));
        
        app.MapGet("/api/v1/product", GetByIdWithMeasures)
            .AllowAnonymous()
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status201Created)
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status409Conflict)
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status422UnprocessableEntity)
            .WithTags(nameof(ProductGroup))
            .WithSummary(EndpointsRoutes.SummaryBuilder(typeof(ProductGroup), GetByIdWithMeasures));
        
        app.MapPut("/api/v1/product/measure", UpdateMeasure)
            .AllowAnonymous()
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status201Created)
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status409Conflict)
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status422UnprocessableEntity)
            .WithTags(nameof(ProductGroup))
            .WithSummary(EndpointsRoutes.SummaryBuilder(typeof(ProductGroup), UpdateMeasure));

        
        app.MapPost("/api/v1/product/measure", CreateMeasure)
            .AllowAnonymous()
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status201Created)
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status409Conflict)
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status422UnprocessableEntity)
            .WithTags(nameof(ProductGroup))
            .WithSummary(EndpointsRoutes.SummaryBuilder(typeof(ProductGroup), CreateMeasure));
        
        app.MapGet("/api/v1/product/measures", GetMeasuresByProductId)
            .AllowAnonymous()
            .Produces<CommonListResponse<CommonResultDto>>(StatusCodes.Status201Created)
            .Produces<CommonListResponse<CommonResultDto>>(StatusCodes.Status409Conflict)
            .Produces<CommonListResponse<CommonResultDto>>(StatusCodes.Status422UnprocessableEntity)
            .WithTags(nameof(ProductGroup))
            .WithSummary(EndpointsRoutes.SummaryBuilder(typeof(ProductGroup), GetMeasuresByProductId));
        
        app.MapDelete("/api/v1/product/measure", DeleteMeasureById)
            .AllowAnonymous()
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status201Created)
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status409Conflict)
            .Produces<CommonResponse<CommonResultDto>>(StatusCodes.Status422UnprocessableEntity)
            .WithTags(nameof(ProductGroup))
            .WithSummary(EndpointsRoutes.SummaryBuilder(typeof(ProductGroup), DeleteMeasureById));
        
    }
}
