using Quiz.DAL.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Quiz.DAL.IServices
{
    public interface IUserService
    {
        bool GetUserByEmailAndPassword(string emailAddress, string password);
        bool AddUser(User_tbl user);
    }
}
