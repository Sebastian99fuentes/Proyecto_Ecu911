using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecu911.Modelos
{
    public partial class FechaReasignacionIda
    {
        [Key]
        public string? IdIda { get; set; }

        [Required]
        [ForeignKey("ProcesoId")]
        public string ProcesoId { get; set; }
        public ProcesoCompra? Proceso {get; set;}

        [Required]
        [ForeignKey("AreaId")]
        public string AreaId { get; set; }
        public Unidad? Area { get; set; }

        [Required]
        public DateTime? fechaIda { get; set; }
    }

}
