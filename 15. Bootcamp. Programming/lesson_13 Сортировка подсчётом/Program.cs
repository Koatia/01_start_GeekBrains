/*
Сортировка подсчетом

В этом коде реализованы две версии сортировки подсчетом: базовая(CountingSort) для массивов с неотрицательными числами от 0 до 9
и расширенная (CountingSortExtended) для массивов с произвольными целыми числами, включая отрицательные.
Расширенная версия использует смещение для корректной работы с отрицательными числами.
*/
internal class Program
{
	private static void Main(string[] args)
	{

		// Инициализация исходного массива с целыми числами, включая отрицательные значения
		int[] array = { 10, -5, -9, 0, 2, 5, 1, 3, 1, 0, -10 };

		// Вызов функции расширенной сортировки подсчетом для сортировки исходного массива
		int[] sortedArray = CountingSortExtended(array);

		// Вывод отсортированного массива в консоль
		Console.WriteLine(string.Join(", ", sortedArray));

		// Функция сортировки подсчетом для массива с элементами от 0 до 9
		void CountingSort(int[] inputArray)
		{
			// Инициализация массива для подсчета количества каждого элемента (предполагается, что элементы от 0 до 9)
			int[] counters = new int[10];

			// Подсчет количества каждого элемента в исходном массиве
			for (int i = 0; i < inputArray.Length; i++)
			{
				counters[inputArray[i]]++;
			}

			// Перезапись исходного массива, используя информацию о количестве каждого элемента
			int index = 0;
			for (int i = 0; i < counters.Length; i++)
			{
				for (int j = 0; j < counters[i]; j++)
				{
					inputArray[index] = i;
					index++;
				}
			}
		}

		// Расширенная функция сортировки подсчетом, поддерживающая отрицательные числа
		int[] CountingSortExtended(int[] inputArray)
		{
			// Нахождение максимального и минимального элементов в массиве
			int max = inputArray.Max();
			int min = inputArray.Min();

			// Вычисление смещения для поддержки отрицательных чисел
			int offset = -min;
			int[] sortedArray = new int[inputArray.Length];
			int[] counters = new int[max + offset + 1];

			// Подсчет количества каждого элемента с учетом смещения
			for (int i = 0; i < inputArray.Length; i++)
			{
				counters[inputArray[i] + offset]++;
			}

			// Перезапись исходного массива, используя информацию о количестве каждого элемента и смещении
			int index = 0;
			for (int i = 0; i < counters.Length; i++)
			{
				for (int j = 0; j < counters[i]; j++)
				{
					sortedArray[index] = i - offset;
					index++;
				}
			}

			// Возвращение отсортированного массива
			return sortedArray;
		}
	}
}
