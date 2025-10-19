namespace Lab1
{
    class Program()
    {
        static void Main(String[] args)
        {
            double distance;
            double fuelConsumption;
            double fuelCostLiter;
            Console.Write("Введите расстояние (в км): ");
            while (!Double.TryParse(Console.ReadLine(), out distance))
            {
                Console.WriteLine("Ошибка ввода");
                Console.Write("Введите расстояние (в км): ");
            }
            Console.Write("Введите средний расход топлива на 100 км (в литрах): ");
            while (!Double.TryParse(Console.ReadLine(), out fuelConsumption))
            {
                Console.WriteLine("Ошибка ввода");
                Console.Write("Введите средний расход топлива на 100 (в литрах): ");
            }
            Console.Write("Введите цену топлива за литр (в рублях): ");
            while (!Double.TryParse(Console.ReadLine(), out fuelCostLiter))
            {
                Console.WriteLine("Ошибка ввода");
                Console.Write("Введите  цену топлива за литр (в рублях): ");
            }

            double fuelConsumed = fuelConsumption * (distance * 0.01);
            double totalCost = fuelConsumed * fuelCostLiter;
            Console.WriteLine($"Итоговая стоимость поездки: {totalCost:F2}");
        }
    }
}