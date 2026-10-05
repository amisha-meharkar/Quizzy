using Quiz.DAL.DBModels;
using Quiz.DAL.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.DAL.Services
{
    public class CouponService : ICouponService
    {
        private readonly QuizGameEntities _db;

        public CouponService(QuizGameEntities dbContext)
        {
            _db = dbContext;
        }

        public List<Coupon_tbl> GetCouponList()
        {
            using (QuizGameEntities db = new QuizGameEntities())
            {
                return db.Coupon_tbl.ToList();
            }
        }

        public Coupon_tbl GetCouponById(int couponId)
        {
            return _db.Coupon_tbl.Find(couponId);
        }

        public bool AddCoupon(Coupon_tbl coupon)
        {
            _db.Coupon_tbl.Add(coupon);
            _db.SaveChanges();
            return true;
        }

        public bool UpdateCoupon(Coupon_tbl coupon)
        {
            _db.Entry(coupon).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            return true;
        }

        public bool DeleteCoupon(int couponId)
        {
            var coupon = _db.Coupon_tbl.Find(couponId);
            if (coupon != null)
            {
                _db.Coupon_tbl.Remove(coupon);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
