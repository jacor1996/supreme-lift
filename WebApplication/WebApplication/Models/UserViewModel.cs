using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using Services.Implementations;

namespace WebApplication.Models
{
    public class UserViewModel
    {
        public User User { get; set; }
        public UserHelper UserHelper { get; set; }

        public UserViewModel(User user)
        {
            User = user;
            UserHelper = new UserHelper(User);
        }
    }
}