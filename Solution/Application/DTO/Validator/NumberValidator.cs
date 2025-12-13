using Domain.Validations;
using FluentValidation;

namespace Application.DTO.Validator;

public class NumberValidator : AbstractValidator<int>
{
    public NumberValidator()
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage($"Number cannot be empty.")
            .WithErrorCode(nameof(ValidationCodes.Code.Required));
        
        RuleFor(x => x)
            .GreaterThan(0)
            .WithMessage("Number cannot be 0 or negative.")
            .WithErrorCode(nameof(ValidationCodes.Code.LesserThanExpected));
    }
}