using System;
using System.Collections.Generic;
using System.Linq;

namespace hw4
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

        static void RandArray(double[] array, int n)
        {
            Random rnd = new();
            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(-50, 50) + rnd.NextDouble();
            }
        }
        static void PrintArray(double[] array, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0,7:F2}", array[i]);
            }
        }

        static double FindMaxAbs(double[] array, int n)//поиск максимального по модулю элемента в массиве
        {
            double m = 0;
            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(array[i]) > Math.Abs(m))
                {
                    m = array[i];
                }
            }
            return m;
        }

        static double FindSum(double[] array, int n)//поиск суммы эл массива, располож м/у 1 и 2 положительными элементами
        {
            double sum = 0;
            int index1 = -1, index2 = -1;
            for (int i = 0; i < n; i++)
            {
                if (array[i] > 0)
                {
                    index1 = i;
                    break;
                }
                if ((array[i] > 0) && (i != index1))
                {
                    index2 = i;
                    break;
                }
            }
            for (int i = index1; i < index2; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        static double[] Buff(double[] array, int n)
        {
            int m = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] == 0)
                {
                    m++;
                }
            }

            double[] array1 = new double[n - m];
            double[] array2 = new double[m];
            for (int i =0; i < n; i++)
            {
                if (array[i] != 0)
                {
                    array1[i] = array[i];
                }
                else
                {
                    array2[i] = array[i];
                }
            }

            array = array1.Concat(array1).ToArray();
            return array;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите количество элементов массива: ");
            string s = Console.ReadLine();
            while  (CheckPoint(s))
            {
                Console.Write("\nОшибка. Введите число: ");
                s = Console.ReadLine();
            }
            int n = int.Parse(s);
            double[] array = new double[n];
            Console.Write("\nМассив: \n");
            RandArray(array, n);
            PrintArray(array, n); ;
            Console.Write($"\nМаксимальный по модулю элемент массива: {FindMaxAbs(array, n)}");
            Console.Write($"\nСумма элементов массива, расположенных между первым и вторым \nположительными элементами: {FindSum(array, n)}");
            
            array = Buff(array, n);
            Console.Write("\nПреобразованный массив: \n");
            PrintArray(array, n);
            Console.Write("\n\n");
        }
    }
}
/*
 В одномерном массиве, состоящем из n-вещественных элементов, вычислить:
•	максимальный по модулю элемент массива;
•	сумму элементов массива, расположенных между первым и вторым положительными элементами.
Преобразовать массив таким образом, чтобы элементы, равные нулю, располагались после всех остальных.
 */
