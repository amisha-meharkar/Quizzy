using Quiz.DAL.DBModels;
using Quiz.DAL.IServices.Admin;
using Quiz.DAL.Services.Admin;
using QuizWebAPIModel.APIModels.Admin;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI.InterfaceMapping;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Mvc.RouteAttribute;

namespace WebAPI.Controllers
{
    public class AdminAPIController : ApiController
    {
        #region Variables
        private readonly IAPIMapping _apiMapping;
        #endregion

        #region Constructor
        public AdminAPIController()
        {
            _apiMapping = DependencyResolver.Current.GetService<IAPIMapping>();
        }
        #endregion


        #region AdminLogin

        [HttpPost]
        [Route("AdminAPI/AuthenticateAdminDetails")]
        public bool AuthenticateAdminDetails([FromBody] AdminLoginAPIModel adminLoginAPIModel)
        {
            return _apiMapping.AuthenticateAdmin(adminLoginAPIModel);   
        }
        #endregion
        #region
        #endregion
    }
}
