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
            User _user = FindUser(user.UserId);

            if (_user == null)
            {
                repo.Users.Add(user);
            }

            else
            {
                _user.Name = user.Name;
                _user.Height = user.Height;
                _user.Weight = user.Weight;
                _user.Sex = user.Sex;

                _user.Records = user.Records;
                _user.Workouts = user.Workouts;
            }
            
            repo.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public User FindUser(int id)
        {
            User user = repo.Users.Find(id);
            return user;
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
