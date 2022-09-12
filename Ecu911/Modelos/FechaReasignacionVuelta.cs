using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecu911.Modelos
{
    public partial class FechaReasignacionVuelta
    {
        [Key]
        [Required]
        public Guid IdVuelta { get; set; }

        [Required]
        [ForeignKey("ProcesoId")]
        public Guid ProcesoId { get; set; }
        public ProcesoCompra ProcesoCompra { get; set; } 

        [Required]
        [ForeignKey("AreaId")]
        public Guid AreaId { get; set; }
        public PlantaUnidadArea Area { get; set; } 

        [Required]
        public DateTime fechaVuelta { get; set; }
    }
}
