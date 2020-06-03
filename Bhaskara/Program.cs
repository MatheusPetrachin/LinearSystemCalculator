using System;
using System.Collections.Generic;
using System.Text;

namespace Bhaskara
{
    class Program
    {
        public static double delta;
        public static double[] x = new double[2];
        public static double[] vet = new double[3];
        public static char n = 'A';
        public static bool imaginarious = false;

        static void Main(string[] args)
        {
            CapturaValores();
            CalculaBhaskara(vet[0], vet[1], vet[2]);
            Console.ReadLine();
        }

        public static void CapturaValores()
        {
            Console.WriteLine("\nBhakara Calculator\n\nDigite os valores A,B e C de uma função do segundo Grau: ");
            for (int i = 0; i < vet.Length; i++)
            {
                Console.Write($"Digite {n}: ", n++);
                vet[i] = double.Parse(Console.ReadLine());
            }
        }

        public static double CalculaBhaskara(double a, double b, double c)
        {
            delta = (b * b - (4 * a * c));

            if (delta < 0)
            {
                Console.WriteLine($"\n\nZeros da Equação (com delta negativo): {delta}\n\n");

                delta = delta * -1;
                b = (-1*b) / (2 * a);
                delta = Math.Sqrt(delta) / (2 * a);

                Console.WriteLine($"{b} + {delta}.i");
                Console.WriteLine($"{b} - {delta}.i");
            }
            else
            {

                Console.WriteLine($"\n\nZeros da Equação: \n\n");
                x[0] = (-b + Math.Sqrt(delta)) / 2 * a;
                x[1] = (-b - Math.Sqrt(delta)) / 2 * a;
            
                Console.WriteLine($"X1: {x[0]}");
                Console.WriteLine($"X1: {x[0]}");
            }

            return delta;
        }
    }
}
