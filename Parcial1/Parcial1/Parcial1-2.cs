using System;
using System.Numerics;

namespace Parcial1
{
    internal static class Parcial1_2
    {
        // Ejecuta interacción por consola: pide N y muestra términos y sumatorias.
        public static void EjecutarInteractivo()
        {
            int N = ReadInt("Introduce N (entero >= 1): ", min: 1);
            MostrarHasta(N);
        }

        // Muestra los términos a_n y las sumas parciales S_n para n = 1..N.
        public static void MostrarHasta(int N)
        {
            BigInteger sumaParcial = 0;

            Console.WriteLine();
            Console.WriteLine("Sucesión: a_n = (-1)^(n-1) * 2^n");
            Console.WriteLine();

            for (int n = 1; n <= N; n++)
            {
                BigInteger potencia = BigInteger.Pow(2, n);               // 2^n
                int signo = (n % 2 == 1) ? 1 : -1;                        // (-1)^(n-1)
                BigInteger termino = signo * potencia;                    // a_n
                BigInteger sumaAnterior = sumaParcial;
                sumaParcial += termino;                                   // S_n

                // Línea explicativa por iteración
                Console.WriteLine(
                    $"n={n}: a{n} = (-1)^{n - 1} * 2^{n} = {signo} * {potencia} = {termino}; " +
                    $"S{n} = S{n - 1} + a{n} = {sumaAnterior} + {termino} = {sumaParcial}"
                );
            }

            Console.WriteLine();
            Console.WriteLine($"Resultado final S{N} = {sumaParcial}");
            Console.WriteLine();
        }

        // Lectura segura de enteros desde consola con validación mínima.
        private static int ReadInt(string prompt, int min = int.MinValue)
        {
            while (true)
            {
                Console.Write(prompt);
                string? line = Console.ReadLine();
                if (int.TryParse(line, out int v) && v >= min) return v;
                Console.WriteLine($"Entrada inválida. Introduce un entero >= {min}.");
            }
        }
    }
}
