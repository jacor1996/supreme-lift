using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class DataRepository : IDataRepository
    {
        private readonly SupremeLiftDbEntities _repository;

        public DataRepository()
        {
            _repository = new SupremeLiftDbEntities();
        }

        #region User methods

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

        #endregion

        #region Exercise methods

        public IEnumerable<Exercise> GetExercises()
        {
            return _repository.Exercises.OrderBy(e => e.ExerciseId);
        }

        public Exercise FindExercise(int id)
        {
            Exercise _exercise = _repository.Exercises.Find(id);
            return _exercise;
        }

        public void AddExercise(Exercise exercise)
        {
            Exercise _exercise = FindExercise(exercise.ExerciseId);

            if (_exercise == null)
            {
                _repository.Exercises.Add(exercise);
            }

            else
            {
                _exercise.Name = exercise.Name;
                _exercise.CaloriesBurned = exercise.CaloriesBurned;

                _exercise.Records = exercise.Records;
                _exercise.WorkoutExercises = exercise.WorkoutExercises;
            }

            _repository.SaveChanges();
        }

        public void DeleteExercise(Exercise exercise)
        {
            Exercise _exercise = FindExercise(exercise.ExerciseId);

            if (_exercise != null)
            {
                _repository.Exercises.Remove(_exercise);
            }

            _repository.SaveChanges();
        }

        #endregion


        #region Record methods

        public IEnumerable<Record> GetRecords()
        {
            return _repository.Records
                .Include(u => u.User)
                .Include(e => e.Exercise);
        }

        public IEnumerable<Record> GetRecords(User user)
        {
            return GetRecords().Where(u => u.User.Name == user.Name);
        }

        public Record FindRecord(int id)
        {
            return GetRecords().FirstOrDefault(r => r.RecordId == id);
        }

        public void AddRecord(Record record)
        {
            Record recordEntity = FindRecord(record.RecordId);

            if (recordEntity == null)
            {
                _repository.Records.Add(record);
            }

            else
            {
                recordEntity.User = record.User;
                recordEntity.Date = record.Date;
                recordEntity.Exercise = record.Exercise;
                recordEntity.Fk_ExerciseId = record.Fk_ExerciseId;
                recordEntity.Fk_UserId = record.Fk_UserId;
                recordEntity.RecordId = record.RecordId;
                recordEntity.WeightLifted = record.WeightLifted;
            }

            _repository.SaveChanges();
        }

        public void DeleteRecord(Record record)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
