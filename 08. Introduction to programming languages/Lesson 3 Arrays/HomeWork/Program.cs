internal class Program
{
	static Random random = new Random();

	public static void Main()
	{
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine("Урок 3. Массивы");

		Task1(); // Находит количество элементов массива, значения которых лежат в отрезке [20,90]
		Task2(); // Определяет количество чётных чисел в массиве
		Task3(); // Находит разницу между максимальным и минимальным элементов массива
		Task4(); // Создает массив, состоящий из цифр натурального числа

		Console.Read();
	}

	public static void Task1()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("\nЗадача 1:");
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Задайте одномерный массив из 10 целых чисел от 1 до 100. Найдите количество элементов массива, значения которых лежат в отрезке [20,90]");
		Console.ResetColor();
		// массив[10 21 14 93 23] => 2

		int[] array1 = new int[10];

		int count1 = 0;

		for (int i = 0; i < array1.Length; i++)
		{
			array1[i] = random.Next(1, 100);
			if (array1[i] >= 20 && array1[i] <= 90) count1++;
		}

		Console.WriteLine($"Массив: [{string.Join(" ", array1)}] => {count1}");
	}

	public static void Task2()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("\nЗадача 2:");
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Задайте массив на 10 целых чисел. Напишите программу, которая определяет количество чётных чисел в массиве");
		Console.ResetColor();
		// массив[6 7 19 34 3 1 4 7 9 1] => 3
		// массив[1 8 43 4 55 60 3 2 1 3] => 4

		int[] array2 = new int[10];

		int count2 = 0;

		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = random.Next(1, 100);
			if (array2[i] % 2 == 0) count2++;
		}

		Console.WriteLine($"Массив: [{string.Join(" ", array2)}] => {count2}");
	}

	public static void Task3()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("\nЗадача 3:");
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Задайте массив из вещественных чисел с ненулевой дробной частью. Найдите разницу между максимальным и минимальным элементов массива");
		Console.ResetColor();
		// массив[2.2 0.4 9.11 7.2 78.98] => 78.58
		// массив[1.22 4.5 3.33] => 3.28

		Console.Write("Введите размер массива: ");
		int num = Convert.ToInt32(Console.ReadLine());
		double[] array3 = new double[num];

		array3[0] = Math.Round(random.NextDouble() * 100, 2); // Округление до второго знака
		double min = array3[0];
		double max = array3[0];

		for (int i = 1; i < array3.Length; i++)
		{
			array3[i] = Math.Round(random.NextDouble() * 100, 2);
			if (array3[i] < min)
				min = array3[i];

			else if (array3[i] > max)
				max = array3[i];
		}

		Console.WriteLine($"Массив: [{string.Join(" ", array3)}] => {max - min}");
		Console.WriteLine($"Массив: [{string.Join(" ", array3.Select(x => x.ToString("0.##")))}] => {max - min:0.##}");
	}

	public static void Task4()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("\nЗадача 4:");
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Дано натуральное число в диапазоне от 1 до 100 000. Создайте массив, состоящий из цифр этого числа.");
		Console.WriteLine("Старший разряд числа должен располагаться на 0-м индексе массива, младший – на последнем. Размер массива должен быть равен количеству цифр");
		Console.ResetColor();
		// 425 => [4 2 5]
		// 8741 => [8 7 4 1]
		// 4 => [4]

		Console.Write("Введите натуральное число в диапазоне от 1 до 100000: ");
		int number;

		while (!int.TryParse(Console.ReadLine(), out number) || number < 1 || number >= 100000)
		{
			Console.Write("Некорректный ввод. Пожалуйста, введите натуральное число в диапазоне от 1 до 100000: ");
		}

		// Получаем количество цифр в числе
		int digitCount = GetDigitCount(number);

		// Создаем массив для хранения цифр и заполняем его цифрами числа
		int[] digitArray = new int[digitCount];
		FillDigitArray(number, digitArray);

		// Выводим результат
		Console.WriteLine($"{number} => [{string.Join(" ", digitArray)}]");

		// Метод для определения количества цифр в числе
		int GetDigitCount(int num)
		{
			int count = 0;
			while (num > 0)
			{
				num /= 10;
				count++;
			}
			return count;
		}

		// Метод для заполнения массива цифрами числа
		void FillDigitArray(int num, int[] array)
		{
			int index = array.Length - 1;
			while (num > 0)
			{
				array[index] = num % 10;
				num /= 10;
				index--;
			}
		}
	}
}
