using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecu911.Modelos
{
    public partial class AlertaDSPPP
    {
        [Key]
        public string? AlertaDSPPPId { get; set; }

        [Required]
        [ForeignKey("ProcesoCompraId")]
        public string ProcesoCompraId { get; set; }
        public ProcesoCompra? ProcesoCompra { get; set; }

        [Required]
        public string descripcionAlerta { get; set; }

    }
}
