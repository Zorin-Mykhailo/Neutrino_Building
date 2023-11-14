namespace Building;

public static class ExtConsole
{
    public static void Out(this string text, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
    {
        ConsoleColor prevForeColor = Console.ForegroundColor;
        ConsoleColor prevBackColor = Console.BackgroundColor;

        Console.ForegroundColor = foregroundColor ?? prevForeColor;
        Console.BackgroundColor = backgroundColor ?? prevBackColor;

        Console.Write(text);

        Console.ForegroundColor = prevForeColor;
        Console.BackgroundColor = prevBackColor;
    }

    public static void OutLine(this string text, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
    {
        ConsoleColor prevForeColor = Console.ForegroundColor;
        ConsoleColor prevBackColor = Console.BackgroundColor;

        Console.ForegroundColor = foregroundColor ?? prevForeColor;
        Console.BackgroundColor = backgroundColor ?? prevBackColor;

        Console.WriteLine(text);

        Console.ForegroundColor = prevForeColor;
        Console.BackgroundColor = prevBackColor;
    }

    public static void ShowError(string errorText)
    {
        ConsoleColor prevForeColor = Console.ForegroundColor;
        ConsoleColor prevBackColor = Console.BackgroundColor;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write($" ");

        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write(" ПОМИЛКА ");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine($" {errorText}");

        Console.ForegroundColor = prevForeColor;
        Console.BackgroundColor = prevBackColor;
    }

    public static string? TakeInput(string inputPrompt)
    {
        ConsoleColor prevForeColor = Console.ForegroundColor;
        ConsoleColor prevBackColor = Console.BackgroundColor;

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write($" {inputPrompt} > ");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.BackgroundColor = ConsoleColor.Black;
        string? consoleInput = Console.ReadLine();

        Console.ForegroundColor = prevForeColor;
        Console.BackgroundColor = prevBackColor;

        return consoleInput;
    }

    public static int? TakeInt32(string inputPrompt)
    {
        string? consoleInput = TakeInput(inputPrompt);
        return string.IsNullOrWhiteSpace(consoleInput) 
            ? null 
            : !int.TryParse(consoleInput, out int userChoice) 
                ? throw new ArgumentException("Значення не є числом") : userChoice;
    }

    public static int AsNotNull(this int? value)
    {
        return value == null ? throw new ArgumentException("Значення не повинно бути пустим") : value.Value;
    }

    public static int BelongsToSet(this int value, IEnumerable<int> set)
    {
        HashSet<int> uniqueValues = new (set);
        return !uniqueValues.Contains(value)
            ? throw new ArgumentException($"Число повинно бути одним із: {{{string.Join(", ", uniqueValues.Order())}}}")
            : value;
    }
}
