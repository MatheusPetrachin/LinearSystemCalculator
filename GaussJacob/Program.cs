using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GaussJacob
{
    class Program
    {
        static int N = 0;
        static double erro = 0;
        static double[] B = new double[30];
        static double[] G = new double[30];
        static double[] X0 = new double[30];
        static double[] XNovo = new double[30];
        static double[] XAux = new double[30];
        static double[,] MatOrigin = new double[30, 30];
        static double[] Horizontal = new double[30];
        static double[,] MatC = new double[30, 30];

        static void Main(string[] args)
        {
            LeMatriz();
            XInicial();
            Show();
            Console.ReadLine();
            ZeraDiagonal();
            CalculaC();
            ShowMatrizC();
            Console.ReadLine();
            CalculaErro();
            Console.ReadLine();
        }

        public static void LeMatriz()
        {
            Console.Write("Digite a ordem do sistema: ");
            N = Int32.Parse(Console.ReadLine());

            Console.Write("Digite o Erro: ");
            erro = double.Parse(Console.ReadLine());
            Console.Write("\n\n");

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"[{i + 1},{j + 1}]: ");
                    MatOrigin[i, j] = double.Parse(Console.ReadLine());
                }
                Console.Write($"Termo Independente {i + 1}: ");
                B[i] = double.Parse(Console.ReadLine());
                Console.WriteLine();
            }
        }
        
        public static void XInicial()
        {
            Console.WriteLine("Digite o X inicial: ");
            for (int i = 0; i < N; i++)
            {
                Console.Write($"X{i + 1}: ");
                X0[i] = double.Parse(Console.ReadLine());
            }
        }

        public static void ZeraDiagonal()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i == j)
                    {
                        Horizontal[i] = MatOrigin[i, j];
                        G[i] = B[i] / MatOrigin[i, j];
                        MatC[i, j] = MatOrigin[i, j] - MatOrigin[i, j];
                    }
                }
            }
        }

        public static void CalculaC()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i != j)
                    {
                        MatC[i, j] = -MatOrigin[i, j] / Horizontal[i];
                    }
                }
            }
        }
        
        public static void CalculaErro()
        {
            double erroAtual = 100;
            double[] erroRelativo = new double[30];
            double[] erroAbs = new double[30];
            int count = 0;

            while (erroAtual > erro)
            {
                for (int i=0; i<N; i++)
                {
                    XAux[i] = X0[i];
                }

                for(int i=0; i < N; i++)
                {
                    XNovo[i] = 0;
                }
                for(int i=0; i<N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        XNovo[i] += MatC[i, j] * X0[j];
                    }
                    XNovo[i] += G[i];
                }

                for(int i=0; i<N; i++)
                {
                    X0[i] = XNovo[i];
                }

                count++;
                Console.WriteLine("\n\n");
                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine($" Novo X{i+1}({count}): " + XNovo[i]);
                }

                for (int i = 0; i < N; i++)
                {
                    erroRelativo[i] = XNovo[i] - XAux[i];
                    if(erroRelativo[i] < 0)
                    {
                        erroRelativo[i] = erroRelativo[i] * -1;
                    }
                }

                var aux = 0.0;

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (erroRelativo[i] < erroRelativo[j])
                        {
                            //aqui acontece a troca, do maior cara  vaia para a direita e o menor para a esquerda
                            aux = erroRelativo[i];
                            erroRelativo[i] = erroRelativo[j];
                            erroRelativo[j] = aux;
                        }
                    }
                }

                var maiorErroRelativo = erroRelativo[N-1];

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (XNovo[i] < XNovo[j])
                        {
                            //aqui acontece a troca, do maior cara  vaia para a direita e o menor para a esquerda
                            aux = XNovo[i];
                            XNovo[i] = XNovo[j];
                            XNovo[j] = aux;
                        }
                    }
                }
                var maiorErroAbs = XNovo[N-1];

                erroAtual = maiorErroRelativo / maiorErroAbs;

                Console.WriteLine(" Maior Erro Relativo: " + maiorErroRelativo);
                Console.WriteLine(" Maior Erro Absoluto: " + maiorErroAbs);
                Console.WriteLine(" Erro Atual: " + erroAtual);
                               
            }
        }

        public static void Show()
        {
            Console.WriteLine("\n\n\tMatriz: \n");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write("\t[" + MatOrigin[i, j] + "]");
                }
                Console.Write("\t= [" + B[i] + "]");
                Console.WriteLine();
            }
        }

        public static void ShowMatrizC()
        {
            Console.WriteLine("\tC: \n");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"\t[{MatC[i, j].ToString("N3")}]\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n\n\tG: ");
            for (int i = 0; i < N; i++)
            {
                Console.Write("\n\t[" + G[i].ToString("N3") + "]");
            }
        }
    }
}
