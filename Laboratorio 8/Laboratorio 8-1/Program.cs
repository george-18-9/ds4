using System;

namespace Laboratorio81
{
    class Program
    {
        static void Main(string[] args)
        {
            Trabajador t = new Trabajador("Juan Pérez", 30, "12345678A", 2500);
            t.MostrarDatos();
            t.MostrarSueldo();

            Console.ReadKey();
        }
    }
}
