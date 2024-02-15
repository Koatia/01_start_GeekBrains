internal class Program
{
	static Random random = new Random();

	public static void Main()
	{
		Console.Clear();
		Random random = new();
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine("Урок 5. Двумерные массивы");

		Task1(); // Выдает значение элемента по его позиции в двумерном массиве
		Task2(); // Меняет местами первую и последнюю строку в двумерном массиве
		Task3(); // Найдет строку с наименьшей суммой элементов в двумерном массиве
		Task4(); // Удалит строку и столбец, на пересечении которых расположен наименьший элемент в двумерном массиве
		Console.Read();
	}

	public static void CreateArray(int[,] array)	// Функция для заполнения двухмерного массива случайными значениями
	{
		for (int i = 0; i < array.GetLength(0); i++)
		{
			for (int j = 0; j < array.GetLength(1); j++)
			{
				array[i, j] = random.Next(10, 100);
			}
		}
	}

	public static void PrintArray(int[,] array)  // Функция для печати двухмерного массива
	{
		for (int i = 0; i < array.GetLength(0); i++)
		{
			for (int j = 0; j < array.GetLength(1); j++)
			{
				Console.Write(array[i, j] + " ");
			}
			Console.WriteLine();
		}
		Console.WriteLine();
	}

	public static void Task1()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("\nЗадача 1:");
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, " +
			"и возвращает значение этого элемента или же указание, что такого элемента нет.");
		Console.ResetColor();

		static int GetElementAtPosition(int[,] array, int row, int col) // Функция для получения значения элемента по заданным координатам
		{
			int numRows = array.GetLength(0);
			int numCols = array.GetLength(1);

			if (row >= 0 && row < numRows && col >= 0 && col < numCols)
			{
				return array[row, col];
			}
			return -1; // Возвращаем -1, чтобы показать, что элемент не существует
		}

		int[,] array1 = new int[4, 5];
		CreateArray(array1);

		Console.Write("Введите позиции элемента в двумерном массиве через пробел: ");
		string[] position = Console.ReadLine().Split(' ');

		int row = Convert.ToInt32(position[0]);
		int col = Convert.ToInt32(position[1]);

		PrintArray(array1);

		int value = GetElementAtPosition(array1, row, col);
		if (value != -1)
		{
			Console.WriteLine($"Значение элемента [{row}, {col}] равно {value}");
		}
		else
		{
			Console.WriteLine($"Элемента [{row}, {col}] не существует в массиве.");
		}
	}

	public static void Task2()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("\nЗадача 2:");

		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Задайте двумерный массив. Напишите программу, которая поменяет местами первую и последнюю строку массива.");
		Console.ResetColor();

		// Функция для обмена местами первой и последней строки массива
		static int[,] ChangeArray2(int[,] array)
		{
			int num;

			for (int j = 0; j < array.GetLength(1); j++)
			{
				num = array[0, j];
				array[0, j] = array[array.GetLength(0) - 1, j];
				array[array.GetLength(0) - 1, j] = num;
			}
			return array;
		}


		int[,] array2 = new int[4, 5];
		CreateArray(array2);
		PrintArray(array2);
		ChangeArray2(array2);
		PrintArray(array2);
	}

	public static void Task3()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("Задача 3:");

		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.");
		Console.ResetColor();

		// Функция для нахождения строки с наименьшей суммой элементов
		static int FindRow(int[,] array)
		{
			int min = 0;
			int sum;
			int row = 0;
			for (int j = 0; j < array.GetLength(1); j++)
			{
				min += array[0, j];
			}
			// Console.Write($"{min} ");

			for (int i = 1; i < array.GetLength(0); i++)
			{
				sum = 0;
				for (int j = 0; j < array.GetLength(1); j++)
				{
					sum += array[i, j];
				}
				// Console.Write($"{sum} ");
				if (sum < min)
				{
					min = sum;
					row = i;
				}
			}
			return row;
		}

		int[,] array3 = new int[4, 5];
		CreateArray(array3);
		PrintArray(array3);
		Console.WriteLine($"Строка {FindRow(array3)} с наименьшей суммой элементов");
	}

	public static void Task4()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("\nЗадача 4:");

		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Задайте двумерный массив из целых чисел. Напишите программу, которая удалит строку и столбец, на пересечении которых " +
			"расположен наименьший элемент массива. Под удалением понимается создание нового двумерного массива без строки и столбца");
		Console.ResetColor();

		// Функция удалит строку и столбец, на пересечении которых расположен наименьший элемент массива
		static int[,] ChangeArray4(int[,] array)
		{
			int min = array[0, 0];
			int row = 0;
			int col = 0;

			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					if (min > array[i, j])
					{
						min = array[i, j];
						row = i;
						col = j;
					}
				}
			}
			Console.WriteLine($"Наименьший элемент массива [{row}, {col}]");

			int[,] newArray = new int[array.GetLength(0) - 1, array.GetLength(1) - 1];
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					if (i < row && j < col)
					{
						newArray[i, j] = array[i, j];
					}
					else if (i > row && j < col)
					{
						newArray[i - 1, j] = array[i, j];
					}
					else if (i > row && j > col)
					{
						newArray[i - 1, j - 1] = array[i, j];
					}
					else if (i < row && j > col)
					{
						newArray[i, j - 1] = array[i, j];
					}

				}
			}
			return newArray;
		}
		int[,] array4 = new int[4, 5];
		int[,] newArray4;
		CreateArray(array4);
		PrintArray(array4);
		newArray4 = ChangeArray4(array4);
		PrintArray(newArray4);
	}
}
