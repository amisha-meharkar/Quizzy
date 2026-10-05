using Quiz.DAL.DBModels;
using Quiz.DAL.IServices.Admin;
using System.Linq;

namespace Quiz.DAL.Services.Admin
{
    public class AdminService : IAdminService
    {
        #region Variables
        private readonly QuizGameEntities _context;
        #endregion

        #region Constructor
        public AdminService(QuizGameEntities context)
        {
            _context = context;
        }
        #endregion

        public bool AuthenticateAdmin(Admin_tbl admin_tbl)
        {
            if(_context.Admin_tbl.Any(x => x.Username == admin_tbl.Username && x.Password == admin_tbl.Password))
            {
                return true;
            }
            return false;
        }

        #region
        #endregion
    }
}
