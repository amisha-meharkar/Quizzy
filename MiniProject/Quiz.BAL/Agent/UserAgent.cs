using Newtonsoft.Json;
using Quiz.BAL.IAgent;
using QuizViewModel;
using System.Net.Http;
using System.Text;

namespace Quiz.BAL.Agent
{
    public class UserAgent : IUserAgent
    {
        public bool AuthenticateUser(LoginViewModel loginViewModel)
        {
            using (var client = new HttpClient())
            {
                string apiUrl = "https://localhost:44314/UserAPI/CheckUser";
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


        public bool CreateUser(SignUpViewModel signUpViewModel)
        {
            using (var client = new HttpClient())
            {
                string apiUrl = "https://localhost:44314/UserAPI/AddUser";
                string json = JsonConvert.SerializeObject(signUpViewModel);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
