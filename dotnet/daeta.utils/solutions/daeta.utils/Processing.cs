using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace daeta.utils;

public static class Processing
{
    [UnmanagedCallersOnly(EntryPoint = "multiply")]
    public static int Multiply(int x, int y) => x * y;
}