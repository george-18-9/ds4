using System;

namespace Laboratorio91
{
    class Program
    {
        static void Main(string[] args)
        {
            double precio;
            string formaPago;

            do
            {
                Console.Write("Ingrese el precio del producto (positivo): ");
            } while (!double.TryParse(Console.ReadLine(), out precio) || precio <= 0);

            Console.Write("Forma de pago (efectivo/tarjeta): ");
            formaPago = Console.ReadLine().Trim().ToLower();

            if (formaPago == "tarjeta")
            {
                string cuenta;
                do
                {
                    Console.Write("Ingrese el número de cuenta (16 dígitos): ");
                    cuenta = Console.ReadLine();
                } while (cuenta.Length != 16 || !ulong.TryParse(cuenta, out _));

                Console.WriteLine($"Pago de {precio:C} realizado con tarjeta número: {cuenta}");
            }
            else if (formaPago == "efectivo")
            {
                Console.WriteLine($"Pago de {precio:C} realizado en efectivo.");
            }
            else
            {
                Console.WriteLine("Forma de pago no válida.");
            }

            Console.ReadKey();
        }
    }
}

