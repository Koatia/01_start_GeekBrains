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
		int firstNumber = 5;
		int secondNumber = 5;

		CompareNumbers(firstNumber, secondNumber);

		static void CompareNumbers(int firstNumber, int secondNumber)
		{
			if (firstNumber < secondNumber)
			{
				Console.WriteLine("Первое число `" + firstNumber + "` меньше чем второе число `" + secondNumber + "`");
			}
			else if (firstNumber > secondNumber)
			{
				Console.WriteLine("Первое число `" + firstNumber + "` больше чем второе число `" + secondNumber + "`");
			}
			else
			{
				Console.WriteLine("Введенные числа равны `" + secondNumber + "`");
			}
		}
	}
	static void Example02()
	{
		int a = 5;
		int b = 6;
		int c = 7;

		int result = FindMax(a, b, c);
		Console.WriteLine($"{result}");

		static int FindMax(int a, int b, int c)
		{
			// Введите свое решение ниже
			int max = a;
			if (b > max) max = b;
			if (c > max) max = c;

			return max;
		}
	}
	static void Example03()
	{
		int number = 7;
		CheckIfEven(number);

		static void CheckIfEven(int number)
		{
			// Введите свое решение ниже
			if (number % 2 == 0) Console.WriteLine("Число `" + number + "` чётное");
			else Console.WriteLine("Число `" + number + "` нечётное");
		}
	}

	static void Example04()
	{
		static void PrintEvenNumbers(int number)
		{
			// Введите свое решение ниже
			int count = 2;

			while (count <= number)
			{
				Console.Write(count);
				count += 2;
				if (number >= count) Console.Write("\t");
			}
		}

		int number = 8;
		PrintEvenNumbers(number);
	}
}
