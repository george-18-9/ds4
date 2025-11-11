using System;

namespace Laboratorio85
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona p = new Persona { Nombre = "Luis", Edad = 22 };
            p.Mostrar();
            Console.ReadKey();
        }
    }
}

