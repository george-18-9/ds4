using System;

namespace EjemploLectura
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese un número: ");
            string texto = Console.ReadLine();  // Lee lo que escriba el usuario
            int numero = Convert.ToInt32(texto); // Convierte el texto a entero

            Console.WriteLine("El número ingresado es: " + numero);
        }
    }
}

