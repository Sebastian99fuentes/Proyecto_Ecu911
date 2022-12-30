using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Ecu911.Modelos
{
    public partial class Useregistrar 
    {
        public string userName { get; set; }
        public string rol { get; set; }
        public string plantaId { get; set; }
    }
}
