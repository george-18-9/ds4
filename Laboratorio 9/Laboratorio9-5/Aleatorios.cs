using System;
using System.Collections.Generic;

namespace Laboratorio95
{
    public class Aleatorios
    {
        private Random random = new Random();

        public int GenerarNumero(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        // Generar arreglo de números no repetidos
        public int[] GenerarArregloNoRepetido(int cantidad, int min, int max)
        {
            HashSet<int> numeros = new HashSet<int>();
            while (numeros.Count < cantidad)
            {
                int num = random.Next(min, max + 1);
                numeros.Add(num);
            }
            int[] resultado = new int[numeros.Count];
            numeros.CopyTo(resultado);
            return resultado;
        }
    }
}

