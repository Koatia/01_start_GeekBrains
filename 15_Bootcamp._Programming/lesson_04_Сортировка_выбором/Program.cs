using static Infrastructure;
using static Sorting;

Console.Clear();

Console.Write("Введите кол-во элементов массива: ");
int n = int.Parse(Console.ReadLine()!);

// int[] array = CreateArray(10);
// Show(array);
// SortSelection(array);
// Show(array);

n.CreateArray(min: 10, max: 100)
  .Show(separator: ", ")
  .SortSelection()
  .Show(separator: ", ");
