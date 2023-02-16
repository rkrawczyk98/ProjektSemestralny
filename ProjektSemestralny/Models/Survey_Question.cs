namespace ProjektSemestralny.Models
{
    public class Survey_Question
    {
        public int SurveyId { get; set; }

        public Survey Survey { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
