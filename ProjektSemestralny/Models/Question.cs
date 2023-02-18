using System.ComponentModel.DataAnnotations;

namespace ProjektSemestralny.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        //public List<Answer>? Answers { get; set; }
        public int? CategoryId { get; set; } 
        public Category? Category { get; set; }
    }
}