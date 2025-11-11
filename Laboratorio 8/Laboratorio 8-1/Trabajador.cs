using System;

namespace Laboratorio81
{
    public class Trabajador : Persona
    {
        public int Sueldo { get; set; }

        public Trabajador(string nombre, int edad, string nif, int sueldo)
            : base(nombre, edad, nif)
        {
            Sueldo = sueldo;
        }

        public void MostrarSueldo()
        {
            Console.WriteLine($"Sueldo: {Sueldo:C}");
        }
    }
}
