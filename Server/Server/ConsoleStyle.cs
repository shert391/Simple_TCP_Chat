internal static class ConsoleStyle
{
    public static void WriteConsoleColor(string text, ConsoleColor color, bool writeLine = false)
    {
        Console.ForegroundColor = color;
        if (writeLine) Console.WriteLine(text);
        else Console.Write(text);
        Console.ResetColor();
    }

    public static void AlertConsole(string name, string context)
    {
        WriteConsoleColor($"{name} ", ConsoleColor.Cyan);
        WriteConsoleColor(context, ConsoleColor.Yellow);
        Console.WriteLine();
    }
}

