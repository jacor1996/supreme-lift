using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IUserHelper
    {
        double GetBMI();

        string GetBMIState();

        double GetBMR();

        double GetTDEE();
    }
}
