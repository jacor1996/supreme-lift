using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class User
    {
        public User(string name) : base()
        {
            Name = name;
            Age = 1;
            Height = 1.83;
            Weight = 86;
            Sex = 0;
        }
    }
}
