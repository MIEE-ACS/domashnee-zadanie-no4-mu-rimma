/*
Соседями элемента A_(i, j) в матрице назовем элементы A_(k, l),
где i-1≤k≤i+1, j-1≤l≤j+1,(k, l)  ≠(i, j). Операция сглаживания
матрицы дает новую матрицу того же размера,
каждый элемент которой получается как среднее арифметическое
имеющихся соседей соответствующего элемента исходной матрицы.
Построить результат сглаживания заданной вещественной матрицы размером 10 х 10.
В сглаженной матрице найти сумму модулей элементов, расположенных ниже главной диагонали. 
*/

using System;

namespace hw4_2
{
    class Program
    {
        static bool CheckPoint(string s)//функция проверки введённых данных
        {
            foreach (char item in s) //Цикл для поочередного обращения к элементам строки
            {
                if ((item != ',') || (item != '.'))
                {
                    if (char.IsDigit(item) == false) //определяет относится ли символ к числам
                    {
                        return true;
                    }
                }
                if ((item == ',') || (item == '.'))
                {
                    return true;
                }
            }
            return false;
        }

        static void RandArray(double[,] array, int n_col, int n_str)
        {
            Random rnd = new Random();

            for (int y = 0; y < n_str; y++)
            {
                for (int x = 0; x < n_col; x++)
                {
                    array[y, x] = rnd.Next(-50, 50) + rnd.NextDouble();
                }
            }
        }

        static void PrintArray(double[,] array, int n_col, int n_str)
        {
            for (int y = 0; y < n_str; y++)
            {
                for (int x = 0; x < n_col; x++)
                {
                    Console.Write("{0,7:F2}", array[y, x]);
                }
                Console.Write("\n\n");
            }
        }
        static void SortArray(double[,] array, int n_col, int n_str)
        {
            double tmp;
            for (int y = 0; y < n_str; y++)
                for (int x = 0; x < n_col; x++)
                {
                    tmp = 0;
                    
                    if (y > 0)
                    {
                        tmp += array[y - 1, x];
                        if (x > 0)
                            tmp += array[y - 1, x - 1];
                        if (x < n_col - 1)
                            tmp += array[y - 1, x + 1];
                    }
                    if (y < n_str - 1)
                    {
                        tmp += array[y + 1, x];
                        if (x > 0)
                            tmp += array[y + 1, x - 1];
                        if (x < n_col - 1)
                            tmp += array[y + 1, x + 1];
                    }
                    if (x > 0)
                        tmp += array[y,x - 1];
                    if (x < n_col - 1)
                        tmp += array[y, x + 1];
                    array[y, x] = tmp/4;
                }
        }

        static void FindSum(double[,] array, int n_col, int n_str)
        {
            double sum = 0;
            for (int y = 0; y < n_str; y++)
            {
                for (int x = 0; x < n_col; x++)
                {
                    if (x <= y)
                    {
                        sum += Math.Abs(array[y, x]);
                    }
                }
            }

            Console.Write("{0,7:F2}", sum);
        }
        static void Main(string[] args)
        {
            /*Console.Write("Введите колличество столбцов матрицы: ");
            string s = Console.ReadLine();
            while (CheckPoint(s))
            {
                Console.Write("\nОшибка. Введите число: ");
                s = Console.ReadLine();
            }
            int n_column = int.Parse(s);
            Console.Write("Введите колличество строк матрицы: ");
            s = Console.ReadLine();
            while (CheckPoint(s))
            {
                Console.Write("\nОшибка. Введите число: ");
                s = Console.ReadLine();
            }
            int n_string = int.Parse(s);
            */
            int n_column = 10, n_string = 10;

            double[,] array2 = new double[n_column, n_string];

            RandArray(array2, n_column, n_string);

            Console.WriteLine("Матрица: \n");
            PrintArray(array2, n_column, n_string);
            Console.Write("\n\n");

            Console.WriteLine("Преобразованная матрица: \n");
            SortArray(array2, n_column, n_string);
            PrintArray(array2, n_column, n_string);

            Console.Write("Сумма модулей элементов, расположенных ниже главной диагонали: ");
            FindSum(array2, n_column, n_string);
            Console.WriteLine("\n\n");
        }
    }
}