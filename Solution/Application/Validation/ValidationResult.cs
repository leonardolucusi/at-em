using Domain.Validations;

namespace Application.Validation;

public class ValidationResult
{
    public ValidationResult() {}
    
    public ValidationResult(FluentValidation.Results.ValidationResult? fluentValidationResult) =>
        GetDataFromFluentValidationResult(fluentValidationResult);

    public ValidationResult(ValidationCodes.Code code, string message, bool isValid) =>
        Add(code, message, isValid);

    public List<string> Messages { get; } = []; 
    public List<ValidationCodes.Code> Codes { get; } = [];
    public bool Validity { get; private set; } = true; 

    public void GetDataFromFluentValidationResult(
        FluentValidation.Results.ValidationResult? fluentValidationResult)
    {
        fluentValidationResult?.Errors?.ForEach(x =>
        {
            Messages.Add($"{x.PropertyName}: {x.ErrorMessage}");
            Codes.Add(ValidationCodes.CodesDictionary[x.ErrorCode]);
            Validity = fluentValidationResult.IsValid;
        });
    }

    public void Add(ValidationCodes.Code code, string message, bool isValid)
    {
        Messages.Add(message);
        Codes.Add(code);
        Validity = isValid;
    }

    public ValidationResult AddAndGet(ValidationCodes.Code code, string message, bool isValid)
    {
        Messages.Add(message);
        Codes.Add(code);
        Validity = isValid;
        return this;
    }
    
}