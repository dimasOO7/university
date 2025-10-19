class Program
{
    static void Main(String[] args)
    {
        Console.WriteLine("введите ваш возраст");
        string strAge = Console.ReadLine();
        int age = int.Parse(strAge);
        Console.Write("ваш возраст: ");
        Console.WriteLine(age);
    }
}