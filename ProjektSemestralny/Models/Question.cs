namespace ProjektSemestralny.Models
{
    public class Question
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public List<Answer> Answers { get; set; }

    }
}
