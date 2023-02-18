using System.ComponentModel.DataAnnotations;

namespace ProjektSemestralny.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Question")]
        public string Content { get; set; }
        [Display(Name = "Category")]
        public int? CategoryId { get; set; } 
        public Category? Category { get; set; }
    }
}