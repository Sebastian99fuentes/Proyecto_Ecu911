using System.ComponentModel.DataAnnotations;

namespace Ecu911.Modelos
{
    public class Logs
    {
        public string? Id { get; set; }
        public string userName { get; set; }
        public string action { get; set; }
        [DataType(DataType.Date)]
        public DateTime? date { get; set; }
    }
}
