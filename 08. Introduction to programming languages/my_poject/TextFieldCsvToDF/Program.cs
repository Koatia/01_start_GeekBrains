using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

class Program
{
	static void Main()
	{
		string filePath = "D:/r12h_os41.csv";

		// Чтение данных из CSV файла в DataTable
		DataTable dataTable = ReadCsvToDataTable(filePath);

		// Пример вывода данных
		foreach (DataRow row in dataTable.Rows)
		{
			foreach (var item in row.ItemArray)
			{
				Console.Write(item + "\t");
			}
			Console.WriteLine();
		}
	}

	static DataTable ReadCsvToDataTable(string filePath)
	{
		using (var reader = new StreamReader(filePath))
		using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
		{
			// Преобразование данных в DataTable
			DataTable dataTable = new DataTable();
			csv.Read();
			csv.ReadHeader();
			foreach (string header in csv.Context.HeaderRecord)
			{
				dataTable.Columns.Add(header);
			}

			while (csv.Read())
			{
				DataRow row = dataTable.NewRow();
				foreach (string header in csv.Context.HeaderRecord)
				{
					row[header] = csv.GetField(header);
				}
				dataTable.Rows.Add(row);
			}

			return dataTable;
		}
	}
}
