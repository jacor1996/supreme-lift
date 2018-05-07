using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Abstract;

namespace DAL.Concrete
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private SupremeLiftDbEntities _repository;

        public WorkoutRepository()
        {
            _repository = new SupremeLiftDbEntities();
        }

        public IEnumerable<Workout> GetWorkouts()
        {
            return _repository.Workouts
                .Include(u => u.User)
                .Include(w => w.WorkoutExercises);
        }

        public IEnumerable<Workout> GetWorkouts(User user)
        {
            //Change to User.Name if it does not work
            return GetWorkouts().Where(u => u.User.UserId == user.UserId);
        }

        public Workout FindWorkout(int id)
        {
            return _repository.Workouts.FirstOrDefault(w => w.WorkoutId == id);
        }

        public void AddWorkout(Workout workout)
        {
            Workout _workout = FindWorkout(workout.WorkoutId);

            if (_workout == null)
            {
                _repository.Workouts.Add(workout);
            }

            else
            {
                _workout.Name = workout.Name;
                _workout.User = workout.User;
                _workout.WorkoutExercises = workout.WorkoutExercises;
                _workout.Fk_UserId = workout.Fk_UserId;
            }

            _repository.SaveChanges();
        }

        public void DeleteWorkout(Workout workout)
        {
            Workout workoutToDelete = FindWorkout(workout.WorkoutId);

            if (workoutToDelete != null)
            {
                _repository.Workouts.Remove(workout);
                _repository.SaveChanges();
            }
        }
    }
}
