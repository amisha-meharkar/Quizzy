using QuizWebAPIModel.APIModels;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI.InterfaceMapping;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace WebAPI.Controllers
{
    public class QuestionAPIController : ApiController
    {
        readonly IAPIMapping _apiMapping;
        public QuestionAPIController()
        {
            _apiMapping = DependencyResolver.Current.GetService<IAPIMapping>();
        }

        [HttpGet]
        [Route("QuestionAPI/GetQuestions")]
        public List<QuestionAPIModel> GetQuestions()
        {
           return _apiMapping.PassQuestionList();
        }
    }
}
