using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;

class Program
{
	static void Main()
	{
		string pathToFile = "D:/r12h_os41.csv";
		string outputPath = "D:/output.csv";

		using (TextFieldParser parser = new TextFieldParser(pathToFile))
		{
			parser.TextFieldType = FieldType.Delimited;
			parser.SetDelimiters(";");

			using (StreamWriter writer = new StreamWriter(outputPath))
			{
				while (!parser.EndOfData)
				{
					string[] fields = parser.ReadFields();
					for (int i = 0; i < fields.Length; i++)
					{
						string field = fields[i];

						// Проверяем условие и изменяем значение field при необходимости
						if (field == "")
						{
							field = "null_value";
						}

						// Записываем значение в файл
						writer.Write(field);

						// Добавляем разделитель (в данном случае ";")
						if (i < fields.Length - 1)
						{
							writer.Write(";");
						}
					}

					// Переход на новую строку
					writer.WriteLine();
				}
			}
		}

		Console.WriteLine("Файл успешно обработан и сохранен в " + outputPath);
	}
}
