using System;

namespace Laboratorio81
{
    public class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string NIF { get; set; }

        public Persona(string nombre, int edad, string nif)
        {
            Nombre = nombre;
            Edad = edad;
            NIF = nif;
        }

        public void MostrarDatos()
        {
            Console.WriteLine($"Nombre: {Nombre}, Edad: {Edad}, NIF: {NIF}");
        }
    }
}
