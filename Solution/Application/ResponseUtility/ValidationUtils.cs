namespace Application.ResponseUtility;

public static class ValidationUtils
{
    public static string ValidOperation_Created(Type type) =>
        $"Object: '{type.Name}' created successfully!";
    
    public static string ValidOperation_Ok() =>
        "Operation successfully completed!";

    public static string ValidOperation_NoContent() =>
        "Operation successfully completed!";
    
    public static string InvalidOperation_NotFound() =>
        "Object sought not found!";
    
    public static string InvalidOperation_WrongCredentials() =>
        "Invalid credentials!";
}