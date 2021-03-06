﻿using System;
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

        public WorkoutRepository(SupremeLiftDbEntities repository)
        {
            //_repository = new SupremeLiftDbEntities();
            _repository = repository;
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
            return GetWorkouts().Where(u => u.Fk_UserId == user.UserId);
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
                _workout.WorkoutId = workout.WorkoutId;
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
                WorkoutExercise[] workoutExercisesCopy = new WorkoutExercise[workoutToDelete.WorkoutExercises.Count];
                workoutToDelete.WorkoutExercises.CopyTo(workoutExercisesCopy, 0);

                foreach (WorkoutExercise w in workoutExercisesCopy)
                {
                    _repository.WorkoutExercises.Remove(w);
                }

                workoutToDelete.Fk_UserId = null;

                _repository.Workouts.Remove(workout);
                _repository.SaveChanges();
            }
        }

        public User FindUser(string userName)
        {
            return _repository.Users.FirstOrDefault(u => u.Name == userName);
        }
    }
}
