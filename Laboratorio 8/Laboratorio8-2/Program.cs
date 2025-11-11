using System;

namespace Laboratorio82
{
    public class Cuenta
    {
        protected double saldo;

        public Cuenta(double saldo)
        {
            this.saldo = saldo;
        }

        public virtual void CalcularIntereses()
        {
            saldo += saldo * 0.03;
        }

        public void MostrarSaldo()
        {
            Console.WriteLine($"Saldo actual: {saldo:C}");
        }
    }

    public class CuentaAhorro : Cuenta
    {
        public CuentaAhorro(double saldo) : base(saldo) { }

        public override void CalcularIntereses()
        {
            saldo += saldo * 0.05;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Cuenta cuenta1 = new Cuenta(1000);
            Cuenta cuenta2 = new CuentaAhorro(1000);

            cuenta1.CalcularIntereses();
            cuenta2.CalcularIntereses();

            cuenta1.MostrarSaldo();
            cuenta2.MostrarSaldo();

            Console.ReadKey();
        }
    }
}
