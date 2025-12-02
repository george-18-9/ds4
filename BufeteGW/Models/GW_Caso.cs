using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BufeteGW.Models
{
    public class GW_Caso
    {
        [Key]
        public int CasoId { get; set; }

        public string NumeroExpediente { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Estado { get; set; } = string.Empty;

        [ForeignKey("Abogado")]
        public int AbogadoId { get; set; }
        public GW_Abogado Abogado { get; set; } = new GW_Abogado();

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public GW_Cliente Cliente { get; set; } = new GW_Cliente();

        public List<GW_Documento> Documentos { get; set; } = new();
        public List<GW_Evento> Eventos { get; set; } = new();
    }
}
