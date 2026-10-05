// Ignore Spelling: Admin BAL

using QuizViewModel.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.BAL.IAgent.Admin
{
    public interface IAdminAgent
    {
        #region AdminLogin
        bool AuthenticateAdmin(AdminLoginViewModel loginViewModel);
        #endregion

        #region
        #endregion
    }
}
