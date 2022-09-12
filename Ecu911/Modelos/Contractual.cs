using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Ecu911.Modelos
{
    public partial class Contractual
    {
        [Key]
        [Required]
        public Guid ContractualId { get; set; }

        [ForeignKey("IdPrecontractual")]
        public Guid? IdPrecontractual { get; set; }
        public Precontractual? Precontractual { get; set; }

        [Display(Name = "Fecha de suscripción")]
        [DataType(DataType.Date)]
        public DateOnly fechaSuscripcion { get; set; }

        [Display(Name = "Fecha de finalización")]
        [DataType(DataType.Date)]
        public DateOnly fechaFinalizacion { get; set; }

        [Required]
        public int rucOferente { get; set; }

        [Required]
        [StringLength(40)]
        public string nombreProveedor { get; set; }


    }
}
