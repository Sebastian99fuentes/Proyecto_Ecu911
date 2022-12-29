using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecu911.Modelos
{
    public partial class Unidad
    {
        [Key]
        public string? UnidadId { get; set; }

        [Required]
        public string nombre { get; set; }


        public ICollection<ProcesoCompra>? ProcesoCompras { get; set; }

        public ICollection<User>? Usuarios { get; set; }
    }
}
