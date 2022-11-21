//Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

void FillRandomElement(int[,,] array, int min, int max)
{
    Random rnd = new Random();

    int rows = array.GetLength(0);
    int columns = array.GetLength(1);
    int deep = array.GetLength(2);
    int newValue = 0;
    int[] listValues = new int[rows * columns * deep];
    int counter = 0;

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            for (int k = 0; k < deep; k++)
            {
                newValue = rnd.Next(min, max + 1);
                while (Array.IndexOf(listValues, newValue) >= 0)
                {
                    newValue = rnd.Next(min, max + 1);
                }
                array[i, j, k] = newValue;
                listValues[counter] = newValue;
                counter++;
            }
        }
    }
}

void PrintArray(int[,,] array)
{
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);
    int deep = array.GetLength(2);

    for (int k = 0; k < deep; k++)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"{array[i, j, k]}({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
    }
}

Console.Write("Введите количество строк: ");
int countLine = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов: ");
int countColumn = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите глубина: ");
int countDeep = Convert.ToInt32(Console.ReadLine());

//создаем массив
int[,,] array = new int[countLine, countColumn, countDeep];

//заполняем с учетом уникальности элементов
FillRandomElement(array, 10, 99);

PrintArray(array);
