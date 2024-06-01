using System.ComponentModel.DataAnnotations;

namespace deportsoft_api.Models
{
    public class RutinaDto
    {
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
        public IFormFile? ImageFile { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
