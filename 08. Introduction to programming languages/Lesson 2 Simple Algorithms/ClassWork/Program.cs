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
		void FillArray(int[] collection)
		{
			int lenght = collection.Length;
			int index = 0;
			while (index < lenght)
			{
				collection[index] = new Random().Next(1, 20);
				index++;
			}
		}

		void PrintArray(int[] col)
		{
			int count = col.Length;
			int position = 0;
			while (position < count)
			{
				Console.WriteLine(position + "\t" + col[position]);
				position++;
			}
		}

		int IndexOf(int[] collection, int find)
		{
			int count = collection.Length;
			int index = 0;
			int position = -1;
			while (index < count)
			{
				if (collection[index] == find)
				{
					position = index;
					break;
				}
				index++;
			}
			return position;
		}

		int[] array = new int[10];

		FillArray(array);
		PrintArray(array);

		Console.WriteLine();
		int num = 4;
		int pos = IndexOf(array, num);

		Console.WriteLine($"Число {num} имеет индекс {pos}");
		Console.WriteLine();
	}

	static void Example02()
	{
		// Напишите программу, которая выводит третью с конца
		// цифру заданного числа или сообщает, что третьей цифры
		// нет.
		// 456 => 4
		// 7812 % 1000 =  126
		// 91 => Третьей цифры нет

		Console.WriteLine("Введите число");
		int num = Convert.ToInt32(Console.ReadLine());

		if (num > 99)
		{
			if (num > 999)
			{
				num = num % 1000;
			}

			int result = num / 100;
			Console.WriteLine(result);
		}
		else
		{
			Console.WriteLine("Число не подходит");
		}
	}

	static void Example03()
	{
		// Напишите программу, которая принимает на вход трёхзначное
		// число и возводит вторую цифру этого числа в степень, равную
		// третьей цифре.
		// Примеры
		// 487 => 8^7 = 2 097 152
		// 254 => 5^4 = 625
		// 617 => 1

		Console.WriteLine("Введите число");
		int num = Convert.ToInt32(Console.ReadLine()); //256

		if (num > 99 && num < 1000)	//  && - и	|| - или
		{
			int num2 = num / 10 % 10;	//  5
			int num3 = num % 10;		  //  6
			int result = 1;

			while (num3 >= 1)
			{
				result = result * num2;
				num3--;
				// num3 = num3 - 1;
			}
			Console.WriteLine(result);
		}
		else
		{
			Console.WriteLine("Число не подходит");
		}

	}

	static void Example04()
	{
		// Напишите программу, которая будет принимать на вход два числа и выводить, является ли второе число кратным первому.
		// Если второе число некратно первому, то программа выводит остаток от деления.
		// 14, 5 => нет, 4
		// 16, 8 => да
		// 4, 3 => нет, 1

		Console.WriteLine("Введите число");
		int num1 = Convert.ToInt32(Console.ReadLine());

		Console.WriteLine("Введите число");
		int num2 = Convert.ToInt32(Console.ReadLine());

		if (num1 % num2 == 0)
		{
			Console.WriteLine("да");
		}
		else
		{
			Console.WriteLine("нет, " + num1 % num2);
		}

	}
}
