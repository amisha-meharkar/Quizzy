using AutoMapper;
using Newtonsoft.Json;
using Quiz.BAL.IAgent.Admin;
using QuizViewModel.ViewModels.Admin;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;

namespace Quiz.BAL.Agent.Admin
{
    public class AdminAgent : IAdminAgent
    {
        private readonly IMapper _mapper;

        public AdminAgent()
        {
            _mapper = DependencyResolver.Current.GetService<IMapper>(); ;
        }

        public bool AuthenticateAdmin(AdminLoginViewModel loginViewModel)
        {
            using (var client = new HttpClient())
            {
                string apiUrl = "https://localhost:44314/AdminAPI/AuthenticateAdminDetails";
                string json = JsonConvert.SerializeObject(loginViewModel);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<bool>(responseContent);
                }
                return false;
            }
        }
    }
}
