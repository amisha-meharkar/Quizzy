using Quiz.DAL.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.DAL.IServices
{
    public interface ICouponService
    {
        List<Coupon_tbl> GetCouponList();
        Coupon_tbl GetCouponById(int couponId);
        bool AddCoupon(Coupon_tbl coupon);
        bool UpdateCoupon(Coupon_tbl coupon);
        bool DeleteCoupon(int couponId);
    }
}
