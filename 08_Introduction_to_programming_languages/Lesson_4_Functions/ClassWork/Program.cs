internal class Program
{
	private static void Main(string[] args)
	{
		Console.Clear();

		Example01();
		Example02();
		Example03();
		Example04();
	}

	static void Example01()
	{
		// Создаем массив и заполняем его случайными числами
		Random random = new Random();
		int[] arr = new int[10];
		for (int i = 0; i < arr.Length; i++)
		{
			arr[i] = random.Next(0, 100);
		}

		PrintArray(array: arr, text: "Входящий массив: ");
		SelectionSort(arr);
		PrintArray(array: arr, text: "Исходящий массив:");


		// Метод для печати массива
		void PrintArray(int[] array, string text)
		{
			Console.WriteLine($"{text} [{string.Join(" ", array)}]");
		}


		// Метод для сортировки массива
		int[] SelectionSort(int[] array)
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				int minPosition = i;
				for (int j = i + 1; j < array.Length; j++)
				{
					if (array[j] < array[minPosition]) minPosition = j;
				}
				// Применение кортежей для обмена значениями позволяет избежать создания временной переменной
				(array[i], array[minPosition]) = (array[minPosition], array[i]);
			}
			return array;
		}

	}

	static void Example02()
	{
		// Задайте массив из N случайных целых чисел (N вводится с клавиатуры).
		// Найдите количество чисел, которые оканчиваются на 1 и делятся нацело на 7.
		// [1 5 11 21 81 4 0 91 2 3]
		// => 2

		// тип возвращающего значения + Название + ()+ {}


		Console.WriteLine("Введите число");
		int num = Convert.ToInt32(Console.ReadLine());

		int[] array = new int[num];

		void PrintArray()
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new Random().Next(10, 101);
				Console.Write(array[i] + " ");
			}
		}


		int FindNumber()
		{
			int countNumber = 0;

			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] % 10 == 1 && array[i] % 7 == 0)
				{
					countNumber = countNumber + 1;
				}
			}
			return countNumber;
		}

		PrintArray();
		int newNum = FindNumber();

		Console.WriteLine("\n" + newNum);
	}

	static void Example03()
	{
		// Заполните массив на N (вводится с консоли, не более 8) случайных целых чисел от 0 до 9.
		// Сформируйте целое число, которое будет состоять из цифр из массива. Старший разряд числа находится на 0-м индексе, младший – на последнем.
		// [1 3 2 4 2 3] => 132423
		// [2 3 1] => 231

		Console.WriteLine("Введите число");
		int num = Convert.ToInt32(Console.ReadLine());

		int[] array = new int[num];

		void PrintArray()
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Convert.ToInt32(Console.ReadLine());
			}
		}

		int GetNumber()
		{
			string numberPerson = "";

			for (int i = 0; i < array.Length; i++)
			{
				numberPerson = numberPerson + array[i];
			}

			return Convert.ToInt32(numberPerson);
		}

		PrintArray();
		int newNum = GetNumber();

		System.Console.WriteLine("\n" + newNum);
	}

	static void Example04()
	{
		// Задайте одномерный массив, заполненный случайными числами. Определите количество простых чисел в этом массиве.
		// [1 3 4 19 3] => 2
		// [4 3 4 1 9 5 21 13] => 3


		System.Console.WriteLine("Введите число");
		int num = Convert.ToInt32(Console.ReadLine());

		int[] array = new int[num];

		void PrintArray()
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new Random().Next(10, 100);
				Console.Write(array[i] + " ");
			}
		}

		int GetNumber()
		{
			int countNumber = 0;

			for (int i = 0; i < array.Length; i++)
			{
				bool isFind = false;

				for (int j = 2; j < array[i]; j++)
				{
					if (array[i] % j == 0)
					{
						isFind = true;
					}
				}

				if (isFind == false)
				{
					countNumber++;
				}
			}

			return countNumber;
		}

		PrintArray();
		System.Console.WriteLine();
		System.Console.WriteLine(GetNumber());
	}
}
