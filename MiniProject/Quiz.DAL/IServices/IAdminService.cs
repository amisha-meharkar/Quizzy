using Quiz.DAL.DBModels;

namespace Quiz.DAL.IServices.Admin
{
    public interface IAdminService
    {
        bool AuthenticateAdmin(Admin_tbl admin_tbl);
    }
}
