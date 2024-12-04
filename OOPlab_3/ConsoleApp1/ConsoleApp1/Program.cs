using System;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Введіть кількість рядків (n): ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введіть кількість стовпців (m): ");
        int m = int.Parse(Console.ReadLine());

        double[,] array = new double[n, m];
        Random rand = new Random();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                array[i, j] = Math.Round(rand.NextDouble() * (7.03 - (-42.31)) + (-42.31), 2);
            }
        }

        Console.WriteLine("Початковий масив:");
        PrintArray(array);

        int nonNegativeRowsCount = 0;
        for (int i = 0; i < n; i++)
        {
            bool hasNegative = false;
            for (int j = 0; j < m; j++)
            {
                if (array[i, j] < 0)
                {
                    hasNegative = true;
                    break;
                }
            }
            if (!hasNegative)
            {
                nonNegativeRowsCount++;
            }
        }
        Console.WriteLine($"Кількість рядків, які не містять жодного від’ємного елемента: {nonNegativeRowsCount}");

        for (int j = 0; j < m; j++)
        {
            for (int i = 0; i < n / 2; i++)
            {
                double temp = array[i, j];
                array[i, j] = array[n - 1 - i, j];
                array[n - 1 - i, j] = temp;
            }
        }

        Console.WriteLine("Масив після зміни порядку елементів у стовпцях:");
        PrintArray(array);
    }

    public static void PrintArray(double[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{array[i, j]:F2}\t");
            }
            Console.WriteLine();
        }
    }
}
