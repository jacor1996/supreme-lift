using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Abstract;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private SupremeLiftDbEntities _repository;

        public UserRepository()
        {
            _repository = new SupremeLiftDbEntities();
        }

        public void AddUser(User user)
        {
            User _user = FindUser(user.UserId);

            if (_user == null)
            {
                _repository.Users.Add(user);
            }

            else
            {
                _user.Name = user.Name;
                _user.Height = user.Height;
                _user.Weight = user.Weight;
                _user.Sex = user.Sex;
                _user.Age = user.Age;

                _user.Records = user.Records;
                _user.Workouts = user.Workouts;
            }

            _repository.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            User _user = FindUser(user.UserId);

            if (_user != null)
            {
                _repository.Users.Remove(_user);
            }

            _repository.SaveChanges();
        }

        public User FindUser(int id)
        {
            User user = _repository.Users.Find(id);
            return user;
        }

        public User FindUser(string userName)
        {
            return _repository.Users.FirstOrDefault(u => u.Name.Equals(userName));
        }

        public IEnumerable<User> GetUsers()
        {
            return _repository.Users;
        }

    }
}
