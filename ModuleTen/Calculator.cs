using System.Numerics;

class Calculator : ISummator
{
    ILogger Logger { get; }
    public Calculator(ILogger logger)
    {
        Logger = logger;
    }
    public void Sum()
    {
        //-2 147 483 648
        Console.WriteLine("Введите несколько чисел(два, например), сумму которых хотите узнать, через пробел:");
        string[] numbers = Console.ReadLine().Split(" ");
        int result;// непосредственно результат сложения
        // для случаев, когда введены числа сумма которых не помещается в int, но нет ошибки e.g.
        // int.MinValue + int.MinValue = 0 - вывод программы
        BigInteger bigResult = new(0); 
        for (int i = 0; i < numbers.Length; i++)
        {
            try
            {
                if(BigInteger.TryParse(numbers[i], out BigInteger a))
                {
                    if (bigResult == 0)
                    {
                        bigResult = a;
                    }
                    else
                    {
                        bigResult += a;
                    }
                }
                else
                {
                    throw new FormatException();
                }
                if (i == numbers.Length - 1)
                {
                    result = (int)bigResult;
                    Logger.Event($"{string.Join(" + ", numbers)} = {result}");
                }
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                break;
            }
        }
    }
}