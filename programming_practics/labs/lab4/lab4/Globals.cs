namespace lab
{
    class Globals
    {
        public static readonly Dictionary<string,double> vehicles = new Dictionary<string, double> { { "Машина", 0 }, { "Грузовик", 0.2 }, {"Мотоцикл", -0.15} };
        public static readonly Dictionary<string,double> seasons = new Dictionary<string, double>{ { "Лето", 0 }, { "Зима", 0.2 } };
    }
}