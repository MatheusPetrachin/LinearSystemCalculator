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
                delta = delta * -1;
                b = b / 2 * a;
                delta = Math.Sqrt(delta) / 2 * a;

                Console.WriteLine($"{b} + {delta}.i");
                Console.WriteLine($"{b} - {delta}.i");
            }
            else
            {
                x[0] = (-b + Math.Sqrt(delta)) / 2 * a;
                x[1] = (-b - Math.Sqrt(delta)) / 2 * a;
            
                Console.WriteLine($"X1: {x[0]}");
                Console.WriteLine($"X1: {x[0]}");
            }

            return delta;
        }
    }
}
