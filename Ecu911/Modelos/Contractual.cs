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

        [DataType(DataType.Date)]
        public DateTime? fechaSuscripcion { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fechaSuscripcionReal { get; set; }

        [DataType(DataType.Date)]
        public DateTime? fechaFinalizacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fechaFinalizacionReal { get; set; }
    }
}

