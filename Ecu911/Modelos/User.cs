using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Ecu911.Modelos
{
    public partial class User : IdentityUser
    {
        public Guid AreaId { get; set; }
        [ForeignKey("AreaId")]
        public PlantaUnidadArea area { get; set; }
    }
}
