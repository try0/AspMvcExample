using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.MVC.Models
{
    [Serializable]
    public class ListExampleModel
    {
        public class User { 
            public string UserId { get; set; }
            public string UserName { get; set; }

            public int Age { get; set; }
        }

        public List<User> UserList { get; set; } = new List<User>();
    }
}