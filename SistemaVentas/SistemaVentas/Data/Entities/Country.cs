using System.ComponentModel.DataAnnotations;

namespace SistemaVentas.Data.Entities
{
    public class Country
    {
        public int ID { get; set; }

        [Display(Name = "País")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required (ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }
    }
}
