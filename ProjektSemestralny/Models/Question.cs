using System.ComponentModel.DataAnnotations;

namespace ProjektSemestralny.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public List<Answer> Answers { get; set; }
        public List<Survey_Question> Surveys_Questions { get; set; }
        public enum Type { Closed, TF, Selected, Open, SemiOpen };
    }
}
