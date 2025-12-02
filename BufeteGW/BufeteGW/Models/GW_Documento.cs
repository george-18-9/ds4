using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BufeteGW.Models
{
    public class GW_Documento
    {
        [Key]
        public int Id { get; set; }

        public string NombreArchivo { get; set; } = string.Empty;
        public string RutaArchivo { get; set; } = string.Empty;
        public string TipoDocumento { get; set; } = string.Empty;

        [ForeignKey("Caso")]
        public int CasoId { get; set; }
        public GW_Caso Caso { get; set; } = new GW_Caso();
    }
}
