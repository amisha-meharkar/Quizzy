using System.Web.Http;
using QuizWebAPIModel.APIModels;
using System.Collections.Generic;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using WebAPI.InterfaceMapping;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;

namespace WebAPI.Controllers
{
    public class CouponAPIController : ApiController
    {
        readonly IAPIMapping _apiMapping;

        public CouponAPIController()
        {
            _apiMapping = DependencyResolver.Current.GetService<IAPIMapping>();
        }

        [HttpGet]
        [Route("CouponAPI/GetCouponList")]
        public List<CouponAPIModel> GetCouponList()
        {
            return _apiMapping.PassCouponList();
        }

        [HttpGet]
        [Route("CouponAPI/GetCouponById/{couponId}")]
        public CouponAPIModel GetCouponById(int couponId)
        {
            return _apiMapping.GiveCouponById(couponId);
        }

        [System.Web.Http.HttpPost]
        [Route("CouponAPI/AddCoupon")]
        public bool AddCoupon([FromBody] CouponAPIModel couponAPIModel)
        {
            return _apiMapping.AddCoupon(couponAPIModel);
        }

        [HttpPost]
        [Route("CouponAPI/UpdateCoupon")]
        public bool UpdateCoupon([FromBody] CouponAPIModel couponAPIModel)
        {
            return _apiMapping.UpdateCoupon(couponAPIModel);
        }

        [HttpDelete]
        [Route("CouponAPI/DeleteCoupon/{couponId}")]
        public bool DeleteCoupon(int couponId)
        {
            return _apiMapping.DeleteCoupon(couponId);
        }

        [HttpGet]
        [Route("CouponAPI/PassCouponNames")]
        public List<string> PassCouponNames()
        {
            List<string> namesOfCoupon = new List<string>(); 
            List<CouponAPIModel> couponList= _apiMapping.PassCouponList();
            foreach(CouponAPIModel coupon in couponList)
            {
                namesOfCoupon.Add(coupon.CouponCategory);
            }
            return namesOfCoupon;
        }
    }
}
