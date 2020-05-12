using System;
using System.Collections.Generic;
using System.Text;

namespace GaussJacob
{
    class Program
    {
        static int N = 3;
        static double erro = 3;
        static double[] B = new double[30];
        static double[] G = new double[30];
        static double[] X0 = new double[30];
        static double[] XNovo = new double[30];
        static double[] XAux = new double[30];
        static double[,] MatOrigin = new double[30, 30];
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
            Console.Write("Digite a ordem do sistema: " + N + "\n\n");

            Console.Write("Digite o Erro: ");
            erro = double.Parse(Console.ReadLine());
            Console.Write("\n\n");

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"[{i + 1},{j + 1}]: ");
                    MatOrigin[i, j] = float.Parse(Console.ReadLine());
                }
                Console.Write($"Termo Independente {i + 1}: ");
                B[i] = float.Parse(Console.ReadLine());
                Console.WriteLine();
            }
        }
        
        public static void XInicial()
        {
            Console.WriteLine("Digite o X inicial: ");
            for (int i = 0; i < N; i++)
            {
                Console.Write($"X{i + 1}: ");
                X0[i] = float.Parse(Console.ReadLine());
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
                    if ((i == 0) && (j == 1))
                    {
                        MatC[i, j] = -MatOrigin[i, j] / MatOrigin[i, j - 1];
                    }
                    else if ((i == 0) && (j == 2))
                    {
                        MatC[i, j] = -MatOrigin[i, j] / MatOrigin[i, j - 2];
                    }
                    else if ((i == 1) && (j == 0))
                    {
                        MatC[i, j] = -MatOrigin[i, j] / MatOrigin[i, j + 1];
                    }
                    else if ((i == 1) && (j == 2))
                    {
                        MatC[i, j] = -MatOrigin[i, j] / MatOrigin[i, j - 1];
                    }
                    else if ((i == 2) && (j == 0))
                    {
                        MatC[i, j] = -MatOrigin[i, j] / MatOrigin[i, j + 2];
                    }
                    else if ((i == 2) && (j == 1))
                    {
                        MatC[i, j] = -MatOrigin[i, j] / MatOrigin[i, j + 1];
                    }
                }
            }
        }
        
        public static void CalculaErro()
        {
            double erroAtual = 100;
            double[] erroRelativo = new double[3];
            double[] erroAbs = new double[3];
            int count = 0;

            while (erroAtual > erro)
            {
                XAux[0] = X0[0];
                XAux[1] = X0[1];
                XAux[2] = X0[2];

                XNovo[0] = (MatC[0, 0] * X0[0] + MatC[0, 1] * X0[1] + MatC[0, 2] * X0[2]) + G[0];
                XNovo[1] = (MatC[1, 0] * X0[0] + MatC[1, 1] * X0[1] + MatC[1, 2] * X0[2]) + G[1];
                XNovo[2] = (MatC[2, 0] * X0[0] + MatC[2, 1] * X0[1] + MatC[2, 2] * X0[2]) + G[2];

                X0[0] = XNovo[0];
                X0[1] = XNovo[1];
                X0[2] = XNovo[2];

                count++;
                Console.WriteLine("\n\n");
                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine($" Novo X{i+1}({count}): " + XNovo[i]);
                }

                erroRelativo[0] = XNovo[0] - XAux[0];
                erroRelativo[1] = XNovo[1] - XAux[1];
                erroRelativo[2] = XNovo[2] - XAux[2];

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
                var maiorErroRelativo = erroRelativo[2];

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
                var maiorErroAbs = XNovo[2];

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
                    Console.Write("\t[" + MatC[i, j] + "]");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n\n\tG: ");
            for (int i = 0; i < N; i++)
            {
                Console.Write("\n\t[" + G[i] + "]");
            }
        }
    }
}
