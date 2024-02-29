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
		// Выводим сообщение, предлагающее пользователю ввести свое имя
		Console.WriteLine("Введите ваше имя ");
		// Читаем строку, введенную пользователем, и сохраняем ее в переменную 'username'
		string? username = Console.ReadLine();
		// Выводим приветствие, используя интерполяцию строк
		Console.WriteLine($"Hello, {username}");
	}
	static void Example02()
	{
		int numberA = new Random().Next(1, 10);
		int numberB = new Random().Next(1, 10);
		int result = numberA + numberB;
		Console.WriteLine($"{numberA} + {numberB} = {result}");

		double numberC = new Random().Next(1, 10);
		double numberD = new Random().Next(1, 10);
		Console.WriteLine($"{numberC} / {numberD} = {numberC / numberD}");
	}
	static void Example03()
	{
		// https://qna.habr.com/q/1160590
		// Внутри строки в нынешнем шарпе хранятся в utf-16, а в консоли - в utf-8.
		// чтобы работало, надо указать явно кодировку utf-16:
		//Console.InputEncoding = System.Text.Encoding.GetEncoding("utf-16");

		Console.Write("Введите имя пользователя: ");
		string? username = Console.ReadLine();

		// Проверяем, не равно ли введенное имя "masha" (в нижнем регистре) Для этого приводим введенное имя к нижнему регистру с помощью метода ToLower()
		if (username?.ToLower() == "masha" || username?.ToLower() == "маша")
		{
			Console.WriteLine("Ура, это же МАША!");
		}
		else
		{
			Console.WriteLine($"Привет, {username}");
		}

		// Ожидаем нажатия любой клавиши для закрытия консоли
		// Console.ReadLine();
	}
	static void Example04()
	{
		// Задание координат точек
		int xa = 40, ya = 1,
			xb = 1, yb = 30,
			xc = 80, yc = 30;

		// Рисование точек
		Console.SetCursorPosition(xa, ya);
		Console.WriteLine("#");

		Console.SetCursorPosition(xb, yb);
		Console.WriteLine("#");

		Console.SetCursorPosition(xc, yc);
		Console.WriteLine("#");

		// Начальные координаты
		int x = xa, y = ya;

		// Количество итераций
		int count = 0;

		while (count < 10000)
		{
			// Выбор случайной точки
			int point = new Random().Next(0, 3);

			// Перемещение в середину отрезка
			if (point == 0)
			{
				x = (x + xa) / 2;
				y = (y + ya) / 2;
			}

			if (point == 1)
			{
				x = (x + xb) / 2;
				y = (y + yb) / 2;
			}

			if (point == 2)
			{
				x = (x + xc) / 2;
				y = (y + yc) / 2;
			}

			// Рисование точки
			Console.SetCursorPosition(x, y);
			Console.WriteLine("#");

			// Увеличение счетчика
			count += 1;
		}

		// Возврат курсора в исходную точку
		Console.SetCursorPosition(xb, yb);
	}
}
