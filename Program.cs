using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Варант12 Дана квадратная матрица. Увеличить все элементы строки с минимальной суммой элементов на среднее арифметическое
//элементов матрицы, лежащих выше главной диагонали
namespace ConsoleApp2
{
    class Program
    {
        static int MinSum(int[,] array)  //функция поиска номера строки с минимальной суммой
        {
            int min = 101;
            int ind = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                    sum += array[i, j];
                if (sum < min)
                {
                    min = sum;
                    ind = i + 1;
                }

            }
            return ind;

        }
        //функция подсчета среднего арифметического элементов над главной диагональю
        static int SrArif(int[,] array)
        {
            int k = 0;
            int s = 0;
            int sr = 0;
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = i + 1; j < array.GetLength(1); j++)
                {
                    k++;
                    s += array[i, j];

                }
            sr = s / k;
            return sr;
        }
        //вывод массива
        static void outp(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }

        }

        static void Main(string[] args)
        {
            Console.Write("Count of lines ");
            int sum, minInd;
            int s, k;
            int sr;
            int n = Convert.ToInt16(Console.ReadLine());
            int[,] matr = new int[n, n];
           

            for (int i = 0; i < matr.GetLength(0); i++)
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    
                    Console.Write(i + " " + j + " ");
                    matr[i, j] = Convert.ToInt32(Console.ReadLine());
                }

            outp(matr);


            //строка с мин суммой
            minInd = MinSum(matr);
            Console.WriteLine("Строка с минимальной суммой " + minInd);


            //ср ариф
            sr = SrArif(matr);
            Console.WriteLine("Среднее арифметическое элементов над главной диагональю " + sr);


            for (int j = 0; j < matr.GetLength(1); j++)
                matr[minInd - 1, j] += sr;
            Console.WriteLine("Измененная матрица");
            outp(matr);
            Console.ReadLine();


        }
    }
}
