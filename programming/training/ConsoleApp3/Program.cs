class Tractor
{
    static int nextId = 0;
    public int id {get;}
    public string Model {get;}
    public double FuelTankVolume {get; private set;}
    private double fuel;
    public double FuelLevel
    {
        get
        {
            return fuel;
        }
        set
        {
            fuel = value;
            if(fuel > FuelTankVolume)
            {
                fuel = FuelTankVolume;
            }
            else if(fuel < 0)
            {
                fuel = 0;
            }
        }
    }
    public double HectaresPerHour {get; private set;}
    public Tractor(string model, double fuelTankVolume,double hectaresPerHour)
    {
        id = nextId;
        nextId++;
        Model = model;
        FuelTankVolume = fuelTankVolume;
        FuelLevel = FuelTankVolume;
        HectaresPerHour= hectaresPerHour;
    }
    public bool Work(int hours)
    {
        if(FuelLevel < 10*hours)
        {
            return false;
        }
        FuelLevel -= 10 * hours;
        return true;
        
    }

    public void Refuel(double  liters)
    {
        double used = Math.Min(FuelTankVolume - FuelLevel, liters);
        FuelLevel += used;
        Console.WriteLine($"получено {used}");
    }
    public string GetInfo()
    {
        return $"id:{id}, {Model}, объём бака: {FuelTankVolume}, запас топлива: {FuelLevel}, скорость работы: {HectaresPerHour} га/час";
    }
    }
    class HarvestField
{
    static int NextId = 0;
    public int fieldid {get;}
    public string Name {get;set;}
    public double Area{get;set;}
    public double HarvestedArea{get;set;}
    public bool isHarvested
    {
        get
        {
            return HarvestedArea >= Area;}
    }
    public HarvestField(string name, double area)
    {
        fieldid = NextId;
        NextId++;
        Name = name;
        Area = area;
        HarvestedArea = 0;
    }
    public double GetRamainingArea()
    {
        return Area -  HarvestedArea;
    }
    public void AddHarvestedArea(double hectares)
    {
        HarvestedArea += hectares;
        HarvestedArea = Math.Min(Area, HarvestedArea);
    }
}

class Program
{
    static void Main()
    {
        List <Tractor> tractors = new List<Tractor>();
        List<HarvestField> fields = new List<HarvestField>();
        tractors.Add(new Tractor("МТЗ",100,10));
        tractors.Add(new Tractor("Абобус",99,15));
        tractors.Add(new Tractor("Москвич",150,5));
        fields.Add(new HarvestField("северное",100));
        fields.Add(new HarvestField("Южное",1200));
        foreach(HarvestField field in fields)
        {
            while(field.isHarvested == false)
            {
                int selectedTracktor = -1;
                for(int i = 0; i < tractors.Count;i++)
                {
                    if(tractors[i].FuelLevel >= 10)
                    {
                        selectedTracktor = i;
                        break;
                    }
                }
                if (selectedTracktor <  0)
                {
                    Console.WriteLine("не хватает топлива");
                    foreach(Tractor t in tractors)
                    {
                        t.Refuel(t.FuelTankVolume - t.FuelLevel);
                    }
                }
                else
                {
                    if(tractors[selectedTracktor].Work(1))
                    {
                        field.AddHarvestedArea(tractors[selectedTracktor].HectaresPerHour);
                        Console.WriteLine($"Трактор {tractors[selectedTracktor].Model} отработал 1 час на поле {field.Name} осталось убрать {field.GetRamainingArea()} га");
                    }
                    else
                    {
                        Console.WriteLine($"ошибка трактору {tractors[selectedTracktor].Model} не хватило топлива");
                    }
                }
            }

        }
    }
}