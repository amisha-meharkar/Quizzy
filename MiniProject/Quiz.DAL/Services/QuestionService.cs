using Quiz.DAL.DBModels;
using Quiz.DAL.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.DAL.Services
{
    public class QuestionService:IQuestionService
    {
        private readonly QuizGameEntities _context;

        public QuestionService(QuizGameEntities context)
        {
            _context = context;
        }
        public List<Question_tbl> GiveQuestionDatabaseList()
        {
            List<Question_tbl> QuestionList = _context.Question_tbl.ToList();    
            return QuestionList;
        }
    }
}
