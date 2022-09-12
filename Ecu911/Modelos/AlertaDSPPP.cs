using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecu911.Modelos
{
    public partial class AlertaDSPPP
    {
        [Key]
        [Required]
        public Guid AlertaDSPPPId { get; set; }

        [ForeignKey("ProcesoCompraId")]
        [Required]
        public Guid ProcesoCompraId { get; set; }
        public ProcesoCompra ProcesoCompra { get; set; }

        [Required]
        public string descripcionAlerta { get; set; }

    }
}
