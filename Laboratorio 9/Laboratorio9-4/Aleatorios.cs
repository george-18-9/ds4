using System;

namespace Laboratorio94
{
    public class Aleatorios
    {
        private Random random = new Random();

        // Generar un número entre dos valores
        public int GenerarNumero(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        // Generar un arreglo con números aleatorios
        public int[] GenerarArreglo(int cantidad, int min, int max)
        {
            int[] arreglo = new int[cantidad];
            for (int i = 0; i < cantidad; i++)
            {
                arreglo[i] = random.Next(min, max + 1);
            }
            return arreglo;
        }
    }
}