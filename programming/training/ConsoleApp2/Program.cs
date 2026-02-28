enum Gender
{
    Male,
    Female
}
abstract class Animal
{
    public string Name{get; protected set;}
    public string Species{get; protected set;}
    public Gender Gender{get; protected set;}
    public abstract string MakeSound();
    public virtual string GetInfo()
    {
        return $"Имя: {Name}, вид: {Species}, пол: {(this.Gender == Gender.Male ? "Самец" : "Самка")}";
    }
}
public interface IFloating
{
    void Float();
}
class Duck : Animal, IFloating
{
    public Duck(string name, Gender gender)
    {
        Name = name;
        this.Gender= gender;
        Species = "утка";
    }
    public void Float()
    {
        Console.WriteLine("буль");
    }
    public override string MakeSound()
    {
     return "кря";   
    }
}
class Lion : Animal
{
    public Lion(string name, Gender gender)
    {
        Name = name;
        this.Gender = gender;
        Species = "Лев";
    }
    public override string MakeSound()
    {
        return "ррр";
    }
}
class Dog : Animal
{
    public Dog(string name, Gender gender)
    {
        Name = name;
        this.Gender = gender;
        Species = "Шабака";
    }
    public override string MakeSound()
    {
        return "Гав";
    }
}
class Ark
{
    private List<Animal> animals = new List<Animal>();
    private List<(Animal male, Animal female)> pairs = new List<(Animal male, Animal female)>();

    public void AddAnimal(Animal animal)
    {
        animals.Add(animal);
    }
    public void PairAnimals()
    {
        pairs.Clear();
        Dictionary<string,Queue<Animal>> males = new Dictionary<string, Queue<Animal>>();
        Dictionary<string,Queue<Animal>> fem = new Dictionary<string, Queue<Animal>>();

        foreach(Animal a in animals)
        {
            switch(a.Gender)
            {
                case Gender.Male:
                if(!males.ContainsKey(a.Species))
                    {
                        males.Add(a.Species,new Queue<Animal>());
                    }
                males[a.Species].Enqueue(a);
                break;
                case Gender.Female:
                 if(!fem.ContainsKey(a.Species))
                    {
                        fem.Add(a.Species,new Queue<Animal>());
                    }
                fem[a.Species].Enqueue(a);
                break;
            }
        }
        List<string> species = males.Keys.ToList();
        species.AddRange(fem.Keys);

        foreach(string s in species.Distinct())
        {
            if(!males.ContainsKey(s) || !fem.ContainsKey(s))
            {
                Console.WriteLine($"для {s} нет пар");
                continue;
            }

            while(males[s].Count > 0 && fem[s].Count > 0)
            {
                pairs.Add((males[s].Dequeue(),fem[s].Dequeue()));
            }

            if (males[s].Count > 0 || fem[s].Count() > 0)
            {
                Console.WriteLine($"для некотрых представителей {s} нет пар");
            }

        }
    }
    public void DisplayPairs()
    {
        foreach((Animal male, Animal female) p in pairs)
        {
            Console.WriteLine($"{p.male.Species} самец: {p.male.Name}, самка: {p.female.Name}");
        }
    }
    public void SortAnimalsBySpecies()
    {
        Dictionary<string,List<Animal>> dict = new Dictionary<string, List<Animal>>();
        foreach(Animal a in animals)
        {
            if(!dict.ContainsKey(a.Species))
            {
                dict.Add(a.Species,new List<Animal>());
            }
            dict[a.Species].Add(a);
        }
        animals.Clear();
        foreach(string s in dict.Keys)
        {
            foreach(Animal a in dict[s])
            {
                animals.Add(a);
            }
        }
    }
}
class Program
{
    static void Main()
    {
        Ark ark = new Ark();
        ark.AddAnimal(new Duck("Жанна", Gender.Female));
        ark.AddAnimal(new Lion("Тимофей",Gender.Male));
        ark.AddAnimal(new Dog("Шарик",Gender.Male));
        ark.AddAnimal(new Lion("Лиза",Gender.Female));
        ark.AddAnimal(new Duck("Пётр",Gender.Male));
        ark.AddAnimal(new Lion("Саша",Gender.Male));
        ark.PairAnimals();
        ark.DisplayPairs();
        ark.SortAnimalsBySpecies();
    }
}