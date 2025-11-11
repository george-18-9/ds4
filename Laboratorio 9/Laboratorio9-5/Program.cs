using System;
using Laboratorio95;

namespace Laboratorio95
{
    class Program
    {
        static void Main(string[] args)
        {
            Aleatorios a = new Aleatorios();

            int min = a.GenerarNumero(1, 10);
            int max = a.GenerarNumero(20, 50);

            if (min > max)
            {
                int temp = min;
                min = max;
                max = temp;
            }

            Console.WriteLine($"Generando números únicos entre {min} y {max}:");

            int cantidad = 10;
            int[] arreglo = a.GenerarArregloNoRepetido(cantidad, min, max);

            foreach (int n in arreglo)
                Console.Write(n + " ");

            Console.ReadKey();
        }
    }
}
