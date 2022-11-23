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
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);
    int counter = 1;

    int nowRow = 0;
    int nowColumn = 0;
    int newRow = 0;
    int newColumn = 0;

    while (counter <= (Math.Pow(rows, 2)))
    {
        array[nowRow, nowColumn] = counter;
        if (nowColumn + 1 == columns || array[nowRow, nowColumn + 1] != 0)
        {
            turnLeft(array);
            newRow = columns - nowColumn - 1;
            newColumn = nowRow + 1;
            nowColumn = newColumn;
            nowRow = newRow;
        }
        else
        {
            nowColumn++;
        }
        counter++;
    }
//доворот матрица после заполнения для соответствия примеру (начало с левого верхнего угла)    
    turnLeft(array);
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