namespace lab
{
    class TripData
    {
        private double distance;

        public double Distance
        {
            get { return distance; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                distance = value;
            }
        }

        private string vehicleType;

        public string VehicleType
        {
            get
            {
                return vehicleType;
            }
            protected set
            {
                if (!Globals.vehicles.ContainsKey(value))
                {
                    throw new ArgumentException();
                }
                season = value;
                vehicleType = value;
            }
        }

        private string season;

        public string Season
        {
            get
            {
                return season;
            }
            protected set
            {
                if (!Globals.seasons.ContainsKey(value))
                {
                    throw new ArgumentException();
                }
                season = value;
            }
        }

        private double fuelPrice;

        public double FuelPrice
        {
            get { return fuelPrice; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                fuelPrice = value;
            }
        }

        private double totalCost;

        public double TotalCost
        {
            get { return totalCost; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                totalCost = value;
            }
        }

        private double fuelConsumed;

        public double FuelConsumed
        {
            get { return fuelConsumed; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                fuelConsumed = value;
            }
        }

        private double fuelConsumption;

        public double FuelConsumption
        {
            get
            {
                return fuelConsumption;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                fuelConsumption = value;
            }
        }

        private DateTime calculationTime;

        public DateTime CalculationTime
        {
            get
            {
                return calculationTime;
            }

            protected set
            {
                calculationTime = value;
            }
        }

        public TripData(double distance, double fuelConsumption, double fuelPrice,string vehicleType, string season)
        {
            this.Distance = distance;
            this.VehicleType = vehicleType;
            this.FuelConsumption = fuelConsumption;
            this.FuelPrice = fuelPrice;
            this.Season = season;
            CalculateCost();
        }

        public double CalculateFuelConsumption()
        {
            FuelConsumed = FuelConsumption * (Distance / 100) * (1 + Globals.vehicles[VehicleType]);
            return FuelConsumed;
        }

        public double CalculateRawCost()
        {
            double cost = CalculateFuelConsumption() * FuelPrice;
            return cost;
        }

        public double ApplySeasonalCoefficient(double cost)
        {
            return cost * (1 + Globals.seasons[Season]);
        }

        public double CalculateCost()
        {
            double cost = CalculateRawCost();
            TotalCost = ApplySeasonalCoefficient(cost);
            CalculationTime = DateTime.Now;
            return TotalCost;
        }
        public void PrintInfo(string text = "")
        {
            Console.WriteLine($"{text} {Distance:F2} км. сезон: {Season} транспорт: {VehicleType} итоговая стоимость: {TotalCost:F2}");
        }


    }
}