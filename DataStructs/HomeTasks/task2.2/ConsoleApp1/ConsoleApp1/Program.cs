public class CalculateSystemConverter
{
    public static string Convert(int n, int b)
    {
        string result;
        if (n < b)
        {
            result = n.ToString();
        }
        else
        {
            result = Convert(n / b, b);
            result += (n % b);
        }
        return result;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("введите число:");
        int n = int.Parse(Console.ReadLine());
        Console.Write("введите систему счисления:");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine(CalculateSystemConverter.Convert(n, b));
    }
}