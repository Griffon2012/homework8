// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

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

int[,] GetMultiMatrix(int[,] matrix1, int[,] matrix2)
{
    int rows1 = matrix1.GetLength(0);
    int columns1 = matrix1.GetLength(1);

    int rows2 = matrix2.GetLength(0);
    int columns2 = matrix2.GetLength(1);

    int[,] resultMatrix = new int[rows1, columns2];

    int sum = 0;

    for (int i = 0; i < rows1; i++)
    {
        for (int k = 0; k < columns2; k++)
        {
            sum = 0;
            for (int j = 0; j < rows2; j++)
            {
                sum += matrix1[i, j] * matrix2[j, k];
            }
            resultMatrix[i, k] = sum;
        }
    }

    return resultMatrix;
}

Console.Write("Введите количество строк первой матрицы: ");
int countLine1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов первой матрицы: ");
int countColumn1 = Convert.ToInt32(Console.ReadLine());

Console.Write("Введите количество строк второй матрицы: ");
int countLine2 = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов второй матрицы: ");
int countColumn2 = Convert.ToInt32(Console.ReadLine());


if (countColumn1 != countLine2)
{
    Console.WriteLine("Матрицы не совместимы");
}
else
{
    //создаем массив
    int[,] array1 = new int[countLine1, countColumn1];
    FillRandomElement(array1, 0, 10);

    //создаем массив2
    int[,] array2 = new int[countLine2, countColumn2];
    FillRandomElement(array2, 0, 10);

    PrintArray(array1);

    Console.WriteLine();

    PrintArray(array2);

    int[,] multiMatrix = GetMultiMatrix(array1, array2);

    Console.WriteLine();

    PrintArray(multiMatrix);
}

