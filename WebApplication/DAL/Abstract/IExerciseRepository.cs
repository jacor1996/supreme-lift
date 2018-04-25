using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IExerciseRepository
    {
        IEnumerable<Exercise> GetExercises();

        Exercise FindExercise(int id);

        void AddExercise(Exercise exercise);

        void DeleteExercise(Exercise exercise);
    }
}
