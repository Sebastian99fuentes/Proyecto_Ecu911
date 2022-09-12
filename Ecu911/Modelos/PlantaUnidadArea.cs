using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecu911.Modelos
{
    public partial class PlantaUnidadArea
    {
        [Key]
        [Required]
        public Guid PlantaUnidadAreaId { get; set; }

        [ForeignKey("PadreId")]
        public Guid PadreId { get; set; }
        public PlantaUnidadArea Padre { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public char tipo { get; set; }


        public ICollection<PlantaUnidadArea> PlantaUnidadAreas { get; set; }

        public ICollection<ProcesoCompra> ProcesoCompras { get; set; }

        public ICollection<User> Usuarios { get; set; }
    }
}
