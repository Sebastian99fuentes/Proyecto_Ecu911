using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Ecu911.Modelos
{
    public partial class UserRegisterRequest 
    {
        public string userName { get; set; }
        public string rol { get; set; }
<<<<<<< HEAD:Ecu911/Modelos/Useregistrar.cs
        public string plantaId { get; set; }
=======

        public string planta { get; set; }
>>>>>>> b1926743a8abd4f9c534d940fecb47fee2ee5d67:Ecu911/Modelos/UserRegisterRequest.cs
    }
}
