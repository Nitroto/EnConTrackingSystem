using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EnConTrackingSystem.Migrations;

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

        public bool IsActive
        {
            get
            {
                if (this.StartDate == null && this.EndDate == null)
                {
                    return false;
                }

                var today = DateTime.Now;

                if (this.StartDate != null && this.EndDate == null)
                {
                    return DateTime.Compare((DateTime)this.StartDate, today) <= 0 ? true : false;
                }

                if (this.EndDate != null && this.StartDate == null)
                {
                    return DateTime.Compare((DateTime)this.EndDate, today) >= 0 ? true : false;
                }

                return DateTime.Compare((DateTime)this.EndDate, today) >= 0 &&
                       DateTime.Compare((DateTime)this.StartDate, today) <= 0;
            }
        }

        public ICollection<Project> Projects { get; set; }
    }
}