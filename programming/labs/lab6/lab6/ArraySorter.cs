using System.Diagnostics;
namespace lab
{
    /// <summary>
    /// класс для сортировки массивов
    /// </summary>
    class ArraySorter
    {
        private readonly int[] array;

        /// <summary>
        /// создание массива с заданным размером
        /// </summary>
        /// <param name="size"> размер массива</param>
        public ArraySorter(int size)
        {
            array = new int[size];
            Random rnd = new();
            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next();
            }
        }
        /// <summary>
        /// Создание массива размером 10
        /// </summary>
        public ArraySorter() : this(10)
        {
        }

        /// <summary>
        /// возвращает копию массива
        /// </summary>
        /// <returns>копия массива</returns>
        public int[] GetArrayCopy()
        {
            int[] copy = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                copy[i] = array[i];
            }
            return copy;
        }
        /// <summary>
        /// Гномья сортировка массива
        /// </summary>
        /// <param name="arr">массив для сортировки, будет изменён</param>
        /// <returns>время сортировки в С</returns>
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
            return ((double)stopwatch.ElapsedTicks) / ((double)Stopwatch.Frequency);
        }
        /// <summary>
        /// сортировка выбором
        /// </summary>
        /// <param name="arr">массив для сортировки, будет изменён</param>
        /// <returns>время сортировки в С</returns>
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
            return ((double)stopwatch.ElapsedTicks) / ((double)Stopwatch.Frequency);
        }
        /// <summary>
        /// Вывести массив
        /// </summary>
        /// <param name="arr">массив для вывода</param>
        /// <param name="text">текст выводимый перед массивом</param>
        /// <param name="outBigger">Выводить ли сообщение о размере массива > 10</param>
        public static void PrintArray(int[] arr, string text = "Массив: ", bool outBigger = false)
        {
            if (arr.Length <= 10)
            {
                Console.WriteLine(text + "{" + string.Join(", ", arr) + "}");
            }
            else if (outBigger)
            {
                Console.WriteLine("Массивы не могут быть выведены на экран, так как длина массива больше 10");
            }
        }
        /// <summary>
        /// Выполнить задание по сортировке
        /// </summary>
        public void DoTask()
        {
            PrintArray(array, "Оригинальный массив: ", true);
            int[] GnomeSorted = GetArrayCopy();
            int[] SelectionSorted = GetArrayCopy();
            double GnomeSortTime = GnomeSort(GnomeSorted);
            Console.WriteLine($"Время гномьей сортировки: {GnomeSortTime} С");
            PrintArray(GnomeSorted, "результат гномьей сортировки: ");
            double SelectionSortTime = GnomeSort(SelectionSorted);
            Console.WriteLine($"Время сортировки выбором: {SelectionSortTime} С");
            PrintArray(SelectionSorted, "результат сортировки выбором: ");
        }

    }
}