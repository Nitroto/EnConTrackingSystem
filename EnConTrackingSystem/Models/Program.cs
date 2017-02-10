using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnConTrackingSystem.Models
{
    public class Program
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter program's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<Project> Projects { get; set; }
    }
}