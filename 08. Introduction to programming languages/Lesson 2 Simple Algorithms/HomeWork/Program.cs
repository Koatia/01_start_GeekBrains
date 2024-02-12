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
		Console.WriteLine("Задача 1:");
		Console.WriteLine("Напишите программу, которая принимает на вход число и проверяет, кратно ли оно одновременно 7 и 23");

		Console.Write("Введите число: ");
		int num1 = Convert.ToInt32(Console.ReadLine());

		if (num1 % 7 == 0 && num1 % 23 == 0)
		{
			Console.WriteLine("Это число кратно одновременно 7 и 23");
		}
		else Console.WriteLine("Это число НЕ кратно одновременно 7 и 23");
	}

	static void Example02()
	{
		Console.WriteLine();
		Console.WriteLine("Задача 2:");
		Console.WriteLine("Напишите программу, которая принимает на вход координаты точки (X и Y), причём X ≠ 0 и Y ≠ 0");
		Console.WriteLine("и выдаёт номер координатной четверти плоскости, в которой находится эта точка");

		// номер четверти для заданной точки (x, y):
		// Первая четверть(I): Если обе координаты x и y положительны.
		// Вторая четверть (II): Если x отрицательно, а y положительно.
		// Третья четверть (III): Если и x, и y отрицательны.
		// Четвёртая четверть (IV): Если x положительно, а y отрицательно.

		Console.Write("Введите координаты точки X и Y через пробел: ");
		string[] coordinates = Console.ReadLine().Split(' ');
		int x = Convert.ToInt32(coordinates[0]);
		int y = Convert.ToInt32(coordinates[1]);

		int quadrant = GetQuadrant(x, y);

		if (quadrant == 0)
		{
			Console.WriteLine("Точка лежит в начале координат.");
		}
		else
		{
			Console.WriteLine($"Точка лежит в {quadrant}-й четверти.");
		}

		int GetQuadrant(double x, double y)
		{
			if (x > 0 && y > 0)
			{
				return 1;
			}
			else if (x < 0 && y > 0)
			{
				return 2;
			}
			else if (x < 0 && y < 0)
			{
				return 3;
			}
			else if (x > 0 && y < 0)
			{
				return 4;
			}
			else
			{
				return 0; // Точка лежит в начале координат
			}
		}
	}

	static void Example03()
	{
		Console.WriteLine();
		Console.WriteLine("Задача 3:");
		Console.WriteLine("Напишите программу, которая принимает на вход целое число из отрезка [10, 99] и показывает наибольшую цифру числа");

		int MaxNum(int number)
		{
			int firstDigit = number / 10;
			int secondDigit = number % 10;
			int max = 0;
			if (firstDigit > secondDigit) max = firstDigit;
			else max = secondDigit;
			return max;
		}

		int number = new Random().Next(10, 100);
		Console.WriteLine($"В числе {number} наибольшая цифра {MaxNum(number)}");

	}

	static void Example04()
	{
		Console.WriteLine();
		Console.WriteLine("Задача 4:");
		Console.WriteLine("Напишите программу, которая на вход принимает натуральное число N, а на выходе показывает его цифры через запятую");

		static List<int> NumInList(int num)
		{
			var digitList = new List<int>();
			while (num > 0)
			{
				digitList.Add(num % 10);
				num /= 10;
			}
			digitList.Reverse();
			return digitList;
		}

		static void PrintList(List<int> digitList)
		{
			Console.Write("Цифры числа через запятую: ");
			Console.WriteLine(string.Join(",", digitList));
		}

		int num = new Random().Next(10000, 100000000);
		Console.WriteLine($"Введено число: {num}");
		var digitList = NumInList(num);
		PrintList(digitList);

		Console.WriteLine();


		// Упрощенное решение )))

		if (num > 0)
		{
			string numberStr = num.ToString();
			for (int i = 0; i < numberStr.Length; i++)
			{
				Console.Write(numberStr[i]);
				if (i < numberStr.Length - 1)
				{
					Console.Write(",");
				}
			}
		}
		else
		{
			Console.WriteLine("Число должно быть натуральным.");
		}

	}
}
