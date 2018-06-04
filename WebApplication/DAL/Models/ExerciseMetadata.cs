using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class ExerciseMetadata
    {
        public int ExerciseId { get; set; }

        [Required(ErrorMessage = "Enter exercise name.")]
        [DisplayName("Exercise Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter calories burned per 25 reps (approximately 20 minutes of exercise).")]
        [Range(0, 2000)]
        [DisplayName("Calories burned")]
        public double CaloriesBurned { get; set; }
    }
}
