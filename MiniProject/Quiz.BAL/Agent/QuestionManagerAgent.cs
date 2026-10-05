using AutoMapper;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Quiz.BAL.IAgent;
using QuizViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.BAL.Agent
{
    public class QuestionManagerAgent : IQuestionManagerAgent
    {
        #region Variable
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public QuestionManagerAgent(IMapper mapper)
        {
            _mapper = mapper;
        }
        #endregion

        public async Task<List<QuestionViewModel>> GetQuestionsBasedOnInput(QuestionPromtViewModel questionPrompt)
        {
            List<QuestionViewModel> questions = new List<QuestionViewModel>();

            try
            {
                using (var client = new HttpClient())
                {
                    string apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent?key=AIzaSyCoM5t4TMqVie_K4dxBzmJ2APHRo0aD-EQ";

                    string prompt = $"provide me json response of {questionPrompt.NumberOfQuestions} mcq on {questionPrompt.Category} with json keys Question , FirstOption, SecondOption, ThirdOption , FourthOption ,CorrectAnswer , Category without any comments without ```json and make the category ={questionPrompt.Category} for all questions";
                    //string prompt = "provide me JSON response of 5 MCQs on science with JSON keys: Question, FirstOption, SecondOption, ThirdOption, FourthOption, CorrectAnswer, Category, without any comments, without ```json, and make the category the same for all questions.";
                    using (var content = new StringContent("{\"contents\":[{\"parts\":[{\"text\":\"" + prompt + "\"}]}]}", Encoding.UTF8, "application/json"))
                    {
                        HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                        if (response.IsSuccessStatusCode)
                        {
                            string responseJson = await response.Content.ReadAsStringAsync();

                            // Parse the response JSON
                            JObject responseObject = JObject.Parse(responseJson);

                            // Extract the inner text from the 'text' object
                            string innerText = responseObject["candidates"][0]["content"]["parts"][0]["text"].ToString();
                            string list = $"[{innerText}]";

                            List<QuestionViewModel> data = JsonConvert.DeserializeObject<List<QuestionViewModel>>(list);
                            return data;
                        }
                        else
                        {
                            Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            return questions;
        }
    }
}
