using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Desafio3_DES.Models
{
    public class PasosPreparacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPaso { get; set; }

        [Required(ErrorMessage = "La descripción del paso es requerida")]
        [MinLength(10, ErrorMessage = "La longitud de la descripción del paso debe tener al menos 10 caracteres")]
        public string DescripcionPaso { get; set; } = string.Empty;

        [Required]
        public int OrdenPaso { get; set; }

        [Required]
        public int RecetaId { get; set; }

        [ForeignKey(nameof(RecetaId))]
        [JsonIgnore]
        public Receta? Receta { get; set; }
    }
}
