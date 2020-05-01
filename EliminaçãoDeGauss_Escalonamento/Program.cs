using System;
using System.Collections.Generic;
using System.Text;

namespace EliminaçãoDeGauss_Escalonamento
{
    class Program
    {
        static int N = 0;
        static float S = 0;
        static float[] b = new float[30];
        static float[] x = new float[30];
        static float[,] a = new float[30, 30];

        static void Main(string[] args)
        {
            LeMatriz();
            Triangular();
            Solucao();
            Resultado();
            Console.ReadLine();
            
        }

        public static void LeMatriz()
        {
            Console.Write("Digite a ordem do sistema: ");
            N = Convert.ToInt32(Console.ReadLine());

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
            Show();
            Console.ReadLine();
        }

        public static float Det(float a, float b, float c, float d)
        {
            return (a * d) - (b * c);
        }

        public static void Triangular()
        {
            int k, i, j;

            for (k = 0; k < (N - 1); k++)
            {
                for (i = (k + 1); i < N; i++)
                {
                    for (j = (k + 1); j < N; j++)
                    {
                        a[i, j] = Det(a[k, k], a[i, k], a[k, j], a[i, j]);
                        Show();
                    }
                    b[i] = Det(a[k, k], a[i, k], b[k], b[i]);
                    a[i, k] = 0;
                    Show();
                }
            }
        }

        public static void Solucao()
        {
            x[N - 1] = b[N - 1] / a[N - 1, N - 1];
            for (int k = N - 2; k >= 0; k--)
            {
                S = 0;
                for (int j = k + 1; j < N; j++)
                    S += a[k, j] * x[j];
                x[k] = (b[k] - S) / a[k, k];
            }
        }

        public static void Resultado()
        {
            Console.WriteLine("Solução do Problema");
            for (int i = 0; i < N; i++)
                Console.WriteLine(" {0} ", Math.Round(x[i], 3));
        }


        public static void Show()
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

    }
}