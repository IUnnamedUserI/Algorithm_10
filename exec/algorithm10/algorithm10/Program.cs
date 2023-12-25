using System;
using System.Diagnostics;

class HeapSort
{
    static void Main()
    {
        // Ввод данных
        Console.WriteLine("[Program] Введите размерность массива:");
        Console.Write(">>> ");
        int N = int.Parse(Console.ReadLine());
        int[] array = new int[N];
        Stopwatch Timer = Stopwatch.StartNew();
        Timer.Start();

        // Заполнение массива
        Random _rnd = new Random();
        for (int i = 0; i < N; i++) array[i] = _rnd.Next(-5 * N, 5 * N);

        // Вывод и сортировка исходного массива
        if (N < 20) for (int i = 0; i < N; i++) Console.WriteLine($"[{i}] {array[i]}");
        HeapSortAlgorithm(array);

        //Вывод отсортированного массива
        Console.WriteLine($"[Program] Время выполнения: {Timer.Elapsed.TotalSeconds} сек.");
        Timer.Stop();
        Console.WriteLine("\n[Program] Отсортированный массив:");
        for (int i = 0; i < N; i++) Console.WriteLine($"[{i}] {array[i]}");
        Console.ReadKey();
    }

    static void HeapSortAlgorithm(int[] array)
    {
        int N = array.Length;

        // Построение кучи (перегруппировка массива)
        for (int i = N / 2 - 1; i >= 0; i--)
            Heapify(array, N, i);

        // Извлечение элементов из кучи
        for (int i = N - 1; i > 0; i--)
        {
            // Перемещаем текущий корень в конец массива
            int temp = array[0];
            array[0] = array[i];
            array[i] = temp;

            // Вызываем процедуру Heapify для уменьшения размера кучи
            Heapify(array, i, 0);
        }
    }

    static void Heapify(int[] arr, int n, int i)
    {
        int largest = i; // Инициализируем наибольший элемент как корень
        int left = 2 * i + 1; // Левый потомок
        int right = 2 * i + 2; // Правый потомок

        // Если левый потомок больше корня
        if (left < n && arr[left] > arr[largest]) largest = left;

        // Если правый потомок больше корня
        if (right < n && arr[right] > arr[largest]) largest = right;

        // Если самый большой элемент не корень
        if (largest != i)
        {
            int temp = arr[i];
            arr[i] = arr[largest];
            arr[largest] = temp;

            // Рекурсивно вызываем Heapify для поддерева
            Heapify(arr, n, largest);
        }
    }
}