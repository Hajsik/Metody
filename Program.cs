using System;
using System.Collections.Generic;
using System.Linq;

namespace NumericalMethods
{
    class Program
    {
        public class Input
        {
            public List<double> Xs { get; set; } = new List<double>();
            public List<double> Ys { get; set; } = new List<double>();
        }
		
        public static List<double> Interpolation(Input input)
        {
            var n = input.Xs.Count;
            
            var matrix = new List<List<double>>();

            for (int i = 0; i < n; i++)
            {
                matrix.Add(new List<double>());

                for (int j = 0; j < n; j++)
                {
                    var power = n - (j + 1);
                    var value = Math.Pow(input.Xs[i], power);
                    matrix.Last().Add(value);
                }

                matrix.Last().Add(input.Ys[i]);
            }

           return Algos.GaussElimination(matrix);
        }


        static void Main()
        {
            // Interpolacja:
            // http://www.algorytm.org/procedury-numeryczne/interpolacja-wielomianowa.html

            // Gauss:
            // https://eduinf.waw.pl/inf/alg/001_search/0076.php

            var args = new Input
            {
                Xs = new List<double> {2, 3, 6, 7, 8, 10},
                Ys = new List<double> {0, 2, 3, 5, 1, 2},
            };

            var output = Interpolation(args);

            var amount_of_solution = args.Xs.Count() - 1;

            for (int i = amount_of_solution; i >= 0; i--)
            {
                string double_position_after_comma = string.Format("{0:0.00}", output[amount_of_solution - i]);
                Console.Write($"{double_position_after_comma}x^{i} + ");
            }

			Console.ReadKey();
        }
    }
}
