using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace WebApplication.Models
{
    public class WorkoutViewModel
    {
        public Workout Workout { get; set; }

        public IEnumerable<WorkoutExercise> WorkoutExercises { get; set; }
    }
}