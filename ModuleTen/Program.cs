using System.Runtime.CompilerServices;

class Program
{
    static ILogger Logger { get; set; }
    static void Main(string[] args)
    {
        Logger = new Logger();
        Calculator calculator = new(Logger);
        while (true)
        {
            calculator.Sum();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nЧтобы закончить нажмите - Escape!\n");
            Console.ResetColor();
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                break;
            }
        }
    }
}