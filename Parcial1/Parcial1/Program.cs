using System;

int ReadInt(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out int v)) return v;
        Console.WriteLine("Entrada inválida. Intenta de nuevo.");
    }
}

int N;
while (true)
{
    N = ReadInt("Introduce N (par y >= 4): ");
    if (N >= 4 && N % 2 == 0) break;
    Console.WriteLine("N debe ser un número par y mayor o igual a 4.");
}

int[,] matriz = new int[N, N];

// Primera fila 1..N y última fila N..1, resto 0
for (int j = 0; j < N; j++)
{
    matriz[0, j] = j + 1;
    matriz[N - 1, j] = N - j;
}

// Mostrar matriz
Console.WriteLine();
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        Console.Write(matriz[i, j].ToString().PadLeft(4));
    }
    Console.WriteLine();
}