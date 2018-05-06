using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IUserHelper
    {
        double GetBMI();

        double GetBMR();

        double GetTDEE();
    }
}
