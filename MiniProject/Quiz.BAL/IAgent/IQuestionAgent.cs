using QuizViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.BAL.IAgent
{
    public interface IQuestionAgent
    {
        List<QuestionViewModel> GetQuestionsList();
    }
}
