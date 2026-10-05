using QuizViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.BAL.IAgent
{
    public interface ICouponAgent
    {
        List<CouponViewModel> GetCouponList();
        CouponViewModel GetCouponById(int couponId);
        bool AddCoupon(CouponViewModel couponViewModel);
        bool UpdateCoupon(CouponViewModel couponViewModel);
        bool DeleteCoupon(int couponId);
    }
}
