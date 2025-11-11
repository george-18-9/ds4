using Laboratorio94;

class Program
{
    static void Main(string[] args)
    {
        Aleatorios a = new Aleatorios();

        Console.WriteLine("Número aleatorio entre 1 y 10: " + a.GenerarNumero(1, 10));

        Console.WriteLine("Arreglo aleatorio:");
        int[] arr = a.GenerarArreglo(5, 1, 10);
        foreach (int n in arr)
            Console.Write(n + " ");

        Console.ReadKey();
    }
}