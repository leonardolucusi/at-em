using Application.Command.Interface;
using Application.DTO.Measure.Create;
using Application.DTO.Product.Create;
using Application.DTO.Product.CreateWithMeasure;
using Application.DTO.Product.Update;
using Application.Responses.Common;
using Application.Validation;
using AutoMapper;
using Domain.Product;
using Domain.Validations;
using FluentValidation;
using Infrastructure.Repository.Interface;
using Infrastructure.UnitOfWork;

namespace Application.Command;

public class ProductCommandCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IRepository<Product> productRepository,
    IRepository<Measure> measureRepository,
    IValidator<ProductCreateDto> productCreateValidator,
    IValidator<ProductUpdateDto> productUpdateValidator,
    IValidator<ProductMeasureCreateDto> productMeasureCreateValidator,
    IValidator<NoProductIdMeasureCreateDto> noProductIdMeasureCreateValidator,
    ValidationResult validationResult) : IProductCommandHandler
{
    public async Task<CommonResponse<ProductCreatedDto>> Create(
        ProductCreateDto productCreateDto,
        CancellationToken cancellationToken = default)
    {
        validationResult.GetDataFromFluentValidationResult(productCreateValidator.Validate(productCreateDto));
        if (validationResult.Validity is false)
        {
            return new CommonResponse<ProductCreatedDto>()
            {
                Content = null,
                ValidationResult = validationResult
            };
        }

        await unitOfWork.BeginTransaction(cancellationToken);

        var product = await productRepository.Add(mapper.Map<Product>(productCreateDto), cancellationToken);

        await unitOfWork.CommitTransaction(cancellationToken);

        validationResult.Add(ValidationCodes.Code.Created,
            ValidationUtils.ValidOperation_Created(typeof(ProductCreatedDto)), true);
        return new CommonResponse<ProductCreatedDto>()
        {
            Content = mapper.Map<ProductCreatedDto>(product),
            ValidationResult = validationResult
        };
    }

    public async Task<CommonResponse<ProductMeasureCreatedDto>> CreateWithMeasure(
        ProductMeasureCreateDto dto, CancellationToken cancellationToken = default)
    {
        validationResult.GetDataFromFluentValidationResult(
            productMeasureCreateValidator.Validate(dto));
        if (validationResult.Validity is false)
        {
            return new CommonResponse<ProductMeasureCreatedDto>
            {
                Content = null,
                ValidationResult = validationResult
            };
        }

        if (dto.Measures is not null && dto.Measures.Count > 0)
        {
            dto.Measures.ForEach(measure =>
                validationResult.GetDataFromFluentValidationResult(noProductIdMeasureCreateValidator.Validate(measure)));
            if (validationResult.Validity is false)
            {
                return new CommonResponse<ProductMeasureCreatedDto>
                {
                    Content = null,
                    ValidationResult = validationResult
                };
            }
        }

        await unitOfWork.BeginTransaction(cancellationToken);
        var productEntity = await productRepository.Add(mapper.Map<Product>(dto), cancellationToken);
        await productRepository.Save(cancellationToken);
        
        var measures = dto.Measures?.Select(x => new MeasureCreateDto
        {
            ProductId = productEntity.Id,
            Height = x.Height,
            Width = x.Width,
            Depth = x.Depth,
            Weight = x.Weight 
        });
        
        await measureRepository.AddRange(measures?.Select(mapper.Map<Measure>)!,
            cancellationToken: cancellationToken);
        
        await unitOfWork.CommitTransaction(cancellationToken);

        validationResult.Add(ValidationCodes.Code.Created,
            ValidationUtils.ValidOperation_Created(typeof(ProductMeasureCreatedDto)), true);
        return new CommonResponse<ProductMeasureCreatedDto>
        {
            Content = mapper.Map<ProductMeasureCreatedDto>(productEntity),
            ValidationResult = validationResult
        };
    }

    public async Task<CommonResponse<ProductUpdatedDto>> Update(
        ProductUpdateDto productUpdateDto,
        CancellationToken cancellationToken = default)
    {
        validationResult.GetDataFromFluentValidationResult(productUpdateValidator.Validate(productUpdateDto));
        if (validationResult.Validity is false)
        {
            return new CommonResponse<ProductUpdatedDto>
            {
                Content = null,
                ValidationResult = validationResult
            };
        }

        await unitOfWork.BeginTransaction(cancellationToken);

        var productEntity = await productRepository.GetById(productUpdateDto.Id, false, cancellationToken);
        if (productEntity is null)
        {
            validationResult.Add(ValidationCodes.Code.NotFound, ValidationUtils.InvalidOperation_NotFound(), false);
            return new CommonResponse<ProductUpdatedDto>
            {
                Content = null,
                ValidationResult = validationResult
            };
        }

        var product = await productRepository.Update(mapper.Map<Product>(productUpdateDto), cancellationToken);

        await unitOfWork.CommitTransaction(cancellationToken);

        validationResult.Add(ValidationCodes.Code.Ok, ValidationUtils.ValidOperation_Ok(), true);
        return new CommonResponse<ProductUpdatedDto>
        {
            Content = mapper.Map<ProductUpdatedDto>(product),
            ValidationResult = validationResult
        };
    }
}