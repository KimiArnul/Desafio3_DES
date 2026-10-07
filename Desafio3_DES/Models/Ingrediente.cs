using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Desafio3_DES.Models
{
    public class Ingrediente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdIngrediente { get; set; }

        [Required(ErrorMessage = "El nombre del ingrediente es requerido")]
        [MinLength(3, ErrorMessage = "El nombre del ingrediente debe tener al menos 3 caracteres")]
        [MaxLength(50, ErrorMessage = "El nombre del ingrediente no puede exceder los 50 caracteres")]
        public string NombreIngrediente { get; set; } = string.Empty;

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public string UnidadMedida { get; set; } = string.Empty;

        [Required]
        public int RecetaId { get; set; }

        [ForeignKey(nameof(RecetaId))]
        [JsonIgnore]
        public Receta? Receta { get; set; }
    }
}
