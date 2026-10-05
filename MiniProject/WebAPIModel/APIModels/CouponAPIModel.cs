using System;

namespace QuizWebAPIModel.APIModels
{
    public class CouponAPIModel
    {
        public int CouponId { get; set; }
        public string CouponCategory { get; set; }
        public string CouponCode { get; set; }
        public DateTime CouponExpiryDate { get; set; }
    }
}
