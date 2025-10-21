using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        Console.Write("Introduce N (entero positivo): ");
        if (!int.TryParse(Console.ReadLine(), out int N) || N < 1)
        {
            Console.WriteLine("Entrada inválida. Introduce un entero positivo mayor o igual a 1.");
            return;
        }

        BigInteger suma = BigInteger.Zero;

        for (int i = 1; i <= N; i++)
        {
            int signo = (i % 2 == 1) ? 1 : -1;                 // (-1)^{i-1}
            BigInteger potencia = BigInteger.One << i;         // 2^i usando desplazamiento
            BigInteger termino = signo * potencia;             // a_i

            Console.WriteLine($"Iteración {i}: a_{i} = (-1)^({i}-1) * 2^{i} = {signo} * {potencia} = {termino}");
            BigInteger anterior = suma;
            suma += termino;
            Console.WriteLine($"  Sumatoria: {anterior} + ({termino}) = {suma}");
        }

        Console.WriteLine($"\nResultado final: suma de los {N} términos = {suma}");
    }
}