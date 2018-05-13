using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IWorkoutExerciseRepository
    {
        IEnumerable<WorkoutExercise> GetAll();

        void SaveWorkoutExercise(WorkoutExercise workoutExercise);

        void DeleteWorkoutExercise(WorkoutExercise workoutExercise);

        WorkoutExercise FindWorkoutExercise(int id);
    }
}
