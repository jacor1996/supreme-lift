using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class WorkoutExerciseMetadata
    {
        [Required(ErrorMessage = "Specify number of sets.")]
        [Range(1, 100)]
        public int Sets { get; set; }

        [Required(ErrorMessage = "Specify number of repetitions.")]
        [Range(1, 100)]
        public int Reps { get; set; }

        [DisplayName("Exercise")]
        public Nullable<int> Fk_ExerciseId { get; set; }

        [DisplayName("Workout")]
        public Nullable<int> Fk_WorkoutId { get; set; }
    }
}
