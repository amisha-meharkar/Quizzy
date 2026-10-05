using Newtonsoft.Json;
using Quiz.BAL.IAgent;
using QuizViewModel.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Quiz.BAL.Agent
{
    public class CouponAgent : ICouponAgent
    {
        private readonly HttpClient _httpClient;

        public CouponAgent(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<CouponViewModel> GetCouponList()
        {
            using (var client = new HttpClient())
            {

                
                HttpResponseMessage response = client.GetAsync("https://localhost:44314/CouponAPI/GetCouponList").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<CouponViewModel>>(jsonResponse);
                }
            }
            return null;
        }

        public CouponViewModel GetCouponById(int couponId)
        {
            string apiUrl = $"https://localhost:44314/CouponAPI/GetCouponById/{couponId}";
            HttpResponseMessage response = _httpClient.GetAsync(apiUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<CouponViewModel>(jsonResponse);
            }
            return null;
        }

        public bool AddCoupon(CouponViewModel couponViewModel)
        {
            string apiUrl = "https://localhost:44314/CouponAPI/AddCoupon";
            string json = JsonConvert.SerializeObject(couponViewModel);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync(apiUrl, content).Result;
            //return response.IsSuccessStatusCode;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<bool>(responseContent);
            }
            return false;
        }

        public bool UpdateCoupon(CouponViewModel couponViewModel)
        {
            string apiUrl = "https://localhost:44314/CouponAPI/UpdateCoupon";
            string json = JsonConvert.SerializeObject(couponViewModel);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync(apiUrl, content).Result;
            // return response.IsSuccessStatusCode;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<bool>(responseContent);
            }
            return false;
        }

        public bool DeleteCoupon(int couponId)
        {
            string apiUrl = $"https://localhost:44314/CouponAPI/DeleteCoupon/{couponId}";
            HttpResponseMessage response = _httpClient.DeleteAsync(apiUrl).Result;
            //return response.IsSuccessStatusCode;
             if (response.IsSuccessStatusCode)
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<bool>(responseContent);
                }
                return false;
        }
    }
}
