using System.ComponentModel.DataAnnotations;

namespace Sale.Shared.Entities
{
    public class State
    {
        public int Id { get; set; }

        public int CountryId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede contener mas de {1} caractéres")]
        [Display(Name = "Estado/Departamento")]
        public string Name { get; set; } = null!;

        public Country? Country { get; set; }
        public ICollection<City>? Cities { get; set; }

        public int CitiesNumber => Cities == null ? 0 : Cities.Count;
    }
}
