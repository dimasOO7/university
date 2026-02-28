using System;
using System.Collections.Generic;

class Nut
{
    private static int nextId = 0;
    public int id {get;}
    private NutTypes type;
    public string Type
    {
        get
        {
        switch (type)
        {
            case NutTypes.Funduk:
            return "Фундук";
            case NutTypes.Grecee:
            return "грецкий";
            case NutTypes.Kedr:
            return "кедровый";
            case NutTypes.DubNut:
            return " жёлудь";
            default:
            return "не задан";
        }
        }
    }
    private double weight;
    public double Weight
    {
        get
        {
            return weight;
        }
        private set
        {
            if (value < 0.5 || value > 5.0)
            {
                throw new ArgumentOutOfRangeException("вес ореха должен быть от 0.5 до 5");
            }
            weight = value;
        }
    }
    public Nut(NutTypes type, double weight)
    {
        this.type = type;
        this.weight = weight;
        id = nextId;
        nextId++;
    }
    public void PrintInfo()
    {
        Console.WriteLine($"[ID:{id}] {Type}, вес: {weight} г");
    }
}

enum NutTypes
{
    Funduk,
    Grecee,
    Kedr,
    DubNut
}

enum Colors
{
    Red,
    Gray,
    Black
}

class Squirrel
{
    public string Name {get;set;}
    private Colors color;
    public string Color
    {
        get
        {
            switch(color)
            {
                case Colors.Red:
                return "рыжая";
                case Colors.Gray:
                return "серая";
                case Colors.Black:
                return "чёрная";
                default:
                return "не задано";
            }
        }
    }
    public int Age {get;set;}
    public List<Nut> Stock {get; private set;}

    public Squirrel(string name, Colors color, int age)
    {
        Name = name;
        this.color = color;
        Age = age;
        Stock = new List<Nut>();
    }
    public void AddNut(Nut newNut)
    {
        Stock.Add(newNut);
    }
    public Nut FindHeaviestNut()
    {
        if(Stock.Count == 0)
        {
            return null;
        }
        Nut nut = Stock[0];
        foreach(Nut n in Stock)
        {
            if(n.Weight > nut.Weight)
            {
                nut = n;
            }
        }
        return nut;
    }
    public double GetTotalWeight()
    {
        double weight = 0.0;
        foreach(Nut n in Stock)
        {
            weight += n.Weight;
        }
        return weight;
    }
    public void PrintStock()
    {
        if(Stock.Count == 0)
        {
            Console.WriteLine("запасы пусты");
            return;
        }
        foreach(Nut n in Stock)
        {
            n.PrintInfo();
        }
    }
}
class Program
{
    static void Main()
    {
        Random rnd = new Random();
        Squirrel[] forest = new Squirrel[]{new Squirrel("Пушинка",Colors.Red,10), new Squirrel("Снежок",Colors.Gray,20),new Squirrel("Уголёк",Colors.Black,30)};
        Nut[] nuts = new Nut[]{
        new Nut(NutTypes.Funduk,3.5),
        new Nut(NutTypes.Grecee,2.4),
        new Nut(NutTypes.Kedr,1.5),
        new Nut(NutTypes.DubNut,0.6),
        new Nut(NutTypes.Grecee,3),
        new Nut(NutTypes.Funduk,4.6),
        new Nut(NutTypes.Kedr,1.4),
        new Nut(NutTypes.DubNut,2.8),
        new Nut(NutTypes.Grecee,5.0),
        new Nut(NutTypes.Funduk,0.5),
        new Nut(NutTypes.Grecee,0.75),
        new Nut(NutTypes.Kedr,4),
        };
        foreach(Nut n in nuts)
        {
            forest[rnd.Next(forest.Length)].AddNut(n);
        }
        Squirrel maxStock = forest[0];
        double maxStockWeight = maxStock.GetTotalWeight();
        foreach(Squirrel s in forest)
        {
            Console.WriteLine($"{s.Name}, возраст: {s.Age}");
            s.PrintStock();
            Nut heaviest = s.FindHeaviestNut();
            if(heaviest != null)
            {
                Console.WriteLine("самый тяжёлый орех:");
                heaviest.PrintInfo();
            }
            double totalWeight = s.GetTotalWeight();
            Console.WriteLine($"общий вес запасов: {totalWeight}г");
            Console.WriteLine();
            if(totalWeight > maxStockWeight)
            {
                maxStockWeight = totalWeight;
                maxStock = s;
            }
        }
        Console.WriteLine($"Победитель конкурса {maxStock.Name}! общий вес запасов: {maxStockWeight}");
    }
}
