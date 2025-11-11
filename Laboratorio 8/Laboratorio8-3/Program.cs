using System;

namespace Laboratorio83
{
    class Program
    {
        static int Suma(int a, int b)
        {
            return a + b;
        }

        static double Suma(double a, double b)
        {
            return a + b;
        }

        static string Suma(string a, string b)
        {
            return a + " " + b;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Suma(5, 7));
            Console.WriteLine(Suma(3.2, 4.8));
            Console.WriteLine(Suma("Hola", "Mundo"));
            Console.ReadKey();
        }
    }
}

