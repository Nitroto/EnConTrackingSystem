using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnConTrackingSystem.Models
{
    public class Program
    {
        public Program()
        {
            this.Projects = new List<Project>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter program's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}