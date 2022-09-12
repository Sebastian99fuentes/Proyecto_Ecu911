using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecu911.Modelos
{
    public class Observacion
    {
        [Key]
        [Required]
        public Guid ObservacionId { get; set; }

        [Required]
        [ForeignKey("ProcesoId")]
        public Guid ProcesoId { get; set; }
        public ProcesoCompra ProcesoCompra { get; set; }


        [Required]
        public DateOnly fechaObsservacion { get; set; }

        [Required]
        public string descripcionObservacion { get; set; }
    }
}
