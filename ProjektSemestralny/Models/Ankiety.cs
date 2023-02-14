using System.ComponentModel.DataAnnotations;

namespace ProjektSemestralny.Models
{
    public class Ankiety
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nazwa { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime UtworzoneDateTime { get; set; } = DateTime.Now;
    }
}
