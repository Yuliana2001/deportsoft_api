using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace deportsoft_api.Models
{
    public class Deportist
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = "";
        public string Estado { get; set; } = "";
        public Rutina Rutina { get; set; }

    }
}
