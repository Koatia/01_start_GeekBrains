/*
Описание

1. **Константы**:
	- `N`: Размер стороны квадратных матриц.
	- `THREADS_NUMBER`: Количество потоков, используемых для параллельного вычисления.

	2. **Матрицы для Результатов**:
	- `serialMulRes`: Для хранения результата последовательного умножения матриц.
	- `threadMulRes`: Для хранения результата параллельного умножения матриц.

	3. **Генерация Матриц**:
	- `MatrixGenerator`: Функция для генерации квадратных матриц заданного размера с случайными значениями.

	4. **Умножение Матриц**:
	- `SerialMatrixMul`: Функция для последовательного умножения матриц.
	- `PrepareParallelMatrixMul`: Функция для подготовки и запуска параллельного умножения матриц.
	- `ParallelMatrixMul`: Функция для выполнения умножения матриц в отдельном потоке.

	5. **Сравнение Результатов**:
	- `EqualityMatrix`: Функция для проверки равенства двух матриц (результатов последовательного и параллельного умножения).
*/

internal class Program
{
	private static void Main(string[] args)
	{
		//размер матрицы
		const int N = 1000;

		// Количество потоков для параллельных вычислений
		const int THREADS_NUMBER = 10;

		//результат выполнения умножения матриц в однопотоке
		int[,] serialMulRes = new int[N, N];

		//результат параллельного умножения матриц
		int[,] threadMulRes = new int[N, N];

		// Генерация первой и второй матриц случайными числами
		int[,] firstMatrix = MatrixGenerator(N, N);
		int[,] secondMatrix = MatrixGenerator(N, N);

		// Выполнение последовательного умножения матриц
		SerialMatrixMul(firstMatrix, secondMatrix);

		// Подготовка и выполнение параллельного умножения матриц
		PrepareParallelMatrixMul(firstMatrix, secondMatrix);

		// Сравнение результатов последовательного и параллельного умножения
		Console.WriteLine(EqualityMatrix(serialMulRes, threadMulRes));

		// Генерация матрицы с случайными элементами
		int[,] MatrixGenerator(int rows, int columns)
		{
			Random _rand = new Random();
			int[,] res = new int[rows, columns];
			for (int i = 0; i < res.GetLength(0); i++)
			{
				for (int j = 0; j < res.GetLength(1); j++)
				{
					res[i, j] = _rand.Next(-100, 100);
				}
			}
			return res;
		}

		// Функция последовательного умножения матриц
		void SerialMatrixMul(int[,] a, int[,] b)
		{
			if (a.GetLength(1) != b.GetLength(0))
			{
				throw new Exception("Нельзя умножить такие матрицы");
			}

			for (int i = 0; i < a.GetLength(0); i++)
			{
				for (int j = 0; j < b.GetLength(1); j++)
				{
					for (int k = 0; k < b.GetLength(0); k++)
					{
						serialMulRes[i, j] += a[i, k] * b[k, j];
					}
				}
			}
		}

		// Подготовка и выполнение параллельного умножения матриц
		void PrepareParallelMatrixMul(int[,] a, int[,] b)
		{
			if (a.GetLength(1) != b.GetLength(0))
			{
				throw new Exception("Нельзя умножить такие матрицы");
			}

			int eachThreadCalc = N / THREADS_NUMBER;
			Thread[] arr = new Thread[2];
			var threadsList = new List<Thread>();
			for (int i = 0; i < THREADS_NUMBER; i++)
			{
				int startPos = i * eachThreadCalc;
				int endPos = (i + 1) * eachThreadCalc;
				//если последний поток
				if (i == THREADS_NUMBER - 1)
				{
					endPos = N;
				}

				threadsList.Add(new Thread(() => ParallelMatrixMul(a, b, startPos, endPos)));
				threadsList[i].Start();
			}
			for (int i = 0; i < THREADS_NUMBER; i++)
			{
				threadsList[i].Join();
			}
		}

		// Функция параллельного умножения матриц
		void ParallelMatrixMul(int[,] a, int[,] b, int startPos, int endPos)
		{
			for (int i = startPos; i < endPos; i++)
			{
				for (int j = 0; j < b.GetLength(1); j++)
				{
					for (int k = 0; k < b.GetLength(0); k++)
					{
						threadMulRes[i, j] += a[i, k] * b[k, j];
					}
				}
			}
		}

		// Функция для проверки равенства двух матриц
		bool EqualityMatrix(int[,] fmatrix, int[,] smatrix)
		{
			bool res = true;

			for (int i = 0; i < fmatrix.GetLength(0); i++)
			{
				for (int j = 0; j < fmatrix.GetLength(1); j++)
				{
					res = res && fmatrix[i, j] == smatrix[i, j];
				}
			}

			return res;
		}
	}
}
