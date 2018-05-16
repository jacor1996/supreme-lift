using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
            return _user.Weight / (_user.Height * _user.Height);
        }

        public string GetBMIState()
        {
            double bmi = GetBMI();
            string result = String.Empty;

            if (bmi < 18.5)
            {
                result = "You are underweight.";
            }

            if (bmi >= 18.5 && bmi < 25)
            {
                result = "You have normal weight.";
            }

            if (bmi >= 25)
            {
                result = "You are overweight.";
            }

            return result;
        }

        public double GetBMR()
        {
            double weightCoefficcent = 10 * _user.Weight; //in kg
            double heightCoefficient = 6.25 * _user.Height * 100; //in cm
            double ageCoefficient = 5 * _user.Age; //in years
            int s = (_user.Age == 0) ? 5 : -161; //5 for male, -161 for female

            return weightCoefficcent + heightCoefficient + ageCoefficient + s; //kcal per day
        }

        public double GetTDEE()
        {
            double genderCoefficient = (_user.Age == 0) ? 1.5 : 1.25;

            return GetBMR() * genderCoefficient;
        }
    }
}
