using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizViewModel.ViewModels
{
    public class QuestionViewModel
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
