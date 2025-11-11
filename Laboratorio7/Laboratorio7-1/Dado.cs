using System;

namespace Laboratorio72
{
    public class Dado
    {
        private int valor;
        private static Random random = new Random();

        public void Tirar()
        {
            valor = random.Next(1, 7); // valores entre 1 y 6
        }

        public void Imprimir()
        {
            Console.WriteLine($"El valor del dado es: {valor}");
        }

        public int RetornarValor()
        {
            return valor;
        }
    }
}
