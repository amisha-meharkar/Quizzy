using Quiz.DAL.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.DAL.IServices
{
    public interface IQuestionService
    {
        List<Question_tbl> GiveQuestionDatabaseList();
    }
}
