namespace QuizWebAPIModel.APIModels
{
    public class QuestionAPIModel
    {
        public int QuestionId { get; set; } = 0;
        public string Category { get; set; } = string.Empty;
        public string Question { get; set; }
        public string FirstOption { get; set; }
        public string SecondOption { get; set; }
        public string ThirdOption { get; set; }
        public string FourthOption { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
