using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Ecu911.Modelos
{
    public partial class Preparatoria
    {
        [Key]
        public string? PreparatoriaId { get; set; }

        [ForeignKey("IdProcesoCompra")]
        public string? IdProcesoCompra { get; set; }
        public ProcesoCompra? ProcesoCompra { get; set; }

        [Display(Name = "Fecha programada de revisión")]
        [DataType(DataType.Date)]
        public DateTime? fechaProgramada { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fechaProgramadaReal { get; set; }

        [Display(Name = "Fecha de solicitud de revisión")]
        [DataType(DataType.Date)]
        public DateTime? fechaSolicitud { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fechaSolicitudReal { get; set; }

        [Display(Name = "Fecha de respuesta efectiva")]
        [DataType(DataType.Date)]
        public DateTime? fechaRespuesta { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fechaRespuestaReal { get; set; }

        [Display(Name = "Fecha de mesa consultiva")]
        [DataType(DataType.Date)]
        public DateTime? fechaMesa { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fechaMesaReal { get; set; }

        [Display(Name = "Fecha de emisión")]
        [DataType(DataType.Date)]
        public DateTime? fechaEmision { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fechaEmisionReal { get; set; }

        [Display(Name = "Valor Certificado")]
        public decimal valorCertificado { get; set; }

        [Display(Name = "Fecha real de solicitud")]
        [DataType(DataType.Date)]
        public DateTime? fechaReal { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fechaRealReal { get; set; }

        [Display(Name = "Fecha de autorización")]
        [DataType(DataType.Date)]
        public DateTime? fechaAutorizacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fechaAutorizacionReal { get; set; }

        [Display(Name = "Fecha de publicación")]
        [DataType(DataType.Date)]
        public DateTime? fechaPublicacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime? fechaPublicacionReal { get; set; }

    }

}
