using System.ComponentModel.DataAnnotations;

namespace ProjektSemestralny.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public List<Question>? Questions { get; set; }
        public enum Type {Closed,TF,Selected,Open,SemiOpen};
    }
}
