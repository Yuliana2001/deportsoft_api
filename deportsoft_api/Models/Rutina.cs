using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace deportsoft_api.Models
{
    public class Rutina
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UsuarioId")]
        public ApplicationUser User { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = "";

        [MaxLength(500)]
        public string Descripcion { get; set; } = "";

        [Required]
        public int Duracion { get; set; } // Duración en minutos

        [Required]
        [MaxLength(50)]
        public string Nivel { get; set; } = ""; // Nivel de dificultad
        public string ImageFileName { get; set; } = "";

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
