using Application.DTO.Common;
using Application.DTO.Validator;
using Domain.Validations;
using FluentValidation;

namespace Application.DTO.Product.Create;

public record ProductCreateDto : IDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Type { get; set; }
    public required string Manufacturer { get;set; }
    public required double SellingPrice { get; set; }
}

public class ProductCreateValidator : AbstractValidator<ProductCreateDto>
{
    public ProductCreateValidator()
    {
        RuleFor(x => x.Name).NotEmpty()
            .WithMessage(ValidatorUtils.RuleMessage_CannotBeNullOrEmpty(nameof(ProductCreateDto.Name)))
            .WithErrorCode(nameof(ValidationCodes.Code.Required));
    }
}

/*
 *
 * RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage(ValidatorUtils.RuleMessage_CannotBeNullOrEmpty(nameof(ConsumidorCadastrarDto.Nome)))
            .WithErrorCode(nameof(ValidationCodes.Code.Required));
        
        RuleFor(x => x.Nome)
            .Length(3, 100)
            .WithMessage(ValidatorUtils.RuleMessage_MinMaxCharacters(3, 100))
            .WithErrorCode(nameof(ValidationCodes.Code.InvalidLengthRange));
            
        RuleFor(x => x.Nome)
            .Matches(@"^[\p{L}\s]+$") 
            .WithMessage(ValidatorUtils.RuleMessage_CannotNumsOrSymbols())
            .WithErrorCode(nameof(ValidationCodes.Code.DoNotMatch));

        RuleFor(x => x.Cpf)
            .NotEmpty()
            .WithMessage(ValidatorUtils.RuleMessage_CannotBeNullOrEmpty(nameof(ConsumidorCadastrarDto.Cpf)))
            .WithErrorCode(nameof(ValidationCodes.Code.Required));
        
        RuleFor(x => x.Cpf)
            .Length(14)
            .WithMessage(ValidatorUtils.RuleMessage_ExactCharacters(14))
            .WithErrorCode(nameof(ValidationCodes.Code.InvalidLength));
        
        RuleFor(x => x.Cpf)
            .Matches(@"^[\d\-.]+$")
            .WithMessage(ValidatorUtils.RuleMessage_OnlyNumbersDashesAndDots())
            .WithErrorCode(nameof(ValidationCodes.Code.DoNotMatch));
        
        RuleFor(x => x.DataNascimento)
            .NotEmpty()
            .WithMessage(ValidatorUtils.RuleMessage_CannotBeNullOrEmpty(nameof(ConsumidorCadastrarDto.DataNascimento)))
            .WithErrorCode(nameof(ValidationCodes.Code.Required));
            
        RuleFor(x => x.DataNascimento)
            .Must(data => data.ToUniversalTime() <= DateTime.UtcNow)
            .WithMessage($"A {nameof(ConsumidorCadastrarDto.DataNascimento)} não pode ser no futuro.")
            .WithErrorCode(nameof(ValidationCodes.Code.DoNotMatch));
            
        RuleFor(x => x.DataNascimento)
            .Must(data => data.ToUniversalTime() >= DateTime.UtcNow.AddYears(-100))
            .WithMessage($"A {nameof(ConsumidorCadastrarDto.DataNascimento)} não pode ser superior a 100 anos.")
            .WithErrorCode(nameof(ValidationCodes.Code.DoNotMatch));
        
        RuleFor(x => x.Cep)
            .Length(8)
            .WithMessage(ValidatorUtils.RuleMessage_ExactCharacters(8))
            .WithErrorCode(nameof(ValidationCodes.Code.InvalidLength));
        
        RuleFor(x => x.Cep)
            .Matches(@"^\d+$")
            .WithMessage(ValidatorUtils.RuleMessage_OnlyNumbers())
            .WithErrorCode(nameof(ValidationCodes.Code.DoNotMatch));
        
        RuleFor(x => x.Endereco)
            .MaximumLength(100)
            .WithMessage(ValidatorUtils.RuleMessage_MaxCharacters(100))
            .WithErrorCode(nameof(ValidationCodes.Code.GreaterThanExpected));
        
        RuleFor(x => x.Bairro)
            .MaximumLength(100)
            .WithMessage(ValidatorUtils.RuleMessage_MaxCharacters(100))
            .WithErrorCode(nameof(ValidationCodes.Code.GreaterThanExpected));

        RuleFor(x => x.Cidade)
            .MaximumLength(100)
            .WithMessage(ValidatorUtils.RuleMessage_MaxCharacters(100))
            .WithErrorCode(nameof(ValidationCodes.Code.GreaterThanExpected));
        
        RuleFor(x => x.Uf)
            .Matches(@"^(?:[A-Z]{2}|)$")
            .WithMessage(ValidatorUtils.RuleMessage_OnlyUpperCaseLettersMaxRange(nameof(ConsumidorCadastrarDto.Uf), 2))
            .WithErrorCode(nameof(ValidationCodes.Code.DoNotMatch));
        
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(ValidatorUtils.RuleMessage_CannotBeNullOrEmpty(nameof(ConsumidorCadastrarDto.Email)))
            .WithErrorCode(nameof(ValidationCodes.Code.Required));
        
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage(ValidatorUtils.RuleMessage_InvalidEmail())
            .WithErrorCode(nameof(ValidationCodes.Code.InvalidEmailAddress));
        
        RuleFor(x => x.Senha)
            .NotEmpty()
            .WithMessage(ValidatorUtils.RuleMessage_CannotBeNullOrEmpty(nameof(ConsumidorCadastrarDto.Senha)))
            .WithErrorCode(nameof(ValidationCodes.Code.Required));
            
        RuleFor(x => x.Senha)
            .Length(6, 100)
            .WithMessage(ValidatorUtils.RuleMessage_MinMaxCharacters(6, 100))
            .WithErrorCode(nameof(ValidationCodes.Code.InvalidLengthRange));
 *
 * 
 */