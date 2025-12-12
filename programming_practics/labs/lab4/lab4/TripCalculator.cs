namespace lab
{
    class TripCalculator
    {
        private TripData[] trips;

        private int tripCount = 0;

        public TripCalculator(int tripCountSaving)
        {
            trips = new TripData[tripCountSaving];
        }

        public void AddTrip(TripData trip)
        {
            tripCount++;

            for (int i = trips.Length - 1; i > 1; i--)
            {
                trips[i] = trips[i - 1];
            }

            trips[0] = trip;
        }

        public void ShowTripHistory()
        {
            for (int i = 0; i < trips.Length && i < tripCount; i++)
            {
                trips[i].PrintInfo((i + 1).ToString());
            }
        }

        public int GetMaximumIndex()
        {
            int limit = Math.Min(trips.Length, tripCount);
            if (limit <= 0) return -1;

            return Enumerable.Range(0, limit)
            .Aggregate((maxIndex, nextIndex) => trips[nextIndex].TotalCost > trips[maxIndex].TotalCost ? nextIndex : maxIndex);
        }

        public int GetMinimumIndex()
        {
            int limit = Math.Min(trips.Length, tripCount);
            if (limit <= 0) return -1;

            return Enumerable.Range(0, limit)
            .Aggregate((minIndex, nextIndex) => trips[nextIndex].TotalCost < trips[minIndex].TotalCost ? nextIndex : minIndex);
        }

        public double GetAverageKmCost()
        {
            int limit = Math.Min(trips.Length, tripCount);
            if (limit <= 0) return -1;

            double totalCost = trips.Take(limit).Sum(t => t.TotalCost);
            double totalDistance = trips.Take(limit).Sum(t => t.Distance);

            if (totalDistance <= 0) return -2;

            return totalCost / totalDistance;
        }

        public int[] FindTripsPerVehicles(string vehicle)
        {
            int limit = Math.Min(trips.Length, tripCount);

            return Enumerable.Range(0, limit)
                .Where(i => trips[i].VehicleType == vehicle)
                .ToArray();
        }

        private double GetVehicleEfficiency(string vehicle)
        {
            int[] indices = FindTripsPerVehicles(vehicle);

            if (indices.Length <= 0) return -1;

            double totalCost = indices.Sum(i => trips[i].TotalCost);
            double totalDistance = indices.Sum(i => trips[i].TotalCost);

            if (totalDistance <= 0) return -2;

            return totalCost / totalDistance;
        }

        private int GetMaxEfficiencyTrip()
        {
            int limit = Math.Min(trips.Length, tripCount);
            if (limit <= 0) return -1;

            return Enumerable.Range(0, limit)
            .Aggregate((maxIndex, nextIndex) => trips[nextIndex].TotalCost / trips[nextIndex].Distance < trips[maxIndex].TotalCost / trips[maxIndex].Distance ? nextIndex : maxIndex);
        }
        private int GetMinEfficiencyTrip()
        {
            int limit = Math.Min(trips.Length, tripCount);
            if (limit <= 0) return -1;

            return Enumerable.Range(0, limit)
            .Aggregate((minIndex, nextIndex) => trips[nextIndex].TotalCost / trips[nextIndex].Distance > trips[minIndex].TotalCost / trips[minIndex].Distance ? nextIndex : minIndex);
        }

        public void AnalyzeTrips()
        {
            string[] avaibleVehicles = Globals.vehicles.Keys.ToArray();
            switch (Menu.MenuSelection(["Самая дорогая поездка", "Самая дешёвая поездка", "Расчёт стоимости 1 км", "Поиск поездок по типу транспорта","Сравнение эффективности разных видов транспорта", "самая экономичная поездка", "самая затратная поездка"], "=== Анализ поездок ==="))
            {
                case 0:
                    int maxIndex = GetMaximumIndex();
                    if (maxIndex >= 0)
                    {
                        trips[maxIndex].PrintInfo("Самая дорогая поездка:");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: нет поездок");
                    }
                    break;
                case 1:
                    int minIndex = GetMinimumIndex();
                    if (minIndex >= 0)
                    {
                        trips[minIndex].PrintInfo("Самая дешёвая поездка:");
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
                        Console.WriteLine("Невозможно вычислить среднюю стоимость");
                    }
                    break;
                case 3:
                    string vehicle = avaibleVehicles[Menu.MenuSelection(["Легковой", "Грузовик", "Мотоцикл"], "Выберите транспорт: ")];
                    int[] indices = FindTripsPerVehicles(vehicle);
                    if (indices.Length > 0)
                    {
                        Console.WriteLine($"Все поездки на {vehicle}");
                        for (int i = 0; i < indices.Length; i++)
                        {
                            trips[indices[i]].PrintInfo($"{i + 1}:");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"поездки на {vehicle} отсутствуют");
                    }

                    break;
                case 4:
                    Console.WriteLine("=== Сравнение эффективности видов транспорта ===");
                    foreach (string v in avaibleVehicles)
                    {
                        double efficiency = GetVehicleEfficiency(v);
                        Console.WriteLine($"{v}: {efficiency}");
                    }
                    break;

                case 5:
                    int MaxEfficiencyTrip = GetMaxEfficiencyTrip();
                    if (MaxEfficiencyTrip >= 0)
                    {
                        trips[MaxEfficiencyTrip].PrintInfo("Самая эффективная поездка:");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка");
                    }
                    break;
                case 6:
                    int MinEfficiencyTrip = GetMinEfficiencyTrip();
                    if (MinEfficiencyTrip >= 0)
                    {
                        trips[MinEfficiencyTrip].PrintInfo("Самая затратная поездка:");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка");
                    }
                    break;

            }
        }


    }
}