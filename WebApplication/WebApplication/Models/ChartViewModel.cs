using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DAL;

namespace WebApplication.Models
{
    public class ChartViewModel
    {
        [Required(ErrorMessage = "Enter amount of data from 1 to 100")]
        [Range(1, 100)]
        [DisplayName("Number of last records")]
        public int AmountOfData { get; set; }

        public IEnumerable<Record> Records { get; set; }

        [Required]
        [DisplayName("Exercise")]
        public int ExerciseId { get; set; }

        public Exercise Exercise { get; set; }
    }
}