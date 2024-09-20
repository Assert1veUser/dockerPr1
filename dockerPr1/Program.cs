using System;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Пожалуйста, укажите искомое значение в качестве параметра командной строки.");
            return;
        }

        if (!int.TryParse(args[0], out int target))
        {
            Console.WriteLine("Пожалуйста, укажите целое число в качестве параметра командной строки.");
            return;
        }

        int[] array = new int[100];
        Random random = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 1001);
        }

        Array.Sort(array);

        int result = BinarySearch(array, target);

        if (result != -1)
        {
            Console.WriteLine($"Значение {target} найдено в массиве на позиции {result}.");
        }
        else
        {
            Console.WriteLine($"Значение {target} не найдено в массиве.");
        }
    }

    static int BinarySearch(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (array[mid] == target)
            {
                return mid;
            }
            else if (array[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }
}
