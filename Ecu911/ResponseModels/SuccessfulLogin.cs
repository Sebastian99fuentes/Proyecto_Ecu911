using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Ecu911.ResponseModels
{
    public class SuccessfulLogin
    {
        [Display(Name = "Access-Token")]
        public string token { get; set; }
        [Display(Name = "Refresh-Token")]
        public string refreshedToken { get; set; }
        [Display(Name = "Role")]
        public string? Role { get; set; }
    }
}
