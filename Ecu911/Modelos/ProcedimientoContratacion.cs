using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecu911.Modelos
{
    public partial class ProcedimientoContratacion
    {
        [Key]
        public string? ProcedimientoContratacionId { get; set; }


        [ForeignKey("ProcedimientoId")]
        public ICollection<ProcesoCompra>? ProcesoCompra { get; set; }

        [Required]
        [StringLength(20)]
        public string tipoProcedimiento { get; set; }
    }
}
