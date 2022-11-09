using System.ComponentModel.DataAnnotations;

namespace Ecu911.Modelos
{
    public class UserRegisterRequest
    {
        public string userName { get; set; }

        [EmailAddress]
        public string email { get; set; }

        public string password { get; set; }

        public string rol { get; set; }

        public PlantaUnidadArea planta { get; set; }
    }
}
