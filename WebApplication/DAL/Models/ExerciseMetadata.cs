using System;
using System.Collections.Generic;
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
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter calories burned per hour.")]
        [Range(0, 2000)]
        public double CaloriesBurned { get; set; }
    }
}
