using System;

namespace Lab1
{
    class Program()
    {
        static double InputDouble(string text)
        {
            double result = 0;
            while (result <= 0)
            {
                Console.Write(text);
                while (!Double.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine("Ошибка ввода");
                    Console.Write(text);
                }
                if (result <= 0)
                {
                    Console.WriteLine("Ошика ввода: отрицательное число или 0");
                }
            }
            return result;
        }
        static void Main()
        {
            const float km100Coef = 100;
            const float carCoef = 1;
            const float truckCoef = 1.2F;
            const float bikeCoef = 0.85F;
            const float winterCoef = 1.1F;
            const float summerCoef = 1;

            bool running_flag = true;

            while (running_flag)
            {
                float seasonCoef = 0;
                float typeCoef = 0;
                double distance = Program.InputDouble("Введите расстояние (в км): ");
                double fuelConsumption = Program.InputDouble("Введите средний расход топлива на 100 км (в литрах): ");
                double fuelCostLiter = Program.InputDouble("Введите  цену топлива за литр (в рублях): ");

                while (!(typeCoef > 0))
                {
                    int i;
                    Console.Write("Выберите транспорт: \n 1.Легковой \n 2.Грузовик \n 3.Мотоцикл \nВыбор: ");
                    while (!int.TryParse(Console.ReadLine(), out i))
                    {
                        Console.Write("Ошибка ввода\nВыберите транспорт: \n1.Легковой \n2.Грузовик \n3.Мотоцикл \nВыбор: ");
                    }
                    switch (i)
                    {
                        case 1:
                            typeCoef = carCoef;
                            break;
                        case 2:
                            typeCoef = truckCoef;
                            break;
                        case 3:
                            typeCoef = bikeCoef;
                            break;
                        default:
                            Console.WriteLine("выбран неверный пункт меню");
                            break;
                    }
                }
                while (!(seasonCoef > 0))
                {
                    int i;
                    Console.Write("Выберите сезон: \n1.Лето \n2.Зима \nВыбор: ");
                    while (!int.TryParse(Console.ReadLine(), out i))
                    {
                        Console.Write("Ошибка ввода\nВыберите сезон: \n1.Лето \n2.Зима \nВыбор: ");
                    }
                    switch (i)
                    {
                        case 1:
                            seasonCoef = summerCoef;
                            break;
                        case 2:
                            seasonCoef = winterCoef;
                            break;
                        default:
                            Console.WriteLine("выбран неверный пункт меню");
                            break;
                    }
                }
                double fuelConsumed = fuelConsumption * (distance / km100Coef) * typeCoef;
                decimal costNoSeason = (decimal)(fuelConsumed * fuelCostLiter);
                decimal totalCost = costNoSeason * (decimal)seasonCoef;
                float seasonCoefProcent = (seasonCoef - 1) * 100;

                Console.WriteLine("=== Результаты расчета ===");
                Console.WriteLine($"Расход топлива: {fuelConsumed:F1}");
                Console.WriteLine($"Стоимость топлива: {costNoSeason:F2}");
                Console.WriteLine($"Сезонный коэффициент: {seasonCoefProcent:F0}%");
                Console.WriteLine($"Итоговая стоимость поездки: {totalCost:F2}");
                bool? current_running_flag = null;
                while (current_running_flag == null)
                {
                    Console.Write("Хотите сделать ещё один расчёт? (да/нет): ");
                    switch (Console.ReadLine())
                    {
                        case "да":
                            current_running_flag = true;
                            break;
                        case "нет":
                            current_running_flag = false;
                            break;
                        default:
                            Console.WriteLine("Ошибка ввода");
                            break;
                    }
                }
                running_flag = (bool)current_running_flag;
            }
        }
    }
}