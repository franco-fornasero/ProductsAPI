using System.ComponentModel.DataAnnotations;

namespace ProductsApp.Data.Models
{
    public class Product
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int? Height { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int? Width { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Depth { get; set; }
        public int? Weight { get; set; }


    }
}
