using System.Web.Mvc;
using Quiz.BAL.IAgent;
using QuizViewModel;
using System.Web.Security;
using Quiz.Core.Utilities;

namespace QuizGame.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAgent _userAgent;

        public UserController(IUserAgent userAgent)
        {
            _userAgent = userAgent;
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {     
                if (_userAgent.AuthenticateUser(loginViewModel))
                {
                    FormsAuthentication.SetAuthCookie(loginViewModel.EmailAddress, false);
                    return RedirectToAction("MenuPage","Question");
                }
            }
            ModelState.AddModelError("", "Invalid Email and Password");
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SignUpViewModel signUpViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_userAgent.CreateUser(signUpViewModel))
                {
                    // Send email after successful sign-up
                    string subject = "Welcome to Quiz Game";
                    string body = "Thank you for signing up with Quiz Game!";
                    EmailUtility.SendEmail(signUpViewModel.EmailAddress, subject, body);

                    return RedirectToAction("Login");
                }
            }
            return View(signUpViewModel);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
