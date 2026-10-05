using AutoMapper;
using Quiz.BAL.Agent;
using Quiz.BAL.Agent.Admin;
using Quiz.BAL.IAgent;
using Quiz.BAL.IAgent.Admin;
using Quiz.DAL.DBModels;
using QuizViewModel;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Quiz.ConfigurationManager.App_Start
{
    public class AutoMapperAndDependencyResolver
    {
        public static void Initialize()
        {
            var container = new UnityContainer();

            container.RegisterType<IUserAgent, UserAgent>();
            container.RegisterType<ICouponAgent, CouponAgent>();
            container.RegisterType<IQuestionAgent,QuestionAgent>();
            container.RegisterType<IAdminAgent, AdminAgent>();
            container.RegisterType<IQuestionManagerAgent, QuestionManagerAgent>();

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LoginViewModel, User_tbl>().ReverseMap();

            });

            // Register IMapper instance
            container.RegisterInstance(mapperConfiguration.CreateMapper());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
