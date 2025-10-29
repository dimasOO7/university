using System.Diagnostics;

namespace lab
{
    public class ArraySorter
    {
        public static int[] CreateArray(int size)
        {
            int[] array = new int[size];
            Random rnd = new();
            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next();
            }
            return array;
        }
        public static int[] GetArrayCopy(int[] arr)
        {
            int[] copy = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                copy[i] = arr[i];
            }
            return copy;
        }

        public static double GnomeSort(int[] arr)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int i = 1;
            int len = arr.Length;
            while (i < len)
            {
                if (i == 0 || arr[i] >= arr[i - 1])
                {
                    i++;
                }
                else
                {
                    int k = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = k;
                    i--;
                }
                
            }
            stopwatch.Stop();
            return ((double)stopwatch.ElapsedTicks)/((double)Stopwatch.Frequency);
        }

        public static double SelectionSort(int[] arr)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int len = arr.Length;
            for (int i = 0; i < len - 1; i++)
            {
                int minI = i;
                for (int k = i + 1; i < len; i++)
                {
                    if (arr[k] < arr[minI])
                    {
                        minI = k;
                    }
                }
                if (minI != i)
                {
                    int k = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = k;
                }
            }
            stopwatch.Stop();
            return ((double)stopwatch.ElapsedTicks)/((double)Stopwatch.Frequency);
        }
        public static void PrintArray(int[] arr, string text = "Массив: ", bool first_message = false)
        {
            if (arr.Length <= 10)
            {
                Console.WriteLine(text + "{" + string.Join(", ",arr) + "}");
            }
            else if (first_message)
            {
                Console.WriteLine("Массивы не могут быть выведены на экран, так как длина массива больше 10");
            }
        }

        public static void DoTask()
        {
            int[] array = CreateArray(Program.InputInt("введите размер массива: ",true));
            PrintArray(array, "Оригинальный массив: ", true);
            int[] GnomeSorted = GetArrayCopy(array);
            int[] SelectionSorted = GetArrayCopy(array);
            double GnomeSortTime = GnomeSort(GnomeSorted);
            Console.WriteLine($"Время гномьей сортировки: {GnomeSortTime} С");
            PrintArray(GnomeSorted, "результат гномьей сортировки: ");
            double SelectionSortTime = GnomeSort(SelectionSorted);
            Console.WriteLine($"Время сортировки выбором: {SelectionSortTime} С");
            PrintArray(SelectionSorted, "результат сортировки выбором: ");
        }

    }
}