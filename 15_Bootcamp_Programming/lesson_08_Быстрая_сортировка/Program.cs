// Быстрая сортировка O(log2(n) * n)

/*
1. Импорт всех модулей/библиотек
2. Объекты/классы
3. Функции/процедуры
4. Основной программный код
*/

/*
// РЕКУРСИЯ: Напишите программу, которая сложит числа a и b без прямого сложения.

int sumNumbers(int n, int m)
{
	if (m == 0)
		return n;
	return sumNumbers(n + 1, m - 1);
}
// f = sumNumbers
// f(5, 3) -> f(6, 2) -> f(7, 1) -> f(8, 0) -> 8


Console.Clear();
Console.Write("Введите 1-ое число: ");
int a = int.Parse(Console.ReadLine()!);
Console.Write("Введите 2-ое число: ");
int b = int.Parse(Console.ReadLine()!);
Console.WriteLine($"{a} + {b} = {sumNumbers(a, b)}");

*/

/*
Быстрая сортировка

array = [7, 4, 1, 3, 5, 2, 6] -> [1, 2, 3, 4, 5, 6, 7]
pivot = 7
[4, 1, 3, 5, 2, 6] + [7] + [] = [] + [1] + [2] + [3] + [] + [4] + [] + [5] + [6] + [7] + []

array = [4, 1, 3, 5, 2, 6]
pivot = 4
[1, 3, 2] + [4] + [5, 6] = [] + [1] + [2] + [3] + [] + [4] + [] + [5] + [6]

array = [1, 3, 2]
pivot = 1
[] + [1] + [3, 2]


array = [3, 2]
pivot = 3
[2] + [3] + []


array = [5, 6]
pivot = 5
[] + [5] + [6]
*/

internal class Program
{
	private static void Main()
	{
		Console.Clear();

		int[] array = { 7, 4, 1, 3, 5, 2, 8, 6 };
		Console.WriteLine($"Начальный массив: [{string.Join(", ", array)}]");


		// Создание экземпляра класса Program
		Program program = new Program();

		// Вызов функции сортировки и вывод отсортированного массива
		int[] sortedArray = QuickSort(array);
		Console.WriteLine($"Конечный массив:  [{string.Join(", ", sortedArray)}]");
	}

	// Функция быстрой сортировки
	private static int[] QuickSort(int[] array)
	{
		if (array.Length < 2)
			return array;
		else
		{
			// Выбор опорного элемента
			int pivot = array[0];
			int count = 0;

			// Подсчет элементов меньше опорного
			foreach (int element in array)
			{
				if (element < pivot)
					count++;
			}

			// Создание массива для элементов меньше опорного
			int[] less = new int[count];
			int j = 0;

			// Заполнение массива элементами меньше опорного
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] < pivot)
				{
					less[j] = array[i];
					j++;
				}
			}

			// Подсчет элементов больше опорного
			count = 0;
			foreach (int element in array)
			{
				if (element > pivot)
					count++;
			}

			// Создание массива для элементов больше опорного
			int[] greater = new int[count];
			j = 0;

			// Заполнение массива элементами больше опорного
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] > pivot)
				{
					greater[j] = array[i];
					j++;
				}
			}

			// Подсчет элементов равных опорному
			count = 0;
			foreach (int element in array)
			{
				if (element == pivot)
					count++;
			}

			// Создание массива для элементов равных опорному
			int[] pivotArray = new int[count];

			// Заполнение массива элементами равными опорному
			for (int i = 0; i < pivotArray.Length; i++)
			{
				pivotArray[i] = pivot;
			}

			// Рекурсивные вызовы для частей массива
			return QuickSort(less.ToArray())
				.Concat(pivotArray.ToArray())
				.Concat(QuickSort(greater.ToArray()))
				.ToArray();
		}
	}
}
