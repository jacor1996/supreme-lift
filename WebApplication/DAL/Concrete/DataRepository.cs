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

        #region User methods

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
            User _user = FindUser(user.UserId);

            if (_user != null)
            {
                repo.Users.Remove(_user);
            }

            repo.SaveChanges();
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

        #endregion

        public IEnumerable<Exercise> GetExercises()
        {
            return repo.Exercises.OrderBy(e => e.ExerciseId);
        }

        public Exercise FindExercise(int id)
        {
            Exercise _exercise = repo.Exercises.Find(id);
            return _exercise;
        }

        public void AddExercise(Exercise exercise)
        {
            Exercise _exercise = FindExercise(exercise.ExerciseId);

            if (_exercise == null)
            {
                repo.Exercises.Add(exercise);
            }

            else
            {
                _exercise.Name = exercise.Name;
                _exercise.CaloriesBurned = exercise.CaloriesBurned;

                _exercise.Records = exercise.Records;
                _exercise.WorkoutExercises = exercise.WorkoutExercises;
            }

            repo.SaveChanges();
        }

        public void DeleteExercise(Exercise exercise)
        {
            Exercise _exercise = FindExercise(exercise.ExerciseId);

            if (_exercise != null)
            {
                repo.Exercises.Remove(_exercise);
            }

            repo.SaveChanges();
        }
    }
}
