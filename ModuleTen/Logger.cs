public class Logger : ILogger
{
    public void Event(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    public void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    public void Repeat()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nЧтобы закончить нажмите - Escape! Иначе - любую клавишу!\n" +
            "Для того чтобы очистить консоль - нажмите Backspace!\n");
        Console.ResetColor();
    }
}
