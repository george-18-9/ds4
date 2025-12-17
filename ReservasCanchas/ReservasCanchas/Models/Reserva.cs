using System;

namespace ReservasCanchas.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int CanchaId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }

        // Hora de entrada y salida
        public TimeSpan HoraInicio { get; set; } 
        public TimeSpan HoraFin { get; set; } 
    }
}

