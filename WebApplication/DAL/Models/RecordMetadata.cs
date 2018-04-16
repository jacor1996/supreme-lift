﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class RecordMetadata
    {
        [Required(ErrorMessage = "Specify how many weight you have lifted (in kg).")]
        [Display(Name = "Lifted weight")]
        [Range(0, 9999)]
        public double WeightLifted { get; set; }

        [Display(Name = "Exercise")]
        public Nullable<int> Fk_ExerciseId { get; set; }
    }
}
