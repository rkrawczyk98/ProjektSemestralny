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
        public string Content { get; set; }
        public Question? Question { get; set; }
        public int? QuestionId { get; set; }
        public ApplicationUser? Author { get; set; }
        public string? AuthorId { get; set; }
    }
}
