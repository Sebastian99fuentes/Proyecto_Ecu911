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

        [DataType(DataType.Date)]
        public DateTime? informeNecesidad { get; set; }
        [DataType(DataType.Date)]
        public DateTime? informeNecesidadReal { get; set; }

        [DataType(DataType.Date)]
        public DateTime? terminosReferencia { get; set; }
        [DataType(DataType.Date)]
        public DateTime? terminosReferenciaReal { get; set; }

        [DataType(DataType.Date)]
        public DateTime? solicitudPublicacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime? solicitudPublicacionReal { get; set; }

        [DataType(DataType.Date)]
        public DateTime? publicacionNecesidad { get; set; }
        [DataType(DataType.Date)]
        public DateTime? publicacionNecesidadReal { get; set; }

        [DataType(DataType.Date)]
        public DateTime? recepcionCotizaciones { get; set; }
        [DataType(DataType.Date)]
        public DateTime? recepcionCotizacionesReal { get; set; }

        [DataType(DataType.Date)]
        public DateTime? elaboracionEstudioMercado { get; set; }
        [DataType(DataType.Date)]
        public DateTime? elaboracionEstudioMercadoReal { get; set; }

        [DataType(DataType.Date)]
        public DateTime? solicitudPAPP { get; set; }
        [DataType(DataType.Date)]
        public DateTime? solicitudPAPPReal { get; set; }

        [DataType(DataType.Date)]
        public DateTime? emisionPAPP { get; set; }
        [DataType(DataType.Date)]
        public DateTime? emisionPAPPReal { get; set; }

        [DataType(DataType.Date)]
        public DateTime? solicitudPresup { get; set; }
        [DataType(DataType.Date)]
        public DateTime? solicitudPresupReal { get; set; }

        [DataType(DataType.Date)]
        public DateTime? emisionPresup { get; set; }
        [DataType(DataType.Date)]
        public DateTime? emisionPresupReal { get; set; }

        [DataType(DataType.Date)]
        public DateTime? solicitudPAC { get; set; }
        [DataType(DataType.Date)]
        public DateTime? solicitudPACReal { get; set; }

        [DataType(DataType.Date)]
        public DateTime? emisionPAC { get; set; }
        [DataType(DataType.Date)]
        public DateTime? emisionPACReal { get; set; }

        [DataType(DataType.Date)]
        public DateTime? solicitudCoordinadorZonal { get; set; }
        [DataType(DataType.Date)]
        public DateTime? solicitudCoordinadorZonalReal { get; set; }

        [DataType(DataType.Date)]
        public DateTime? resolucionInicio { get; set; }
        [DataType(DataType.Date)]
        public DateTime? resolucionInicioReal { get; set; }

        [DataType(DataType.Date)]
        public DateTime? publicacionProceso { get; set; }
        [DataType(DataType.Date)]
        public DateTime? publicacionProcesoReal { get; set; }
    }

}

//[Display(Name = "Fecha programada de revisión")]
//[DataType(DataType.Date)]
//public DateTime? fechaProgramada { get; set; }
//[DataType(DataType.Date)]
//public DateTime? fechaProgramadaReal { get; set; }

//[Display(Name = "Fecha de solicitud de revisión")]
//[DataType(DataType.Date)]
//public DateTime? fechaSolicitud { get; set; }
//[DataType(DataType.Date)]
//public DateTime? fechaSolicitudReal { get; set; }

//[Display(Name = "Fecha de respuesta efectiva")]
//[DataType(DataType.Date)]
//public DateTime? fechaRespuesta { get; set; }
//[DataType(DataType.Date)]
//public DateTime? fechaRespuestaReal { get; set; }

//[Display(Name = "Fecha de mesa consultiva")]
//[DataType(DataType.Date)]
//public DateTime? fechaMesa { get; set; }
//[DataType(DataType.Date)]
//public DateTime? fechaMesaReal { get; set; }

//[Display(Name = "Fecha de emisión")]
//[DataType(DataType.Date)]
//public DateTime? fechaEmision { get; set; }
//[DataType(DataType.Date)]
//public DateTime? fechaEmisionReal { get; set; }

//[Display(Name = "Valor Certificado")]
//public decimal valorCertificado { get; set; }

//[Display(Name = "Fecha real de solicitud")]
//[DataType(DataType.Date)]
//public DateTime? fechaReal { get; set; }
//[DataType(DataType.Date)]
//public DateTime? fechaRealReal { get; set; }

//[Display(Name = "Fecha de autorización")]
//[DataType(DataType.Date)]
//public DateTime? fechaAutorizacion { get; set; }
//[DataType(DataType.Date)]
//public DateTime? fechaAutorizacionReal { get; set; }

//[Display(Name = "Fecha de publicación")]
//[DataType(DataType.Date)]
//public DateTime? fechaPublicacion { get; set; }
//[DataType(DataType.Date)]
//public DateTime? fechaPublicacionReal { get; set; }
