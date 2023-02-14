namespace ProjektSemestralny.Models
{
    public class Survey
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; set; }
    }
}
