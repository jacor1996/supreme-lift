using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Services.Interfaces;

namespace Services.Implementations
{
    public class UserHelper : IUserHelper
    {
        private User _user;

        public UserHelper(User user)
        {
            _user = user;
        }

        public double GetBMI()
        {
            throw new NotImplementedException();
        }

        public double GetBMR()
        {
            throw new NotImplementedException();
        }

        public double GetTDEE()
        {
            throw new NotImplementedException();
        }
    }
}
