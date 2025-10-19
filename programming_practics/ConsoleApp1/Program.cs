using System;

class Program()
{
    static void Main(String[] args)
    {
        double b;
        double a;
        Console.WriteLine("Введите длинну");
        while (!Double.TryParse(Console.ReadLine(), out a))
        {
            Console.WriteLine("ошибка ввода");
        }
        Console.WriteLine("Введите ширину");
        while (!Double.TryParse(Console.ReadLine(), out b))
        {
            Console.WriteLine("ошибка ввода");
        }
        double P = 2 * (a + b);
        double S = a * b;
        Console.WriteLine($"Периметр {P:F2}");
        Console.WriteLine($"Площадь: {S:F2}");
    }
}