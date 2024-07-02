using System.Reflection;

namespace CheckSPNs.Service;

public class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
