using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SistemaVentas.Data.Entities
{
    public class City
    {
        public int ID { get; set; }

        [Display(Name = "Ciudad")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [JsonIgnore]
        public State State { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
