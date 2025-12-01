using Domain.Validations;
using FluentValidation;

namespace Application.DTOs.Validator;

public class IdValidator : AbstractValidator<int>
{
    public IdValidator()
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage($"Id não pode ser vazio.")
            .WithErrorCode(nameof(ValidationCodes.Code.Required));
        
        RuleFor(x => x)
            .GreaterThan(0)
            .WithMessage("Id não deve ser zero ou negativo.")
            .WithErrorCode(nameof(ValidationCodes.Code.LesserThanExpected));
    }
}