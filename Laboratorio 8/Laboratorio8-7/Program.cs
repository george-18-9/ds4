using System;

namespace Laboratorio87
{
    public sealed class ClaseFinal
    {
        public void Mostrar()
        {
            Console.WriteLine("Esta clase no puede heredarse");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ClaseFinal c = new ClaseFinal();
            c.Mostrar();
            Console.ReadKey();
        }
    }
}
