/*
Этот код демонстрирует реализацию сортировки подсчетом в однопоточном и многопоточном режимах.
В многопоточной версии используется блокировка для синхронизации доступа к общему массиву счетчиков.
В конце происходит проверка на равенство отсортированных массивов, чтобы убедиться,
что параллельная сортировка дает тот же результат, что и последовательная

*/

internal class Program
{
	private static void Main(string[] args)
	{
		const int THREADS_NUMBER = 4; // Количество потоков для параллельной обработки
		const int N = 100000; // Размер массива для сортировки
		object lock_object = new object(); // Объект блокировки для синхронизации потоков

		// Инициализация массивов для последовательной и параллельной сортировки
		Random rand = new Random();
		int[] resSerial = new int[N].Select(r => rand.Next(0, 5)).ToArray(); // Создание массива размером N и заполнение его случайными числами в диапазоне (0, 5)
		int[] resParallel = new int[N];

		// Копирование данных из последовательного массива в параллельный
		Array.Copy(resSerial, resParallel, N);

		// Сортировка массивов
		CountingSortExtended(resSerial); // Последовательная сортировка
		PrepareParallelCountingSort(resParallel); // Параллельная сортировка

		// Проверка на равенство отсортированных массивов
		Console.WriteLine(EqualityMatrix(resSerial, resParallel));



		// Функция подготовки к параллельной сортировке подсчетом
		void PrepareParallelCountingSort(int[] inputArray)
		{
			// Определение максимального и минимального элементов
			int max = inputArray.Max();
			int min = inputArray.Min();

			int offset = -min; // Смещение для поддержки отрицательных чисел
			int[] counters = new int[max + offset + 1]; // Массив счетчиков

			int eachThreadCalc = N / THREADS_NUMBER; // Количество элементов на поток
			var threadsParall = new List<Thread>(); // Список потоков

			// Создание и запуск потоков
			for (int i = 0; i < THREADS_NUMBER; i++)
			{
				int startPos = i * eachThreadCalc; // Начальная позиция для потока
				int endPos = (i + 1) * eachThreadCalc; // Конечная позиция для потока
				if (i == THREADS_NUMBER - 1)
				{
					endPos = N; // Корректировка для последнего потока
				}

				threadsParall.Add(new Thread(() => CountingSortParallel(inputArray, counters, offset, startPos, endPos))); // Добавляем поток в список потоков
				threadsParall[i].Start(); // Запускаем поток
			}

			// Ожидание завершения всех потоков
			foreach (var thread in threadsParall)
			{
				thread.Join();
			}

			// Пересборка отсортированного массива из счетчиков
			int index = 0;
			for (int i = 0; i < counters.Length; i++)
			{
				for (int j = 0; j < counters[i]; j++)
				{
					inputArray[index] = i - offset;
					index++;
				}
			}
		}

		// Функция параллельной сортировки подсчетом
		void CountingSortParallel(int[] inputArray, int[] counters, int offset, int startPos, int endPos)
		{
			for (int i = startPos; i < endPos; i++)
			{
				lock (lock_object) // Блокировка для синхронизации доступа к общему ресурсу
				{
					counters[inputArray[i] + offset]++;
				}
			}
		}

		// Расширенная функция сортировки подсчетом
		void CountingSortExtended(int[] inputArray)
		{
			// Аналогично PrepareParallelCountingSort, но для однопоточной обработки
			int max = inputArray.Max();
			int min = inputArray.Min();

			int offset = -min;
			int[] counters = new int[max + offset + 1];

			for (int i = 0; i < inputArray.Length; i++)
			{
				counters[inputArray[i] + offset]++;
			}

			int index = 0;
			for (int i = 0; i < counters.Length; i++)
			{
				for (int j = 0; j < counters[i]; j++)
				{
					inputArray[index] = i - offset;
					index++;
				}
			}
		}

		// Функция для проверки равенства двух массивов
		bool EqualityMatrix(int[] fmatrix, int[] smatrix)
		{
			bool res = true;

			for (int i = 0; i < N; i++)
			{
				res = res && fmatrix[i] == smatrix[i];
			}

			return res;
		}
	}
}
