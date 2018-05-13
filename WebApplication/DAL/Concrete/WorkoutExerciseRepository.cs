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
            throw new NotImplementedException();
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
                
            }

            _entities.SaveChanges();
        }

        public void DeleteWorkoutExercise(WorkoutExercise workoutExercise)
        {
            throw new NotImplementedException();
        }

        public WorkoutExercise FindWorkoutExercise(int id)
        {
            return _entities.WorkoutExercises.FirstOrDefault(w => w.WorkoutExerciseId == id);
        }
    }
}
