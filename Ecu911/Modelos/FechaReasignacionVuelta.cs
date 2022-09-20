using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecu911.Modelos
{
    public partial class FechaReasignacionVuelta
    {
        [Key]
        public string? IdVuelta { get; set; }

        [Required]
        [ForeignKey("ProcesoId")]
        public string ProcesoId { get; set; }
        public ProcesoCompra? Proceso { get; set; }

        [Required]
        [ForeignKey("AreaId")]
        public string AreaId { get; set; }
        public PlantaUnidadArea? Area { get; set; }

        [Required]
        public DateTime fechaVuelta { get; set; }
    }
}
