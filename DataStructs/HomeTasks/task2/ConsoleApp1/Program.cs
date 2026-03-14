public class CalculateSystemConverter
{
    public static string Convert(int n, int b)
    {
        string result;
        if(n < b)
        {
            result = n.ToString();
        }
        else
        {
            result = Convert(n/b,b);
            result += (n % b);
        }
        return result;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine(CalculateSystemConverter.Convert(26,5));
    }
}