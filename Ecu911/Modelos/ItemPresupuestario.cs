using System.ComponentModel.DataAnnotations;

namespace Ecu911.Modelos
{
    public class ItemPresupuestario
    {
        [Key]
        public string? itemId { get; set; }

        public string nunItem { get; set; } 
    }
}
