namespace ProjektSemestralny.Models
{
    public class Answer
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public enum Type {Closed,TF,Selected,Open,SemiOpen};
    }
}
