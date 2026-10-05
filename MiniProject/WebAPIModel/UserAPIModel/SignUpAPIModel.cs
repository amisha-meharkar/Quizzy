namespace QuizWebAPIModel.UserAPIModel
{
    public class SignUpAPIModel
    {
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public int Attempts { get; set; } = 1;
    }
}
