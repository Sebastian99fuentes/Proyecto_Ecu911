using System.ComponentModel.DataAnnotations;

namespace Ecu911.Modelos
{
    public partial class Etapa
    {
        [Key]
        [Required]
        public Guid EtapaId { get; set; }

        [Required]
        [MaxLength(40)]
        public string tipoEtapa { get; set; } = "";

        public ICollection<ProcesoCompra> ProcesoCompras { get; set; }
    }
}
