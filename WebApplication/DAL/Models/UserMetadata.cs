using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UserMetadata
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your age.")]
        [Range(0, 110)]
        public int Age { get; set; }

        [Required(ErrorMessage = "Enter your weight in kg.")]
        [DisplayName("Weight [kg]")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Enter your height in cm.")]
        [DisplayName("Height [kg]")]
        public double Height { get; set; }

        [Required]
        public int Sex { get; set; }
    }
}
