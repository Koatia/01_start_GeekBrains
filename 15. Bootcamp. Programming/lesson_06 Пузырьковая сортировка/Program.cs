internal class Program
{
	private static void Main()
	{
		// Очистка консоли для более чистого вывода
		System.Console.Clear();

		// Запрашиваем у пользователя количество элементов массива
		System.Console.Write("Введите кол-во элементов массива: ");
		int n = int.Parse(Console.ReadLine()!);

		// Инициализация и заполнение массива случайными числами от 10 до 100
		int[] array = new int[n];
		for (int i = 0; i < n; i++)
			array[i] = Random.Shared.Next(10, 100);

		// Вывод начального массива
		System.Console.WriteLine("Начальный массив: [" + string.Join(", ", array) + "]");
		// Проверка, отсортирован ли массив
		System.Console.WriteLine($"Массив отсортирован: {Check(array)}");
		System.Console.WriteLine();

		// Сортировка пузырьком
		BubbleSort(array);

		// Вывод окончательного массива и проверка, отсортирован ли он
		System.Console.WriteLine($"Конечный массив:  [{string.Join(", ", array)}]");
		System.Console.WriteLine($"Массив отсортирован: {Check(array)}");
	}

	// Функция для проверки, отсортирован ли массив
	private static bool Check(int[] array)
	{
		for (int i = 0; i < array.Length - 1; i++)
		{
			if (array[i] > array[i + 1])
				return false;
		}
		return true;
	}

	// Функция для сортировки пузырьком
	private static void BubbleSort(int[] array)
	{
		// Внешний цикл для прохода по всем элементам массива
		for (int i = 0; i < array.Length - 1; i++)
		{
			// Внутренний цикл для сравнения и обмена элементов
			for (int j = 0; j < array.Length - 1 - i; j++)
			{
				if (array[j] > array[j + 1])
				{
					// Обмен значений, если текущий элемент больше следующего
					int temp = array[j];
					array[j] = array[j + 1];
					array[j + 1] = temp;
				}
			}

			// Вывод текущего состояния массива после каждой итерации внешнего цикла
			System.Console.WriteLine(i + "\t[" + string.Join(", ", array) + "]");
		}
	}
}
