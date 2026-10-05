using QuizWebAPIModel.APIModels;
using QuizWebAPIModel.APIModels.Admin;
using QuizWebAPIModel.UserAPIModel;
using System.Collections.Generic;

namespace WebAPI.InterfaceMapping
{
    public interface IAPIMapping
    {
        bool AuthenticateUser(LoginAPIModel loginAPIModel);
        bool CreateUser(SignUpAPIModel signUpAPIModel);
        List<QuestionAPIModel> PassQuestionList();
        List<CouponAPIModel> PassCouponList();
        CouponAPIModel GiveCouponById(int couponId);
        bool AddCoupon(CouponAPIModel couponAPIModel);
        bool UpdateCoupon(CouponAPIModel couponAPIModel);
        bool DeleteCoupon(int couponId);
        bool AuthenticateAdmin(AdminLoginAPIModel adminLoginAPIModel);
    }
}