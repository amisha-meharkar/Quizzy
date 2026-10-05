using Newtonsoft.Json;
using Quiz.BAL.IAgent;
using QuizViewModel.ViewModels;
using System.Collections.Generic;
using System.Net.Http;

namespace Quiz.BAL.Agent
{
    public class QuestionAgent:IQuestionAgent
    {
        public List<QuestionViewModel> GetQuestionsList()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync("https://localhost:44314/QuestionAPI/GetQuestions").Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = response.Content.ReadAsStringAsync().Result;
                    List<QuestionViewModel> questions = JsonConvert.DeserializeObject<List<QuestionViewModel>>(jsonString);
                    return questions;
                }
                return new List<QuestionViewModel>();
            }
        }
    }
}
