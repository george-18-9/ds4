using System;

namespace Laboratorio86
{
    public class Base
    {
        public virtual void Mostrar()
        {
            Console.WriteLine("Método de la clase base");
        }
    }

    public class Derivada : Base
    {
        public sealed override void Mostrar()
        {
            Console.WriteLine("Método final - no puede sobrescribirse");
        }
    }

    // Si se intenta heredar de Derivada y sobrescribir Mostrar, dará error.
    class Program
    {
        static void Main(string[] args)
        {
            Derivada d = new Derivada();
            d.Mostrar();
            Console.ReadKey();
        }
    }
}
