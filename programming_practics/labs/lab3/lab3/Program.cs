using System;
using System.Linq;

namespace Lab
{

    class Globals
    {
        public readonly static (string type, double coef)[] vehicles = { ("Машина", 0), ("Грузовик", 0.2), ("Мотоцикл", -0.15) };
        public readonly static (string season, double coef)[] seasonsTypes = { ("Лето", 0), ("Зима", 0.2) };
    }

    class History
    {
        private readonly int tripSavingCount;
        private (double distance, string vehicle, string season, double cost)[] trips;

        private ulong tripCount = 0;

        public History(int savingTrips)
        {
            tripSavingCount = savingTrips;
            trips =new (double, string, string, double)[savingTrips];
        }

        public void SaveTripToHistory(double distance, int vehicle, int season, double totalCost)
        {
            int index = (int)tripCount % tripSavingCount;

            trips[index] = (
                distance,
                Globals.vehicles[vehicle].type,
                Globals.seasonsTypes[season].season,
                totalCost
            );

            tripCount++;
        }

        private int GetRealIndex(int historyIndex)
        {
            return ((int)tripCount - historyIndex - 1) % tripSavingCount;
        }

        void ShowTrip(int arrayIndex, string text = "")
        {
            var trip = trips[arrayIndex];

            Console.WriteLine($"{text} {trip.distance:F2} км. {trip.season} {trip.vehicle} итоговая стоимость: {trip.cost:F2}");
        }

        public void ShowTripHistory()
        {
            if (tripCount > 0)
            {
                for (UInt16 i = 0; i < tripSavingCount && i < tripCount; i++)
                {
                    ShowTrip(GetRealIndex(i), $"{i + 1}:");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: нет поездок");
            }
            
        }

        private int GetMaximumIndex()
        {
            int limit = Math.Min(tripSavingCount, (int)tripCount);
            if (limit == 0) return 0;

            return Enumerable.Range(0, limit)
                .Aggregate((maxIndex, nextIndex) => trips[nextIndex].cost > trips[maxIndex].cost ? nextIndex : maxIndex);
        }

        private int GetMinimumIndex()
        {
            int limit = Math.Min(tripSavingCount, (int)tripCount);
            if (limit == 0) return 0;

            return Enumerable.Range(0, limit)
                .Aggregate((minIndex, nextIndex) => trips[nextIndex].cost < trips[minIndex].cost ? nextIndex : minIndex);
        }

        public void AnalyzeTrips()
        {
            switch (Menu.MenuSelection(["Самая дорогая поездка", "Самая дешёвая поездка", "Расчёт стоимости 1 км", "Поиск поездок по типу транспорта"], "=== Анализ поездок ==="))
            {
                case 0:
                    if (tripCount > 0)
                    {
                        ShowTrip(GetMaximumIndex(), "Самая дорогая поездка:");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: нет поездок");
                    }
                    break;
                case 1:
                    if (tripCount > 0)
                    {
                        ShowTrip(GetMinimumIndex(), "Самая дешёвая поездка:");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: нет поездок");
                    }
                    break;
                case 2:
                    double averageKmCost = GetAverageKmCost();
                    if (averageKmCost >= 0)
                    {
                        Console.WriteLine($"Средняя стоимость 1 км: {averageKmCost:F2}");
                    }
                    else
                    {
                        Console.WriteLine("Невозможно вычислить среднюю стоимость: нет поездок");
                    }
                    break;
                case 3:
                    string vehicle = Globals.vehicles[Menu.MenuSelection(["Легковой", "Грузовик", "Мотоцикл"], "Выберите транспорт: ")].type;
                    int[] indices = FindTripsPerVehicles(vehicle);
                    if (indices.Length > 0)
                    {
                        Console.WriteLine($"Все поездки на {vehicle}");
                        for (int i = 0; i < indices.Length; i++)
                        {
                            ShowTrip(indices[i], $"{i + 1}:");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"поездки на {vehicle} отсутствуют");
                    }

                    break;

            }
        }

        private double GetAverageKmCost()
        {
            double totalCost = trips.Take(tripSavingCount).Sum(t => t.cost);
            double totalDistance = trips.Take(tripSavingCount).Sum(t => t.distance);

            if (totalDistance == 0)
            {
                return -1;
            }

            return totalCost / totalDistance;
        }

        private int[] FindTripsPerVehicles(string vehicle)
        {
            int limit = Math.Min(tripSavingCount, (int)tripCount);

            return Enumerable.Range(0, limit)
                .Where(i => trips[i].vehicle == vehicle)
                .ToArray();
        }
    }
    class Program
    {
        static double InputDouble(string text)
        {
            while (true)
            {
                Console.Write(text);
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    if (value >= 0)
                    {
                        return value;
                    }
                    else
                    {
                        Console.WriteLine("Введите неотрицательное число");
                    }
                }
                else
                {
                    Console.WriteLine("");
                }
            }
        }

        static int InputInt(string text, int min, int max)
        {
            while (true)
            {
                Console.Write(text);
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    if (value >= min && value <= max)
                    {
                        return value;
                    }
                    else
                    {
                        Console.WriteLine($"Введите число от {min} до {max}");
                    }
                }
                else
                {
                    Console.WriteLine("");
                }
            }
        }

        static double CalculateFuelConsumption(double distance, double fuelConsumption, double fuelCost, int vehicleType)
        {
            double fuelConsumed = fuelConsumption * (distance / 100) * (1 + Globals.vehicles[vehicleType].coef);
            double cost = fuelConsumed * fuelCost;
            return cost;
        }

        static double ApplySeasonalCoefficient(double cost, int season)
        {
            return cost * (1 + Globals.seasonsTypes[season].coef);
        }

        static void Main()
        {

            History history = new History(10);

            bool isRunning = true;

            while (isRunning)
            {
                try
                {
                    switch (Menu.MenuSelection(["Калькулятор Стоимости поездки", "Вывод истории поездки", "Анализ поездок", "выход"]))
                    {
                        case 0:
                            double distance = InputDouble("Введите расстояние (в км): ");
                            double fuelConsumption = InputDouble("Введите средний расход топлива на 100 км (в литрах): ");
                            double fuelCostLiter = InputDouble("Введите  цену топлива за литр (в рублях): ");

                            int vehicle = Menu.MenuSelection(["Легковой", "Грузовик", "Мотоцикл"], "Выберите транспорт: ");
                            int season = Menu.MenuSelection(["Лето", "Зима"], "Выберите сезон: ");

                            double costNoSeason = CalculateFuelConsumption(distance, fuelConsumption, fuelCostLiter, vehicle);

                            double totalCost = ApplySeasonalCoefficient(costNoSeason, season);

                            history.SaveTripToHistory(distance, vehicle, season, totalCost);
                            Console.WriteLine("=== Результаты расчета ===");
                            Console.WriteLine($"Стоимость топлива: {costNoSeason:F2}");
                            Console.WriteLine($"Сезонный коэффициент: {Globals.seasonsTypes[season].coef * 100:F0}%");
                            Console.WriteLine($"Итоговая стоимость поездки: {totalCost:F2}");
                            break;
                        case 1:
                            history.ShowTripHistory();
                            break;
                        case 2:
                            history.AnalyzeTrips();
                            break;

                        case 3:
                            isRunning = Menu.MenuSelection(["нет", "да"], "Выйти?") == 0;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Вызвано исключение: " + ex);
                }
                finally
                {
                    Console.WriteLine("нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                }
            }
            Console.WriteLine("Хорошего дня");
        }
    }
}