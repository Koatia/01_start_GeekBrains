internal class Program
{
	static Random random = new Random();

	public static void Main()
	{
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine("Урок 4. Функции");

		Task1(); // Программа завершается при вводе символа ‘q’ или при вводе числа, сумма цифр которого чётная
		Task2(); // покажет количество чётных чисел в массиве
		Task3(); // перевернёт одномерный массив
		Console.Read();
	}

	public static void Task1()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("Задача 1:");
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Напишите программу, которая бесконечно запрашивает целые числа с консоли. " +
			"Программа завершается при вводе символа ‘q’ или при вводе числа, сумма цифр которого чётная");
		Console.ResetColor();

		while (true) // Бесконечный цикл
		{
			Console.Write("Введите целое число или 'q' для выхода: ");
			string? input = Console.ReadLine(); // Чтение строки ввода пользователя
			if (input == "q") // Проверка на ввод 'q' для выхода
			{
				Console.WriteLine("Нажата 'q' для выхода");
				break;
			}
			int number;
			if (int.TryParse(input, out number)) // Проверка, является ли ввод числом
			{
				int sum = 0;
				while (number > 0) // Вычисление суммы цифр числа
				{
					sum += number % 10; // Добавление последней цифры к сумме
					number /= 10; // Удаление последней цифры из числа
				}
				if (sum % 2 == 0) // Проверка, является ли сумма цифр четной
				{
					Console.WriteLine("[STOP]");
					break;
				}
			}
			else // Если ввод не является числом и не 'q', повторить запрос
			{
				Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число или 'q'.");
			}
		}
	}

	public static void Task2()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("\nЗадача 2:");
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Задайте массив заполненный случайными трёхзначными числами. " +
			"Напишите программу, которая покажет количество чётных чисел в массиве");
		Console.ResetColor();

		Console.Write("Введите количество элементов массива: ");
		int num2 = Convert.ToInt32(Console.ReadLine());
		int[] array2 = new int[num2];
		int count2 = 0;

		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = random.Next(100, 1000);
			if (array2[i] % 2 == 0) count2++;
		}

		Console.WriteLine($"Массив: [{string.Join(" ", array2)}] => {count2}");
	}

	public static void Task3()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("\nЗадача 3:");
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Напишите программу, которая перевернёт одномерный массив (первый элемент станет последним, второй – предпоследним и т.д.)");
		Console.ResetColor();

		Console.Write("Введите количество элементов массива: ");
		int num3 = Convert.ToInt32(Console.ReadLine());
		int[] array3 = new int[num3];
		int[] reverseArray3 = new int[num3];

		for (int i = 0; i < num3; i++)
		{
			array3[i] = random.Next(1, 1000);
			reverseArray3[num3 - 1 - i] = array3[i];
		}

		PrintArray(array: array3, text: "Входящий массив: ");
		PrintArray(array: reverseArray3, text: "Исходящий массив:");

		// Метод для печати массива
		void PrintArray(int[] array, string text)
		{
			Console.WriteLine($"{text} [{string.Join(" ", array)}]");
		}
	}
}
