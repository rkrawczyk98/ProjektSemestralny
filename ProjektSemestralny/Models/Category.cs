using System.ComponentModel.DataAnnotations;

namespace ProjektSemestralny.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public List<Survey>? Surveys { get; set; }

    }
}
