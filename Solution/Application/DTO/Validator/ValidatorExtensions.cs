using FluentValidation.Results;

namespace Application.DTO.Validator;

public static class ValidatorExtensions
{
    private static readonly IdValidator _idValidator = new();
    private static readonly NumberValidator _numberValidator = new();
    
    public static bool IsValidId(int id, out List<ValidationFailure>? validations)
    {
        var result = _idValidator.Validate(id);
        if (!result.IsValid)
        {
            validations = result.Errors;
            return false;
        }

        validations = null;
        return true;
    }
    
    public static bool IsValidNumber(int number, out List<ValidationFailure>? validations)
    {
        var result = _numberValidator.Validate(number);
        if (!result.IsValid)
        {
            validations = result.Errors;
            return false;
        }

        validations = null;
        return true;
    }
}