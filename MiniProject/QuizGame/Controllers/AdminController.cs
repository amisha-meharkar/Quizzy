using Quiz.BAL.IAgent.Admin;
using QuizViewModel.ViewModels;
using QuizViewModel.ViewModels.Admin;
using System.Web.Mvc;
using System.Web.Security;

namespace QuizGame.Controllers
{
    public class AdminController : Controller
    {
        #region Variables
        IAdminAgent _adminAgent;
        #endregion

        #region constructor
        public AdminController(IAdminAgent adminAgent)
        {
            _adminAgent = adminAgent;
        }
        #endregion

        #region AdminLandingPage
        public ActionResult AdminLandingPage()
        {
            Session["promptObject"] = new QuestionPromtViewModel();
            return View();
        }
        #endregion


        #region 
        [HttpPost]
        public ActionResult AdminLandingPage(QuestionPromtViewModel questionPromtViewModel)
        {
            Session["promptObject"] = questionPromtViewModel;
            return RedirectToAction("QuestionManager","QuestionManager");
        }
        #endregion

        #region Login
        public ActionResult AdminLogin()
        {
            return View(new AdminLoginViewModel());
        }

        [HttpPost]
        public ActionResult AdminLogin(AdminLoginViewModel adminLoginViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_adminAgent.AuthenticateAdmin(adminLoginViewModel))
                    {
                        FormsAuthentication.SetAuthCookie(adminLoginViewModel.Username, false);
                        return RedirectToAction("AdminLandingPage", "Admin");
                    }
                }
                return View(adminLoginViewModel);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }
        #endregion

        #region
        #endregion
    }
}