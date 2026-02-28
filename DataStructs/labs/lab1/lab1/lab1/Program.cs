namespace lab1
{
class Program
    {
        public static uint CalculateOnes(uint n)
        {
            uint result = 0;
            while(n>0)
            {
                result += n & 1;
                n = n >> 1;
            }
            return result;
        }

        public static void Main()
        {
            uint number;
            Console.Write("введите целое положительное число: ");
            while (!uint.TryParse(Console.ReadLine(),out number))
            {
                Console.WriteLine("ошибка ввода");
            }
            uint result = CalculateOnes(number);

            Console.WriteLine($"Число единиц в двоичном представлении числа {number}: {result}");
        }
    }
}