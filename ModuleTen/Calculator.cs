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
        Console.WriteLine("Введите несколько чисел(два, например), сумму которых хотите узнать, через пробел:");
        string[] numbers = Console.ReadLine().Split(" ");

        Int64 result;// непосредственно результат сложения

        // для случаев, когда введены числа сумма которых не помещается в Int64, но нет ошибки e.g.
        // int.MinValue + int.MinValue = 0 - вывод программы
        BigInteger bigResult = new(0); 

        // выполняются небольшие преобразования элементов массива,
        // вычисляются переменные  result and bigResult
        // выводится результат на консоль
        for (int i = 0; i < numbers.Length; i++)
        {
            try
            {
                if(BigInteger.TryParse(numbers[i], out BigInteger a))
                {
                    if (i != 0)// если число отрицательное - выводится операция вычитания, иначе - сложения
                    {
                        if (numbers[i].Contains('-'))
                        {
                            numbers[i] = string.Concat(" - ", (a * (-1)).ToString());
                        }
                        else
                        {
                            numbers[i] = string.Concat(" + ", a.ToString());
                        }
                    }
                    else
                    {
                        numbers[i] = a.ToString();// если число введено с нолями впереди, e.g. -002
                    }
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
                    // на случай, если случайно после последнего числа был поставлен пробел
                    throw new FormatException($"Ошибка в {i} позиции, там указано:\"{numbers[i]}\"; Это не число!");
                }
                if (i == numbers.Length - 1)
                {
                    result = (Int64)bigResult;
                    Logger.Event($"{string.Concat(numbers)} = {result}");
                    Logger.Repeat();
                }
            }
            catch (Exception e)
            {
                Logger.Error(e.Message); 
                Logger.Repeat();
                break;
            }
        }
    }
}