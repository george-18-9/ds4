using System;

namespace Laboratorio31
{
    class CalculosMatematicos
    {
        public static int Calcular(int a, int b)
        {
            return (a + b) * (a - b);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese el primer número: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el segundo número: ");
            int b = Convert.ToInt32(Console.ReadLine());

            int resultado = CalculosMatematicos.Calcular(a, b);
            Console.WriteLine($"El resultado de (a+b)*(a-b) es: {resultado}");
        }
    }
}

