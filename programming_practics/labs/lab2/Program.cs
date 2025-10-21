using System;

namespace Lab2
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
                    Console.WriteLine("Ошибка ввода: отрицательное число или 0");
                }
            }
            return result;
        }

        static bool Calculator()
        {
            try
            {
                const float km100Coef = 100;
                const float carCoef = 1;
                const float truckCoef = 1.2F;
                const float bikeCoef = 0.85F;
                const float winterCoef = 1.1F;
                const float summerCoef = 1;
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
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("ошибка переполнения:\n" + ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("вызвано исключение:\n" + ex);
            }
            finally

            {
                Console.WriteLine("расчёт завершён");
            }
            while (true)
            {
                Console.Write("Хотите сделать ещё один расчёт? (да/нет): ");
                switch (Console.ReadLine())
                {
                    case "да":
                        return true;
                    case "нет":
                        return false;
                    default:
                        Console.WriteLine("Ошибка ввода");
                        break;
                }
            }
        }

        static void Main()
        {
            bool runningFlag = true;

            while (runningFlag)
            {
                bool inputFlag = true;
                while (inputFlag)
                {
                    Console.WriteLine("=== Калькулятор стоимости поездки ===");
                    Console.WriteLine("1. Рассчитать поездку");
                    Console.WriteLine("2. Выйти");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            runningFlag = Calculator();
                            inputFlag = false;
                            break;
                        case "2":
                            runningFlag = false;
                            inputFlag = false;
                            break;

                        default:
                            Console.WriteLine("Ошибка ввода");
                            break;
                    }
                }
            }
        }
    }
}