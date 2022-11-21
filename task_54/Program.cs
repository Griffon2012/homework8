//Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

void FillRandomElement(int[,] array, int min, int max)
{
    Random rnd = new Random();

    int rows = array.GetLength(0);
    int columns = array.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            array[i, j] = rnd.Next(min, max + 1);
        }
    }
}

void PrintArray(int[,] array)
{
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}

void SortElementsByRow(int[,] array)
{
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            if (j != columns - 1 && array[i, j] < array[i, j + 1])
            {
                (array[i, j], array[i, j + 1]) = (array[i, j + 1], array[i, j]);
                j = 0;
            }
        }
    }
}

Console.Write("Введите количество строк: ");
int countLine = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов: ");
int countColumn = Convert.ToInt32(Console.ReadLine());

//создаем массив
int[,] array = new int[countLine, countColumn];

//заполняем random
FillRandomElement(array, 0, 10);
PrintArray(array);

Console.WriteLine();

//сортируем
SortElementsByRow(array);
PrintArray(array);