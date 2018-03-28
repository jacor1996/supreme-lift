using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class DataRepository : IDataRepository
    {
        private SupremeLiftDbEntities repo;

        public DataRepository()
        {
            repo = new SupremeLiftDbEntities();
        }

        public void AddUser(User user)
        {
            repo.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public User FindUser(int id)
        {
            throw new NotImplementedException();
        }

        public User FindUser(string name)
        {
            return repo.Users.Where(u => u.Name == name).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return repo.Users;
        }

        public IEnumerable<Exercise> GetExercises()
        {
            return repo.Exercises;
        }
    }
}
