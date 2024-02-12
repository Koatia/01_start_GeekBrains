class Program
{
	static void Main()
	{
		// Исходный массив строк
		string[] originalArray = { "apple", "cat", "dog", "banana", "sky", "cup" };

		// Подсчёт строк, удовлетворяющих условию
		int count = 0;
		foreach (var item in originalArray)
		{
			if (item.Length <= 3) count++;
		}

		// Создание нового массива для отфильтрованных строк
		string[] filteredArray = new string[count];
		int index = 0;
		foreach (var item in originalArray)
		{
			if (item.Length <= 3)
			{
				filteredArray[index++] = item;
			}
		}

		// Вывод результата
		Console.Clear();
		Console.WriteLine($"[\"{string.Join("\", \"", originalArray)}\"] -> [\"{string.Join("\", \"", filteredArray)}\"]");
	}
}
