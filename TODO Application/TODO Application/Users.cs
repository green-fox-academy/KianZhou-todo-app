using System.Collections.Generic;
using System.Security.Cryptography;

namespace TODO_Application
{
    public class Users
    {
        public List<Task> ListTasks { set; get; }
        public string Name { set; get; }
        public int UserId { set; get; }
        public string Password { set; get; }

        public Users(string name, int userId, string password)
        {
            ListTasks = new List<Task>();
            Name = name;
            UserId = userId;
            Password = password;
        }
    }
}