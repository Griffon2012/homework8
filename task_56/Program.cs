//Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

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

int GetRowNumberWithMinSum(int[,] array)
{
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);
    int minSum = array[0, 0];
    int sum = 0;
    int rowIndexMinSum = 0;

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            sum += array[i, j];
        }
        if (minSum > sum)
        {
            minSum = sum;
            rowIndexMinSum = i;
        }
        sum = 0;
    }

    return rowIndexMinSum + 1;
}

Console.Write("Введите количество строк: ");
int countLine = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов: ");
int countColumn = Convert.ToInt32(Console.ReadLine());

if (countLine == countColumn)
{
    Console.WriteLine("Массив не прямоугольный");
}
else
{
    //создаем массив
    int[,] array = new int[countLine, countColumn];

    //заполняем random
    FillRandomElement(array, 0, 10);
    PrintArray(array);

    Console.WriteLine();

    int stringNumberWithMinSum = GetRowNumberWithMinSum(array);
    Console.WriteLine($"Строка с минимальной суммой элементов: {stringNumberWithMinSum}");

}