using System.Reflection;

namespace Application;

public static class ApplicationLayerAssemblies
{
    public static Assembly[] GetAssemblies() => AppDomain.CurrentDomain.GetAssemblies();
}