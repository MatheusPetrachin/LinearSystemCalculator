using System;
using System.Collections.Generic;
using System.Text;

namespace EliminaçãoDeGauss_Escalonamento
{
    class Program
    {
        static void Main(string[] args)
        {
            //definindo variaveis
            int N = 0;
            float[] b = new float[30];
            float[] x = new float[30];
            float[,] a = new float[30, 30];


            Console.Write("Digite a ordem do sistema: ");
            N = Convert.ToInt32(Console.ReadLine());

            //etodosLeMatriz(N);
            
                                   

            
        }        

        public static float Det(float a, float b, float c, float d)
        {
            return (a * d) - (b * c);
        }

        public static void Triangularizacao(int N, float[,] a, float[] b)
        {
            int k, i, j;

            for (k = 0; k < (N - 1); k++)
            {
                for (i = (k + 1); i < N; i++)
                {
                    for (j = (k + 1); j < N; j++)
                    {
                        a[i, j] = Det(a[k, k], a[i, k], a[k, j], a[i, j]);
                    }
                    b[i] = Det(a[k, k], a[i, k], b[k], b[i]);
                    a[i, k] = 0;
                }
            }
        }

        public static void Show(int N, float[,] a, float[] b)
        {
            Console.WriteLine("Nossa Matriz: ");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(a[i, j]);
                }
                Console.WriteLine(" " + b[i]);
            }
            Console.ReadLine();
        }

        public static void LeMatriz(int N, float[,] a, float[] b)
        {
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Linha: {i + 1}");
                for (int j = 0; j < N; j++)
                {
                    Console.WriteLine($"Coluna: {j + 1}");
                    a[i, j] = float.Parse(Console.ReadLine());
                }
                Console.WriteLine("B: ");
                b[i] = float.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}