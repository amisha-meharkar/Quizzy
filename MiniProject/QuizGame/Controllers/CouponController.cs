using Quiz.BAL.IAgent;
using QuizViewModel.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace QuizGame.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponAgent couponAgent;

        public CouponController(ICouponAgent couponAgent)
        {
            this.couponAgent = couponAgent;
        }

        // GET: Product
        public ActionResult ShowCouponList()
        {
            List<CouponViewModel> couponList = couponAgent.GetCouponList();
            return View("CouponList",couponList);
        }


        // GET: Product/Create
        public ActionResult Create()
        {
            return View(new CouponViewModel());
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(CouponViewModel couponViewModel)
        {
            if (ModelState.IsValid)
            {
                couponAgent.AddCoupon(couponViewModel);
                return RedirectToAction("ShowCouponList");
            }

            return View(couponViewModel);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int couponId)
        {
            CouponViewModel couponViewModel = couponAgent.GetCouponById(couponId);
            return View(couponViewModel);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(CouponViewModel couponViewModel)
        {
            if (ModelState.IsValid)
            {
                couponAgent.UpdateCoupon(couponViewModel);
                return RedirectToAction("ShowCouponList");
            }

            return View(couponViewModel);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int couponId)
        {
            couponAgent.DeleteCoupon(couponId);
            return RedirectToAction("ShowCouponList");
        }
    }
}