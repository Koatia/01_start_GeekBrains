internal class Program
{
	static Random random = new Random();

	public static void Main()
	{
		Console.InputEncoding = System.Text.Encoding.GetEncoding("utf-16");
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine("Урок 7. Рекурсия");

		Task1(); // выводит натуральные числа в заданном диапазоне с использованием рекурсии.
		Task2(); // вычисляет функцию Аккермана с использованием рекурсии.
		Task3(); // выводит элементы массива, начиная с конца, с использованием рекурсии.
		Console.Read();
	}

	public static void Task1()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("\nЗадача 1:");
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Задайте значения M и N. Напишите программу, которая выведет все натуральные числа в промежутке от M до N. Использовать рекурсию, не использовать циклы");
		Console.ResetColor();

		int m1 = random.Next(0, 10);
		int n1 = m1 + random.Next(0, 10);

		Console.Write($"М = {m1}; N = {n1} => \"");
		PrintArray(m1, n1);

		void PrintArray(int startNum, int endNum)
		{
			if (startNum == endNum)
			{
				Console.WriteLine($"{startNum}\"");
				return;
			}

			Console.Write(startNum + ", ");
			PrintArray(startNum + 1, endNum);
		}
	}

	public static void Task2()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("\nЗадача 2:");
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n");
		Console.ResetColor();

		int m2 = random.Next(0, 4);
		int n2 = random.Next(0, 4);

		Console.Write($"М = {m2}; N = {n2} => ");
		Console.WriteLine($"A({m2}, {n2}) = {FuncAcc(m2, n2)}");

		int FuncAcc(int m, int n)
		{
			if (m == 0)
			{
				return n + 1;
			}
			else if (m > 0 && n == 0)
			{
				return FuncAcc(m - 1, 1);
			}
			else
			{
				return FuncAcc(m - 1, FuncAcc(m, n - 1));
			}
		}
	}

	public static void Task3()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("\nЗадача 3:");
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Задайте произвольный массив. Выведете его элементы, начиная с конца. Использовать рекурсию, не использовать циклы");
		Console.ResetColor();

		int[] array3 = new int[7];
		int lastIndex = array3.Length - 1;

		InitArray(array3, lastIndex);

		Console.Write($"Массив: [{string.Join(", ", array3)}] => ");
		ReverseArr(array3, lastIndex);
		Console.WriteLine();

		void InitArray(int[] array, int index)
		{
			array[index] = random.Next(10, 100);
			if (index == 0) return;
			InitArray(array, index - 1);
		}

		void ReverseArr(int[] array, int index)
		{
			if (index == 0)
			{
				Console.WriteLine(array[index]);
				return;
			}
			Console.Write($"{array[index]} ");
			ReverseArr(array, index - 1);
		}
	}
}
