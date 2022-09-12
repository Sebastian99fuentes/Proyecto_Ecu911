
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Ecu911.Modelos
{
    public partial class ProcesoCompra
    {
        [Key]
        [Required]
          
        public Guid ProcesoCompraId { get; set; }

        [ForeignKey("IdProcesoCompra")]
        public ICollection<Preparatoria>? Preparatorias { get; set; }


        [Required]
        [ForeignKey("EstadoId")]
        public Guid EstadoId { get; set;}

        public Estado Estado { get; set;}


        [Required]
        [ForeignKey("EtapaId")]
        public Guid EtapaId { get; set; }
        public Etapa Etapa { get; set; }

        [Required]
        [ForeignKey("PlantaId")]
        public Guid PlantaId { get; set; }
        public PlantaUnidadArea PlantaUnidadArea { get; set; }

        [Required]
        [Display(Name = "Nro. Proceso")]
        [RegularExpression("([1-9][0-9]*)")]
        public int numProceso { get; set; }

        [Required]
        public long cpc { get; set; }

        [Required]
        [Display(Name = "Grupo de gasto")]
        [RegularExpression("([1-9][0-9]*)")]
        public int grupoGasto { get; set; }

        [Required]
        [Display(Name = "Item Presupuestario")]
        [RegularExpression("([1-9][0-9]*)")]
        public long itemPresup { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; } = "";

        [Required]
        [Column(TypeName = "decimal(15,2)")]
        [DataType(DataType.Currency)]
        [Display(Name = "Total (iva)")]
        public decimal total { get; set; }

        [Required]
        [Display(Name = "Cuatrimestre Planificado")]
        [RegularExpression("([1-9][0-9]*)")]
        public int cuatrimestre { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Mes Planificado")]
        public string mesPlanificado { get; set; }


        public ICollection<AlertaDSPPP> AlertasDSPPP { get; set; }
        public ICollection<Observacion> Observaciones { get; set; }

    }
    
}
