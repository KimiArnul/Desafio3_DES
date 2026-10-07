using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio3_DES.Models
{
    public class Receta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReceta { get; set; }

        [Required(ErrorMessage = "El nombre de la receta es requerido")]
        [MinLength(3, ErrorMessage = "El nombre de la receta debe tener al menos 3 caracteres")]
        [MaxLength(100, ErrorMessage = "El nombre de la receta no puede exceder los 100 caracteres")]
        public string NombreReceta { get; set; } = string.Empty;

        [Required]
        [MaxLength(450)]
        public string Descripcion { get; set; } = string.Empty;

        public TimeOnly TiempoPreparacion { get; set; }

        public ICollection<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();

        public ICollection<PasosPreparacion> PasosPreparacion { get; set; } = new List<PasosPreparacion>();
    }
}
