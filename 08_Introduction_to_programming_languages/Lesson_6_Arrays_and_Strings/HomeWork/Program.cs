internal class Program
{
	private static void Main()
	{
		Console.InputEncoding = System.Text.Encoding.GetEncoding("utf-16");
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine("Урок 6. Массивы и строки");

		Task1(); // Создает строку из символов двумерного массива символов
		Task2(); // Создает строку, в которой все заглавные буквы заменены на строчные
		Task3(); // Определяет, является ли строка палиндромом
		Task4(); // Создает строку, в которой слова расположены в обратном порядке
		Console.Read();
	}

	public static void Task1()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("Задача 1:");
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Задайте двумерный массив символов (тип char [,]). Создать строку из символов этого массива.\n");
		Console.ResetColor();

		char[,] array1 = {
	{'q','w','e','r','t'},
	{'a','s','d','f','g'},
	{'z','x','c','v','b'}
	};

		string str1 = "";

		for (int i = 0; i < array1.GetLength(0); i++)
		{
			for (int j = 0; j < array1.GetLength(1); j++)
			{
				str1 += array1[i, j];
				Console.Write(array1[i, j] + " ");
			}
			Console.WriteLine();
		}

		Console.WriteLine($"\n{str1}\n");
	}
	public static void Task2()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("Задача 2:");
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Задайте строку, содержащую латинские буквы в обоих регистрах. Сформируйте строку, в которой все заглавные буквы заменены на строчные.\n");
		Console.ResetColor();

		string str2 = "aSdFgHjKl-!";

		Console.WriteLine($"{str2} => {str2.ToLower()}\n");
	}
	public static void Task3()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("Задача 3:");
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Задайте произвольную строку. Выясните, является ли она палиндромом.\n");
		Console.ResetColor();

		Console.Write("Задайте произвольную строку: ");
		string str3 = Console.ReadLine();

		string IsPolindrom(string str)
		{
			// Нормализация строки путем удаления не буквенно-цифровых символов и приведения к нижнему регистру
			string normalized = new string(str.Where(char.IsLetterOrDigit).ToArray()).ToLower();

			for (int i = 0; i < normalized.Length / 2; i++)
			{
				if (normalized[i] != normalized[normalized.Length - 1 - i])
				{
					return "Нет, это не палиндром";
				}
			}
			return "Да, это палиндром";
		}

		Console.WriteLine($"\n{str3} => {IsPolindrom(str3)}\n");
	}
	public static void Task4()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("Задача 4:");
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Задайте строку, состоящую из слов, разделенных пробелами. Сформировать строку, в которой слова расположены в обратном порядке. В полученной строке слова должны быть также разделены пробелами.\n");
		Console.ResetColor();

		string str4 = "Hello my world";
		Console.Write($"{str4} =>");

		string[] words = str4.Split(" ");

		for (int i = words.Length - 1; i >= 0; i--)
		{
			Console.Write($" {words[i]}");
		}
	}
}
