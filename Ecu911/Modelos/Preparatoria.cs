using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Ecu911.Modelos
{
    public partial class Preparatoria
    {
        [Key]
        [Required]
        public Guid PreparatoriaId { get; set; }


        [ForeignKey("IdProcesoCompra")]
        public Guid? IdProcesoCompra { get; set; }
        public ProcesoCompra? ProcesoCompra { get; set; }

        [ForeignKey("IdPreparatoria")]
        public ICollection<Precontractual> Precontractuales { get; set; }

        [Display(Name = "Fecha programada de revisión")]
        [DataType(DataType.Date)]
        public DateOnly fechaProgramada { get; set; }

        [Display(Name = "Fecha de solicitud de revisión")]
        [DataType(DataType.Date)]
        public DateOnly fechaSolicitud { get; set; }

        [Display(Name = "Fecha de respuesta efectiva")]
        [DataType(DataType.Date)]
        public DateOnly fechaRespuesta { get; set; }

        [Display(Name = "Fecha de mesa consultiva")]
        [DataType(DataType.Date)]
        public DateOnly fechaMesa { get; set; }

        [Display(Name = "Fecha de emisión")]
        [DataType(DataType.Date)]
        public DateOnly fechaEmision { get; set; }

        [Display(Name = "Valor Certificado")]
        [DataType(DataType.Date)]
        public decimal valorCertificado { get; set; }

        [Display(Name = "Fecha real de solicitud")]
        [DataType(DataType.Date)]
        public DateOnly fechaReal { get; set; }

        [Display(Name = "Fecha de autorización")]
        [DataType(DataType.Date)]
        public DateTime fechaAutorizacion { get; set; }

        [Display(Name = "Fecha de publicación")]
        [DataType(DataType.Date)]
        public DateOnly fechaPublicacion { get; set; }

    }

}
