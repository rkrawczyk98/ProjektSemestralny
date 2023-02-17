//using MessagePack;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System;
using ProjektSemestralny.Areas.Identity.Data;

namespace ProjektSemestralny.Models
{
    public class Survey
    {
        [Key]
        public int Id { get; set; }
        
        public string Question { get; set; }

        public List<Survey_Question>? Surveys_Questions { get; set; }

        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        public string? AuthorId { get; set; }
        public enum Type { Closed, TF, Selected, Open, SemiOpen };
    }
}
