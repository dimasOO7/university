using System;

class Program
{
    static int[] Shrink(int[] arr)
    {
        List<int> set = new List<int>();

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != 0 && set.Find(arr[i]) == -1)
            {
                set.Add(arr[i]);
            }
        }
        return set.ToArray();
    }
    static void Main()
    {
        int[] arr = { 1, 2, 0, 0, 1, 43, 5, 2, 5 };
        Console.WriteLine(Shrink(arr));
    }
}