using System;

class Program()
{
    static void Main()
    {
        Console.WriteLine("введите расстояние в километрах");
        double km;
        const double k = 0.621371;
        while (!Double.TryParse(Console.ReadLine(), out km))
        {
            Console.WriteLine("ошибка ввода");
        }
        double miles = km * k;
        Console.WriteLine($"расстояние в милях: {miles:F2}");
    }
}