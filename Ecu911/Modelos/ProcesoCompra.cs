using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Ecu911.Modelos
{
    public partial class ProcesoCompra
    {
        [Key]
        public string? ProcesoCompraId { get; set; }

        //[Column(TypeName = "decimal(3,2)")]
        public decimal? Avance { get; set; }

        [ForeignKey("IdProcesoCompra")]
        public ICollection<Preparatoria>? Preparatorias { get; set; }


        [Required]
        [ForeignKey("EstadoId")]
        public string EstadoId { get; set; }
        public Estado? Estado { get; set; }

        [Required]
        [ForeignKey("ProcedimientoId")]
        public string ProcedimientoId { get; set; }
        public ProcedimientoContratacion? Procedimiento { get; set; }


        [Required]
        [ForeignKey("EtapaId")]
        public string EtapaId { get; set; }
        public Etapa? Etapa { get; set; }

        [Required]
        [ForeignKey("PlantaId")]
        public string PlantaId { get; set; }
        public Unidad? Planta { get; set; }

        [Required]
        public string cpc { get; set; }

        [Required]
        [Display(Name = "Grupo de gasto")]
        [RegularExpression("([1-9][0-9]*)")]
        public string grupoGasto { get; set; }

        [Required]
        [Display(Name = "Item Presupuestario")]
        [RegularExpression("([1-9][0-9]*)")]
        public string itemPresup { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

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

        public string? sectorOpcional { get; set; }


        public ICollection<AlertaDSPPP>? AlertasDSPPP { get; set; }
        public ICollection<Observacion>? Observaciones { get; set; }

    }

}
