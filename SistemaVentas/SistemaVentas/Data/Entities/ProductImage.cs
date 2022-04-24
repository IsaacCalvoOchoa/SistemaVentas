using System.ComponentModel.DataAnnotations;

namespace SistemaVentas.Data.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }

        public Products Product { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        //TODO: Pending to change to the correct path
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:7057/images/noimage.png"
            : $"https://sistemaventas1.blob.core.windows.net/products/{ImageId}";

    }
}
