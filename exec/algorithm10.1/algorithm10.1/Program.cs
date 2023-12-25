using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("[Program] Введите размерность массивов:");
        Console.Write(">>> ");
        int N = int.Parse(Console.ReadLine());

        int[] A = new int[N];
        int[] B = new int[N];
        Random _rnd = new Random();

        for (int i = 0; i < N; i++)
        {
            A[i] = _rnd.Next(-500, 500);
            B[i] = _rnd.Next(-500, 500);
        }
        PrintSortedSums(A, B);
        Console.ReadKey();
    }

    static void PrintSortedSums(int[] A, int[] B)
    {
        Array.Sort(A);
        Array.Sort(B);

        int N = A.Length;
        int[] sums = new int[N * N];
        int index = 0;

        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++) sums[index++] = A[i] + B[j];

        Array.Sort(sums);

        Console.WriteLine("[Program] Суммы в возрастающем порядке:");
        foreach (int value in sums) Console.WriteLine(value);
    }
}