using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BufeteGW.Models
{
    public class GW_Evento
    {
        [Key]
        public int Id { get; set; }

        public string TipoEvento { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaEvento { get; set; }

        [ForeignKey("Caso")]
        public int CasoId { get; set; }
        public GW_Caso Caso { get; set; } = new GW_Caso();
    }
}

