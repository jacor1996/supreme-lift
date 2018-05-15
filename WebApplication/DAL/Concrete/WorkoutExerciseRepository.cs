using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Abstract;

namespace DAL.Concrete
{
    public class WorkoutExerciseRepository : IWorkoutExerciseRepository
    {
        private SupremeLiftDbEntities _entities;

        public WorkoutExerciseRepository(SupremeLiftDbEntities entities)
        {
            _entities = entities;
        }

        public IEnumerable<WorkoutExercise> GetAll()
        {
            return _entities.WorkoutExercises;
        }

        public void SaveWorkoutExercise(WorkoutExercise workoutExercise)
        {
            WorkoutExercise _workoutExercise = FindWorkoutExercise(workoutExercise.WorkoutExerciseId);

            if (_workoutExercise == null)
            {
                _entities.WorkoutExercises.Add(workoutExercise);
            }

            else // edit data
            {
                _workoutExercise.Workout = workoutExercise.Workout;
                _workoutExercise.Exercise = workoutExercise.Exercise;
                _workoutExercise.Fk_ExerciseId = workoutExercise.Fk_ExerciseId;
                _workoutExercise.Fk_WorkoutId = workoutExercise.Fk_WorkoutId;
                _workoutExercise.Reps = workoutExercise.Reps;
                _workoutExercise.Sets = workoutExercise.Sets;
                _workoutExercise.WorkoutExerciseId = workoutExercise.WorkoutExerciseId;

            }

            _entities.SaveChanges();
        }

        public void DeleteWorkoutExercise(WorkoutExercise workoutExercise)
        {
            WorkoutExercise workoutExerciseToDelete = FindWorkoutExercise(workoutExercise.WorkoutExerciseId);

            if (workoutExerciseToDelete != null)
            {
                _entities.WorkoutExercises.Remove(workoutExercise);
                _entities.SaveChanges();
            }
        }

        public WorkoutExercise FindWorkoutExercise(int id)
        {
            return _entities.WorkoutExercises.FirstOrDefault(w => w.WorkoutExerciseId == id);
        }
    }
}
