using System.ComponentModel.DataAnnotations;

namespace BufeteGW.Models
{
    public class GW_Abogado
    {
        [Key] // <-- ESTA LÍNEA es la clave
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
    }
}

