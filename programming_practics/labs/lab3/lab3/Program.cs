using System;
using System.Collections.Generic;

namespace Lab
{

    class Globals
    {
        public readonly static (string type, double coef)[] vehicles = { ("Машина", 0), ("Грузовик", 0.2), ("Мотоцикл", -0.15) };
        public readonly static (string season, double coef)[] seasonsTypes = { ("Лето", 0), ("Зима", 0.2) };
        public static double[] distances = new double[10];
        string[] vehicleTypes = new string[10];
        string[] seasons = new string[10];
        double[] totalCosts = new double[10];
    }

    class History
    {
        double[] distances = new double[10];
        string[] vehicleTypes = new string[10];
        string[] seasons = new string[10];
        double[] totalCosts = new double[10];

        ulong tripCount = 0;

        public void SaveTripToHistory(double distance, int vehicle, int season, double totalCost)
        {
            distances[tripCount % 10] = distance;
            vehicleTypes[tripCount % 10] = Globals.vehicles[vehicle].type;
            seasons[tripCount % 10] = Globals.seasonsTypes[season].season;
            totalCosts[tripCount % 10] = totalCost;
            tripCount++;
        }

        void ShowTrip(int index, string text = "")
        {
            Console.WriteLine($"{text}: {distances[index]:F2} км. {seasons[index]:F2} {vehicleTypes[index]:F2} итоговая стоимость: {totalCosts[index]:F2}");
        }

        public void ShowTripHistory()
        {
            for (UInt16 i = 0; i < 10 && i < tripCount; i++)
            {
                ShowTrip((int)((tripCount - i - 1) % 10),i.ToString());
            }
        }

        public void AnalyzeTrips()
        {
            switch (Menu.MenuSelection(["Самая дорогая поездка", "Самая дешёвая поездка", "Расчёт стоимости 1 км", "Поиск поездок по типу транспорта"], "=== Анализ поездок ==="))
            {
                case 0:
                    ShowTrip(GetMaximum(), "Самая дорогая поездка");
                    break;
                case 1:
                    ShowTrip(GetMinimum(), "Самая дешёвая поездка");
                    break;
                case 2:
                    Console.WriteLine($"Средняя стоимость 1 км: {GetAverageKmCost():F2}");
                    break;
                case 3:
                    string vehicle = Globals.vehicles[Menu.MenuSelection(["Легковой", "Грузовик", "Мотоцикл"], "Выберите транспорт: ")].type;
                    int[] indices = FindTripsPerVehicles(vehicle);
                    Console.WriteLine($"Все поездки на {vehicle}");
                    foreach (int i in indices)
                    {
                        ShowTrip(i);
                    }
                    break;

            }
        }

        int GetMaximum()
        {
            double max = totalCosts[0];
            int index = 0;
            for (UInt16 i = 0; i < 10 && i < tripCount; i++)
            {
                if (totalCosts[i] > max)
                {
                    index = i;
                }
            }
            return index;
        }
        int GetMinimum()
        {
            double min = totalCosts[0];
            int index = 0;
            for (UInt16 i = 0; i < 10 && i < tripCount; i++)
            {
                if (totalCosts[i] < min)
                {
                    index = i;
                }
            }
            return index;
        }

        double GetAverageKmCost()
        {
            double totalCost = 0;
            double totalDistance = 0;
            for (UInt16 i = 0; i < 10 && i < tripCount; i++)
            {
                totalCost += totalCosts[i];
                totalDistance += distances[i];
            }
            return totalCost / totalDistance;
        }

        int[] FindTripsPerVehicles(string vehicle)
        {
            List<int> coincidences = new List<int>();
            for (UInt16 i = 0; i < 10 && i < tripCount; i++)
            {
                if (vehicleTypes[i] == vehicle)
                {
                    coincidences.Add(i);
                }
            }
            return coincidences.ToArray();
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
            double fuelConsumed = fuelConsumption * (distance / 100) * (1+Globals.vehicles[vehicleType].coef);
            double cost = fuelConsumed * fuelCost;
            return cost;
        }

        static double ApplySeasonalCoefficient(double cost, int season)
        {
            return cost * (1 + Globals.seasonsTypes[season].coef);
        }

        static void Main()
        {

            History history = new History();

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