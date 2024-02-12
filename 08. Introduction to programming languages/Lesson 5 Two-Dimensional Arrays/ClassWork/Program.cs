internal class Program
{
	private static void Main(string[] args)
	{
		Console.Clear();

		Example01();
		Example02();
		Example03();
		Example04();
		Example05();
	}

	static void Example01()
	{
		// Задайте двумерный массив. Найдите элементы, у которых оба индекса чётные, и замените эти элементы на их квадраты.

		// 2 3 4 3
		// 4 3 4 1 =>
		// 2 9 5 4

		// 4 3 4 3
		// 4 3 4 1
		// 2 9 25 4

		int[,] array = new int[3, 4];

		void CreateArray()
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					array[i, j] = new Random().Next(1, 10);
				}
			}
		}

		void PrintArray()
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					System.Console.Write(array[i, j] + " ");
				}
				System.Console.WriteLine();
			}
			System.Console.WriteLine();
		}

		void FindElementsArray()
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					if (i % 2 == 0 && j % 2 == 0)
					{
						array[i, j] = array[i, j] * array[i, j];	// Math.Pow(array[i, j], 2);
					}
				}
			}
		}

		CreateArray();
		PrintArray();
		FindElementsArray();
		PrintArray();
	}

	static void Example02()
	{
		// Задайте двумерный массив. Найдите сумму элементов, находящихся на главной диагонали (с индексами (0,0); (1;1) и т.д.

		// 2 3 4 3
		// 4 3 4 1 => 2 + 3 + 5 = 10
		// 2 9 5 4

		int[,] array = new int[3, 4];

		void CreateArray()
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					array[i, j] = new Random().Next(1, 10);
				}
			}
		}

		void PrintArray()
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					System.Console.Write(array[i, j] + " ");
				}
				System.Console.WriteLine();
			}
			System.Console.WriteLine();
		}

		void FindElementsArray()
		{
			int sumElement = 0;

			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					if (i == j)
					{
						sumElement += array[i, j];
					}
				}
			}
			System.Console.WriteLine("Сумма = " + sumElement);
		}

		CreateArray();
		PrintArray();
		FindElementsArray();
	}

	static void Example03()
	{
		// Задайте двумерный массив из целых чисел. Сформируйте новый
		// одномерный массив, состоящий из средних арифметических
		// значений по строкам двумерного массива.
		// Пример
		// 2 3 4 3
		// 4 3 4 1 => [3 3 5]
		// 2 9 5 4

		int[,] array = new int[3, 4];
		double[] array2 = new double[array.GetLength(0)];

		void CreateArray()
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					array[i, j] = new Random().Next(1, 10);
				}
			}
		}

		void PrintArray()
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					System.Console.Write(array[i, j] + " ");
				}
				System.Console.WriteLine();
			}
			System.Console.WriteLine();
		}

		void FindElementsArray()
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				double sumElement = 0;

				for (int j = 0; j < array.GetLength(1); j++)
				{
					sumElement += array[i, j];
				}
				array2[i] = sumElement / array.GetLength(1);
			}
		}

		void PrintArray2()
		{
			for (int i = 0; i < array2.Length; i++)
			{
				System.Console.Write(array2[i] + " ");
			}
			System.Console.WriteLine();
		}

		CreateArray();
		PrintArray();
		FindElementsArray();
		PrintArray2();
	}

	static void Example04()
	{
		// Задача 4*(не обязательная): Задайте двумерный массив из целых чисел. Напишите программу, которая удалит строку и столбец, на пересечении которых расположен наименьший элемент массива. Под удалением понимается создание нового двумерного массива без строки и столбца

		// Создаем двумерный массив (например, 3x3)
		int[,] array = new int[,]
		{
	{ 6, 2, 3 },
	{ 4, 0, 6 },
	{ 7, 8, 9 }
		};

		// Находим индексы наименьшего элемента
		int minElement = int.MaxValue;
		int minRow = -1;
		int minColumn = -1;

		for (int row = 0; row < array.GetLength(0); row++)
		{
			for (int col = 0; col < array.GetLength(1); col++)
			{
				if (array[row, col] < minElement)
				{
					minElement = array[row, col];
					minRow = row;
					minColumn = col;
				}
			}
		}

		// Создаем новый массив без строки и столбца с наименьшим элементом
		int[,] trimmedArray = new int[array.GetLength(0) - 1, array.GetLength(1) - 1];
		int newRow = 0;

		for (int row = 0; row < array.GetLength(0); row++)
		{
			if (row == minRow)
				continue;

			int newColumn = 0;
			for (int col = 0; col < array.GetLength(1); col++)
			{
				if (col == minColumn)
					continue;

				trimmedArray[newRow, newColumn] = array[row, col];
				newColumn++;
			}
			newRow++;
		}

		// Выводим новый массив
		Console.WriteLine("Новый массив без строки и столбца с наименьшим элементом:");
		for (int row = 0; row < trimmedArray.GetLength(0); row++)
		{
			for (int col = 0; col < trimmedArray.GetLength(1); col++)
			{
				Console.Write(trimmedArray[row, col] + " ");
			}
			Console.WriteLine();
		}
	}

	static void Example05()  // Рекурсия
	{
		// вывод на экран двухмерного массива чисел (int)
		void ShowImage(int[,] matrix)
		{
			for (int rows = 0; rows < matrix.GetLength(0); rows++)
			{
				for (int columns = 0; columns < matrix.GetLength(1); columns++)
				{
					if (matrix[rows, columns] > 0)
					{
						Console.Write("#");
					}
					else
					{
						Console.Write(" ");
					}
				}
				Console.WriteLine();
			}
		}


		// закраска области, ограниченной границами (цветом)
		void FillImage(int[,] image, int x, int y)
		{
			int width = image.GetLength(1);
			int height = image.GetLength(0);

			if (image[y, x] > 0)
				return;
			image[y, x] = 1;
			if (x > 0)
				FillImage(image, x - 1, y);	 // заполняем слева
			if (y > 0)
				FillImage(image, x, y - 1);	 // сверху
			if (x < width - 1)
				FillImage(image, x + 1, y);	 // справа
			if (y < height - 1)
				FillImage(image, x, y + 1);	 // снизу
		}


		int[,] picture = new int[,] {
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,1,0,0,1,1,1,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0},
			{0,0,0,0,1,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,1,0,0,0,0,0,0,0,0},
			{0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0},
			{0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		};

		ShowImage(picture);
		FillImage(picture, 13, 6);
		ShowImage(picture);


		/*
		   Найти факториал числа с помощью рекурсии
			   factorial(n) = 1*2*3...*n
		   или
			   factorial(n) = n*...3*2*1

		   например:
			   factorial(5) = 5*4*3*2*1
		   что можно представить как:
			   factorial(5) = 5*factorial(4);

		   то есть, если обобщить:
			   factorial(n) = n * factorial(n-1)
		*/

		double Factorial(int n)
		{
			if (n > 1)
			{
				return n * Factorial(n - 1);
			}
			return 1;   // 0! и 1! - равны 1
		}


		Console.Write("Enter number: ");
		for (int num = 1; num < 30; num++)
		{
			Console.WriteLine($"Factorial number '{num}' = {Factorial(num)}");
		}

	}
}
