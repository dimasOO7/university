using System;

class Program()
{
    static void Main()
    {
        double a;
        double b;
        double c;
        Console.WriteLine("введите a");
        while (!Double.TryParse(Console.ReadLine(), out a))
        {
            Console.WriteLine("ошибка ввода");
        }
        Console.WriteLine("введите b");
        while (!Double.TryParse(Console.ReadLine(), out b))
        {
            Console.WriteLine("ошибка ввода");
        }
        Console.WriteLine("введите c");
        while (!Double.TryParse(Console.ReadLine(), out c))
        {
            Console.WriteLine("ошибка ввода");
        }
        double D = b * b - 4 * a * c;
        if (D < 0)
        {
            Console.WriteLine("нет корней");
        }
        else if (D == 0)
        {
            double x = -b / 2 / a;
            Console.WriteLine($"только 1 корень: {x}");
        }
        else
        {
            double x1 = (-b + Math.Sqrt(D)) / 2 / a;
            double x2 = (-b - Math.Sqrt(D)) / 2 / a;
            Console.WriteLine($"первый корень: {x1}");
            Console.WriteLine($"второй корень: {x2}");
        }
    }
}