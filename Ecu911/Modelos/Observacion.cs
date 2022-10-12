using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ecu911.Servicios;
using System.Text.Json.Serialization;

namespace Ecu911.Modelos
{
    public class Observacion
    {
        [Key]
        public string? ObservacionId { get; set; }

        [Required]
        [ForeignKey("ProcesoId")]
        public string ProcesoId { get; set; }
        public ProcesoCompra? Proceso { get; set; }

        
        [Required]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateTime? fechaObsservacion { get; set; }

        [Required]
        public string descripcionObservacion { get; set; }
    }
}
