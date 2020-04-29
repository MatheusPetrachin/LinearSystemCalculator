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

            //coletando dados
            Console.Write("Digite a ordem do sistema: ");
            N = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Linha: {i+1}");
                for (int j = 0; j < N; j++)
                {
                    Console.WriteLine($"Coluna: {j+1}");
                    a[i, j] = float.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }
            Console.ReadLine();

            //apresentando matriz
            Console.WriteLine("Nossa Matriz: ");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(a[i,j]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
