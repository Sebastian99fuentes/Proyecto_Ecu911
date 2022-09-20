using System.ComponentModel.DataAnnotations;

namespace Ecu911.Modelos
{
    public partial class Estado
    {
        [Key]
        public string? EstadoId { get; set; }

        [Required]
        public string tipoEstado { get; set; }

        public ICollection<ProcesoCompra>? ProcesoCompras { get; set; }
    }
}
