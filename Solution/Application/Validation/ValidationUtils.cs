namespace Application.Validation;

internal static class ValidationUtils
{
    internal static string ValidOperation_Created(Type type) =>
        $"Objeto: '{type.Name}' criado com sucesso!";
    
    // TODO: Improve OK validation message later on...
    internal static string ValidOperation_Ok() =>
        "Operação realizada com sucesso!";

    // TODO: Improve NoContent validation message later on...
    internal static string ValidOperation_NoContent() =>
        "Operação realizada com sucesso!";
    
    internal static string InvalidOperation_NotFound() =>
        "Objeto procurado não encontrado!";
    
    internal static string InvalidOperation_WrongCredentials() =>
        "Credencial inválida!";
}