using Quiz.DAL.DBModels;
using Quiz.DAL.IServices;
using System.Linq;

namespace Quiz.DAL.Services
{
    public class UserService : IUserService
    {
        private readonly QuizGameEntities _context;

        public UserService(QuizGameEntities context)
        {
            _context = context;
        }

        public bool GetUserByEmailAndPassword(string emailAddress, string password)
        {
            return _context.User_tbl.Any(x => x.EmailAddress == emailAddress && x.Password == password);
        }

        public bool AddUser(User_tbl user)
        {
            _context.User_tbl.Add(user);
            _context.SaveChanges();
            return true;
        }
    }
}
