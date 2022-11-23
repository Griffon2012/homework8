//Напишите программу, которая заполнит спирально массив 4 на 4. 

void PrintArray(int[,] array)
{
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);

    Console.WriteLine();

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write($"{String.Format("{0,2:D2}", array[i, j])} ");
        }
        Console.WriteLine();
    }
}

void FillInSpiral(int[,] array)
{
    int columns = array.GetLength(1);
    int counter = 1;
    
    for (int k = 0; k < Math.Round(columns / 2.0, MidpointRounding.AwayFromZero); k++)
    {
        if (counter == (Math.Pow(columns, 2)))
        {
            array[k, k] = counter;
        }
        else
        {
            for (int j = 1; j <= 4; j++)
            {
                for (int i = k; i < columns - 1 - k; i++)
                {
                    array[k, i] = counter;
                    counter++;
                }
                turnLeft(array);
            }
        }
    }
}

void turnLeft(int[,] array)
{
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);

    int[,] newArray = new int[rows, columns];
    Array.Copy(array, newArray, array.Length);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            array[columns - 1 - j, i] = newArray[i, j];
        }
    }
}

Console.Write("Введите количество строк/столбцов: ");
int count = Convert.ToInt32(Console.ReadLine());

int[,] array = new int[count, count];

FillInSpiral(array);
PrintArray(array);