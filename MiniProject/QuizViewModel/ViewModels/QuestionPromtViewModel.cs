using System.Collections.Generic;

namespace QuizViewModel.ViewModels
{
    public class QuestionPromtViewModel
    {
        public string Category {  get; set; }= string.Empty;

        public int NumberOfQuestions { get; set; } = 0;
        public List<QuestionViewModel> Questions { get; set; } = new List<QuestionViewModel>();
    }
}
