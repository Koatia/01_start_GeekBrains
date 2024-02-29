internal class Program
{
	private static void Main(string[] args)
	{
		Console.Clear();

		Example01();
		Example02();
		Example03();
	}

	static void Example01()
	{
		// Напишите программу, которая будет принимать на вход число и возвращать сумму его цифр.
		// Указание - Использовать рекурсию.
		// Пример
		// 123 => 6
		// 63 => 9


		Console.Write("Введите число: ");
		int num = Convert.ToInt32(Console.ReadLine());

		System.Console.WriteLine(GetSumNember(num)); //123

		int GetSumNember(int newNum) //123
		{
			if (newNum == 0)
			{
				return 0;
			}

			return newNum % 10 + GetSumNember(newNum / 10);  // 3 + 2 +1 +0= 6
		}

	}

	static void Example02()
	{
		// Задайте значение N. Напишите программу, которая выведет все натуральные числа в промежутке от 1 до N.
		// Указание - Использовать рекурсию. Не использовать цикл.
		// Пример
		// N=5 => 1 2 3 4 5

		int num = new Random().Next(1, 10);
		Console.WriteLine("Наше число " + num);

		int firstElement = 1;

		PrintNumbers(firstElement, num);

		void PrintNumbers(int startEl, int endEl)
		{
			Console.Write(startEl);

			if (startEl == endEl)
			{
				return;
			}

			PrintNumbers(startEl + 1, endEl);
		}

	}

	static void Example03()
	{
		// Считать строку с консоли, содержащую латинские буквы. Вывести на экран согласные буквы этой строки.
		// Указание - Использовать рекурсию. Не использовать цикл.
		// Пример
		// “hello23” => h l l
		// “World” => W r l d
		// “Hello world!” => H l l w r l d

		string str = "14TeMmrI2";
		Console.Write(str);
		Console.Write(" => ");

		ShowСonsonants(str);

		void ShowСonsonants(string userInput)
		{
			if (userInput.Length == 0)
			{
				return;
			}

			string vowels = "aoiyeu";

			if (char.IsLetter(userInput[0]) && !vowels.Contains(char.ToLower(userInput[0])))
			{
				Console.Write(userInput[0]);
			}

			ShowСonsonants(userInput.Substring(1));
		}
	}
}
