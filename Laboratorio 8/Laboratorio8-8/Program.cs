using System;

namespace Laboratorio88
{
    public abstract class Figura
    {
        public abstract double CalcularArea();
    }

    public class Cuadrado : Figura
    {
        public double Lado { get; set; }

        public Cuadrado(double lado)
        {
            Lado = lado;
        }

        public override double CalcularArea()
        {
            return Lado * Lado;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Figura f = new Cuadrado(5);
            Console.WriteLine($"Área del cuadrado: {f.CalcularArea()}");
            Console.ReadKey();
        }
    }
}
