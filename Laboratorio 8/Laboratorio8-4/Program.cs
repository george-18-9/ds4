using System;

namespace Laboratorio84
{
    public class Persona
    {
        private string nombre;
        private int edad;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Edad
        {
            get { return edad; }
            set
            {
                if (value > 0)
                    edad = value;
            }
        }

        public void Mostrar()
        {
            Console.WriteLine($"Nombre: {nombre}, Edad: {edad}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Persona p = new Persona();
            p.Nombre = "Ana";
            p.Edad = 25;
            p.Mostrar();
            Console.ReadKey();
        }
    }
}

