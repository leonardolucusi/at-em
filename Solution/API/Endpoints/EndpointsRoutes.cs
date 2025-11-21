namespace API.Endpoints;

internal static class EndpointsRoutes
{
    internal const string RotaIdentity = "/identity";
    
    internal const string RouteProduct = "/product";
    internal static string SummaryBuilder(Type type, Delegate @delegate) =>
        $"This endpoint will execute the method '{type.Name}.{@delegate.Method.Name}()'";
}