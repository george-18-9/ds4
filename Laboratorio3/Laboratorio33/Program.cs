using System;

namespace Laboratorio33
{
    class CalculosMatematicos
    {
        public static double CalculoPerimetro(double lado1, double lado2)
        {
            return 2 * (lado1 + lado2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese el valor del primer lado: ");
            double lado1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese el valor del segundo lado: ");
            double lado2 = Convert.ToDouble(Console.ReadLine());

            double perimetro = CalculosMatematicos.CalculoPerimetro(lado1, lado2);
            Console.WriteLine($"El perímetro del rectángulo es: {perimetro}");
        }
    }
}
