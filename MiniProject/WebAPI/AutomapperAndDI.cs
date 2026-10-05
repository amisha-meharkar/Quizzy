using AutoMapper;
using Quiz.DAL.DBModels;
using Quiz.DAL.IServices;
using Quiz.DAL.IServices.Admin;
using Quiz.DAL.Services;
using Quiz.DAL.Services.Admin;
using QuizWebAPIModel.APIModels;
using QuizWebAPIModel.APIModels.Admin;
using QuizWebAPIModel.UserAPIModel;
using System.Net.Http;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebAPI.InterfaceMapping;
using WebAPI.NormalMapping;

namespace WebAPI.AutomappingConfigurations
{
    public class AutomapperAndDI
    {
        public static void Initialize()
        {
            var container = new UnityContainer();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ICouponService, CouponService>();
            container.RegisterType<IQuestionService, QuestionService>();         
            container.RegisterType<ICouponService, CouponService>();         
            container.RegisterType<IAdminService, AdminService>();         
            container.RegisterType<IAPIMapping, APIMapping>();
            container.RegisterInstance(new HttpClient());

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SignUpAPIModel, User_tbl>().ReverseMap();
                cfg.CreateMap<QuestionAPIModel, Question_tbl>().ReverseMap();
                cfg.CreateMap<CouponAPIModel, Coupon_tbl>().ReverseMap();
                cfg.CreateMap<AdminLoginAPIModel, Admin_tbl>().ReverseMap();
            });

            // Register IMapper instance
            container.RegisterInstance(mapperConfiguration.CreateMapper());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}