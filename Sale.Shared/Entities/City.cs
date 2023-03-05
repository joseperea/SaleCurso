using System.ComponentModel.DataAnnotations;

namespace Sale.Shared.Entities
{
    public class City
    {
        public int Id { get; set; }

        public int StateId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede contener mas de {1} caractéres")]
        [Display(Name = "Cuidad")]
        public string Name { get; set; } = null!;

        public State? State { get; set; }
    }
}
