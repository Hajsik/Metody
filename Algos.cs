using System;
using System.Collections.Generic;
using System.Linq;

namespace NumericalMethods
{
    public class Algos
    {
        public static double eps = 0.0001;
		
        public static List<double> GaussElimination(List<List<double>> input)
        {
            var n = input.Count();

            // Print(input);

            var AB = FirstStep(input, n);

            // Print(input);

            var Xs = SecondStep(AB, n);

            // Print(input);

            return Xs;
        }

        private static List<double> SecondStep(List<List<double>> AB, int n)
        {
            var X = new List<double>(new double[n]);
            for (int i = n - 1; i >= 0; i--)
            {
                double s = AB[i][n];
                for (int j = n - 1; j >= i + 1; j--)
                {
                    s -= AB[i][j] * X[j];
                }
                if (Math.Abs(AB[i][i]) < eps)
                {

                }
                X[i] = s / AB[i][i];
            }
            return X;
        }

        private static List<List<double>> FirstStep(List<List<double>> AB, int n)
        {
            double m = 1;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (Math.Abs(AB[i][i]) < eps)
                    {
                        new List<List<double>>();
                    }

                    m = -AB[j][i] / AB[i][i];

                    for (int k = i + 1; k <= n; k++)
                    {
                        AB[j][k] += m * AB[i][k];
                    }
                }
            }

            return AB;
        }

        public static void Print(List<List<double>> input)
        {
            foreach (var row in input)
            {
                foreach (var el in row)
                {
                    Console.Write($"{el} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}