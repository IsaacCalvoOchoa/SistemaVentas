using System.ComponentModel.DataAnnotations;

namespace SistemaVentas.Models
{
    public class StateViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Estado")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        public int CountryId { get; set; }
    }
}
