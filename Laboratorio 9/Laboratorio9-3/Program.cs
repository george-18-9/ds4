using System;

namespace Laboratorio93
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;

            Console.Write("Ingrese lado A: ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Ingrese lado B: ");
            b = double.Parse(Console.ReadLine());
            Console.Write("Ingrese lado C: ");
            c = double.Parse(Console.ReadLine());

            if (a + b > c && a + c > b && b + c > a)
            {
                if (a == b && b == c)
                    Console.WriteLine("Triángulo equilátero");
                else if (a == b || a == c || b == c)
                    Console.WriteLine("Triángulo isósceles");
                else
                    Console.WriteLine("Triángulo escaleno");
            }
            else
            {
                Console.WriteLine("Los lados no forman un triángulo válido.");
            }

            Console.ReadKey();
        }
    }
}
