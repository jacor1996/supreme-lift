﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IUserRepository
    {
        ICollection<User> Get();

        User Find(int id);

        void Add(User user);

        void Delete(User user);
    }
}
