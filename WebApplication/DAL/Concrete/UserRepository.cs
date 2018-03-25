using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private SupremeLiftDbEntities repo;

        public UserRepository()
        {
            repo = new SupremeLiftDbEntities();
        }

        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public User Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Get()
        {
            return repo.Users;
        }

        public IEnumerable<Exercise> GetExercises()
        {
            return repo.Exercises;
        }
    }
}
