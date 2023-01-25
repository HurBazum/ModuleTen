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
            ConsoleKeyInfo key = Console.ReadKey();
            if(key.Key != ConsoleKey.Escape)
            {
                switch(key.Key) 
                {
                    case ConsoleKey.Backspace: Console.Clear();break;
                    default: Console.CursorLeft = 0; break;
                }
            }
            else
            {
                break;
            }
        }
    }
}