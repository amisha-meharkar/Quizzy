using AutoMapper;
using Quiz.DAL.DBModels;
using Quiz.DAL.IServices;
using Quiz.DAL.IServices.Admin;
using QuizWebAPIModel.APIModels;
using QuizWebAPIModel.APIModels.Admin;
using QuizWebAPIModel.UserAPIModel;
using System.Collections.Generic;
using WebAPI.InterfaceMapping;
namespace WebAPI.NormalMapping
{
    public class APIMapping : IAPIMapping
    {
        private readonly IUserService _userService;
        private readonly IQuestionService _questionService;
        private readonly ICouponService _couponService;
        private readonly IMapper _mapper;
        private readonly IAdminService _adminService;
        public APIMapping(IUserService userService, IMapper mapper, IQuestionService questionService, ICouponService couponService,IAdminService adminService)
        {
            _userService = userService;
            _questionService = questionService;
            _mapper = mapper;
            _couponService = couponService;
            _adminService = adminService;
        }

        public bool AuthenticateUser(LoginAPIModel loginAPIModel)
        {
            return _userService.GetUserByEmailAndPassword(loginAPIModel.EmailAddress,loginAPIModel.Password);   
        }
        public bool CreateUser(SignUpAPIModel signUpAPIModel)
        {
            return _userService.AddUser(_mapper.Map<User_tbl>(signUpAPIModel));
        }
        
        public List<QuestionAPIModel> PassQuestionList()
        {
            return _mapper.Map<List<QuestionAPIModel>>(_questionService.GiveQuestionDatabaseList());
        }

        public List<CouponAPIModel> PassCouponList()
        {
            return _mapper.Map<List<CouponAPIModel>>(_couponService.GetCouponList());
        }
        public CouponAPIModel GiveCouponById(int couponId)
        {
            return _mapper.Map<CouponAPIModel>(_couponService.GetCouponById(couponId));
        }

        public bool AddCoupon(CouponAPIModel couponAPIModel)
        {
            return _couponService.AddCoupon(_mapper.Map<Coupon_tbl>(couponAPIModel));
        }

        public bool UpdateCoupon(CouponAPIModel couponAPIModel)
        {
            return _couponService.UpdateCoupon(_mapper.Map<Coupon_tbl>(couponAPIModel));
        }
        public bool DeleteCoupon(int couponId)
        {
            return _couponService.DeleteCoupon(couponId);
        }

        public bool AuthenticateAdmin(AdminLoginAPIModel adminLoginAPIModel)
        {
            return _adminService.AuthenticateAdmin(_mapper.Map<Admin_tbl>(adminLoginAPIModel));
        }
    }
}