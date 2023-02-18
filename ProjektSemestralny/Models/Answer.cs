using Microsoft.AspNetCore.Identity;
using ProjektSemestralny.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektSemestralny.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Answer")]
        public string Content { get; set; }
        public Question? Question { get; set; }
        [Display(Name = "Question")]
        public int? QuestionId { get; set; }
        public ApplicationUser? Author { get; set; }
        public string? AuthorId { get; set; }
    }
}
