namespace Application.Validation;

internal static class ValidationUtils
{
    internal static string ValidOperation_Created(Type type) =>
        $"Object: '{type.Name}' created successfully!";
    
    internal static string ValidOperation_Ok() =>
        "Operation successfully completed!";

    internal static string ValidOperation_NoContent() =>
        "Operation completed successfully, no content!";
    
    internal static string InvalidOperation_NotFound() =>
        "Item not found!";
    
    internal static string InvalidOperation_WrongCredentials() =>
        "Invalid credential!";
}