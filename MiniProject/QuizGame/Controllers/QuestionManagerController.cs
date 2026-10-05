using Quiz.BAL.IAgent;
using QuizViewModel.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace QuizGame.Controllers
{
    public class QuestionManagerController : Controller
    {
        #region Variables 
        private readonly IQuestionManagerAgent _questionManagerAgent;
        #endregion

        #region Constructor
        public QuestionManagerController()
        {
            _questionManagerAgent = DependencyResolver.Current.GetService<IQuestionManagerAgent>();
        }
        #endregion

        #region QuestionSelectionPage
        public ActionResult QuestionManager()
        {
            QuestionPromtViewModel promptObject = (QuestionPromtViewModel)Session["promptObject"];
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> QuestionManager(QuestionPromtViewModel questionCriteria)
        {
            QuestionPromtViewModel promptObject = (QuestionPromtViewModel)Session["promptObject"];
            questionCriteria.Category = promptObject.Category;
            List<QuestionViewModel> aiQuestions = await _questionManagerAgent.GetQuestionsBasedOnInput(questionCriteria);
            QuestionPromtViewModel TempObject = (QuestionPromtViewModel)Session["promptObject"];
            promptObject.Questions.AddRange(aiQuestions);
            Session["promptObject"] = TempObject;
            return View();
        }
        #endregion


        #region
        #endregion


        #region
        #endregion


        #region
        #endregion
    }
}