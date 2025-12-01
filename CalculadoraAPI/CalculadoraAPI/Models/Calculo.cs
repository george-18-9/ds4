using System;

namespace CalculadoraAPI.Models
{
    public class Calculo
    {
        public int Id { get; set; }
        public string Operacion { get; set; } = string.Empty;
        public double Valor1 { get; set; }
        public double Valor2 { get; set; }
        public double Resultado { get; set; }
        public DateTime? Fecha { get; set; }

    }
}