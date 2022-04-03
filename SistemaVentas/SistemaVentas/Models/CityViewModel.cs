using System.ComponentModel.DataAnnotations;

namespace SistemaVentas.Models
{
    public class CityViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Ciudad")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        public int StateId { get; set; }
    }
}
