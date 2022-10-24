using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Ecu911.ResponseModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Ingrese su usuario")]
        [Display(Name = "Usuario")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Ingrese la contraseña")]
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}
