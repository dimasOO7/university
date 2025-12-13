namespace lab
{
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

        static void Main()
        {

            TripCalculator history = new TripCalculator();

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
                            string[] avaibleVehicles = Globals.vehicles.Keys.ToArray();
                            int vehicleIndex = Menu.MenuSelection(avaibleVehicles, "Выберите транспорт: ");
                            string[] avaibleSeasons = Globals.seasons.Keys.ToArray();
                            int seasonIndex = Menu.MenuSelection(avaibleSeasons, "Выберите сезон: ");

                            TripData trip = new TripData(distance, fuelConsumption, fuelCostLiter, avaibleVehicles[vehicleIndex], avaibleSeasons[seasonIndex]);
                            trip.PrintInfo();

                            history.AddTrip(trip);
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