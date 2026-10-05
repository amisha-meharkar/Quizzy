using QuizViewModel;

namespace Quiz.BAL.IAgent
{
    public interface IUserAgent
    {
        bool AuthenticateUser(LoginViewModel loginViewModel);
        bool CreateUser(SignUpViewModel signUpViewModel);
    }
}
