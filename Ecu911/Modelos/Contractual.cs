using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Ecu911.Modelos
{
    public partial class Contractual
    {
        [Key]
        public string? ContractualId { get; set; }

        [ForeignKey("IdPrecontractual")]
        public string? IdPrecontractual { get; set; }
        public Precontractual? Precontractual { get; set; }

        [Display(Name = "Fecha de suscripción")]
        [DataType(DataType.Date)]
        public DateTime? fechaSuscripcion { get; set; }

        [Display(Name = "Fecha de finalización")]
        [DataType(DataType.Date)]
        public DateTime? fechaFinalizacion { get; set; }

        [Required]
        public string rucOferente { get; set; }

        [Required]
        [StringLength(40)]
        public string nombreProveedor { get; set; }

        [Required]
        public string plazoContrato { get; set; }
    }
}
