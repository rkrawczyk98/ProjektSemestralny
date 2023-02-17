using System.ComponentModel.DataAnnotations;

namespace ProjektSemestralny.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public string? AuthorId { get; set; }
    }
}
