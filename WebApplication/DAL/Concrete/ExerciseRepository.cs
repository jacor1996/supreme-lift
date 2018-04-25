using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Abstract;

namespace DAL.Concrete
{
    public class ExerciseRepository : IExerciseRepository
    {
        private SupremeLiftDbEntities _repository;

        public ExerciseRepository()
        {
            _repository = new SupremeLiftDbEntities();
        }

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
    }
}
