using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Veterinaria.Models
{
    public class Vacina
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
    }
}
