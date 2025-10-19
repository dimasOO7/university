using System;

class Program()
{
    static void Main(string[] args)
    {
        try
        {
            double a, b, c;
            string strA, strB;
            Console.WriteLine("введите число a");
            strA = Console.ReadLine();
            while (!double.TryParse(strA, out a))
            {
                Console.WriteLine("Введи число, а не букву, гений");
                strA = Console.ReadLine();
            }
            Console.WriteLine("введите число b");
            strB = Console.ReadLine();
            while (!double.TryParse(strB, out b))
            {
                Console.WriteLine("Введи число, а не букву, гений");
                strB = Console.ReadLine();
            }
            c = -4 * Math.Pow(Math.Sin(a * 3), 3) + Math.Sqrt(b) / Math.Log(b + 2);
            Console.WriteLine($"результат вычисления: {c}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Произошло деление на ноль: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("ошибка: " + ex.Message);
        }
    }
}