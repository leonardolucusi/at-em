using FluentValidation.Results;

namespace Application.DTOs.Validator;

public static class ValidatorExtensions
{
    private static readonly IdValidator _idValidator = new();
    
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
}