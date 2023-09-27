namespace Building;

public static class ExtConsole
{
    public static void ShowError(String errorText)
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

    public static String? TakeInput(String inputPrompt)
    {
        ConsoleColor prevForeColor = Console.ForegroundColor;
        ConsoleColor prevBackColor = Console.BackgroundColor;

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write($" {inputPrompt} > ");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.BackgroundColor = ConsoleColor.Black;
        String? consoleInput = Console.ReadLine();

        Console.ForegroundColor = prevForeColor;
        Console.BackgroundColor = prevBackColor;

        return consoleInput;
    }

    public static Int32? TakeInt32(String inputPrompt)
    {
        String? consoleInput = TakeInput(inputPrompt);
        return String.IsNullOrWhiteSpace(consoleInput) 
            ? null 
            : !Int32.TryParse(consoleInput, out Int32 userChoice) 
                ? throw new ArgumentException("Значення не є числом") : userChoice;
    }

    public static Int32 AsNotNull(this Int32? value)
    {
        return value == null ? throw new ArgumentException("Значення не повинно бути пустим") : value.Value;
    }

    public static Int32 BelongsToSet(this Int32 value, IEnumerable<Int32> set)
    {
        HashSet<Int32> uniqueValues = new (set);
        return !uniqueValues.Contains(value)
            ? throw new ArgumentException($"Число повинно бути одним із: {{{String.Join(", ", uniqueValues.Order())}}}")
            : value;
    }
}
