using System.Runtime.InteropServices;
using Spectre.Console;

namespace daeta.utils;

public static class Processing
{
    [UnmanagedCallersOnly(EntryPoint = "multiply")]
    public static int Multiply(int x, int y) => x * y;

    [UnmanagedCallersOnly(EntryPoint = "write_line")]
    public static int WriteLine(IntPtr pMessage)
    {
        try
        {
            string? message = Marshal.PtrToStringAnsi(pMessage);

            if (message is not null)
            {
                AnsiConsole.MarkupLine($"[red]{message}[/] via [green]Spectre.Console[/]");
            }
        }
        catch
        {
            return -1;
        }

        return 0;
    }
}