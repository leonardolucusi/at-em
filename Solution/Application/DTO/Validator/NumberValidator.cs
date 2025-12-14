using Domain.Validations;
using FluentValidation;

namespace Application.DTO.Validator;

public class NumberValidator : AbstractValidator<int>
{
    public NumberValidator()
    {
        RuleFor(x => x)
            .GreaterThan(-1)
            .WithMessage("Number cannot be negative.")
            .WithErrorCode(nameof(ValidationCodes.Code.LesserThanExpected));
    }
}