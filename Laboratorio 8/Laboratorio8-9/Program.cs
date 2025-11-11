using System;

namespace Laboratorio89
{
    public interface IFigura
    {
        double CalcularArea();
    }

    public class Circulo : IFigura
    {
        public double Radio { get; set; }

        public Circulo(double radio)
        {
            Radio = radio;
        }

        public double CalcularArea()
        {
            return Math.PI * Radio * Radio;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IFigura figura = new Circulo(4.5);
            Console.WriteLine($"Área del círculo: {figura.CalcularArea():F2}");
            Console.ReadKey();
        }
    }
}
