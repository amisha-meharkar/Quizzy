using Quiz.BAL.IAgent;
using QuizViewModel.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

public class QuestionController : Controller
{
    private readonly IQuestionAgent _questionAgent;

    public QuestionController(IQuestionAgent questionAgent)
    {
        _questionAgent = questionAgent;
    }

    // GET: QuizMenu
    public ActionResult MenuPage()
    {
        // Initialize the counter in the session if it doesn't exist
        if (Session["Counter"] == null)
        {
            Session["Counter"] = -1;
            Session["score"] = 0;
        }
        return View();
    }

    public ActionResult QuizMain()
    {
        // Increment the counter stored in the session

        int counter = (int)Session["Counter"];
        counter++;
        Session["Counter"] = counter;
        if (counter < _questionAgent.GetQuestionsList().Count)
        {
            return View("QuizStart", GiveNextQuestion());
        }
        return View("Score");
    }

    public QuestionViewModel GiveNextQuestion()
    {
        // Retrieve the counter from the session
        int counter = (int)Session["Counter"];
        List<QuestionViewModel> questions = _questionAgent.GetQuestionsList();
        return questions[counter];
    }

    [HttpGet]
    public bool IncreaseScore()
    {
        int score = (int)Session["score"];
        score++;
        Session["score"] = score;
        return true;
    }


    // POST: QuizMenu/RecordAnswer
    [HttpPost]
    public ActionResult RecordAnswer(QuestionViewModel model)
    {
        // Save the answer to the database or wherever you want
        // For demonstration, let's assume you have a table named UserAnswers with columns: UserId, QuestionId, and Answer
        // You would then save the answer like this:
        // var userAnswer = new UserAnswer { UserId = "user_id_here", QuestionId = model.QuestionId, Answer = model.Answer };
        // _context.UserAnswers.Add(userAnswer);
        // _context.SaveChanges();

        return RedirectToAction("QuizStart"); // Redirect to the next question
    }

    public ActionResult Result()
    {
        return View("Index", "Home");
    }
}