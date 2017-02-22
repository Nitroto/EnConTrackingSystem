using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnConTrackingSystem.Models
{
    public class Program
    {
        public static int DefaultProgramId = 1;
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
                var endDate = this.EndDate;
                var startDate = this.StartDate;

                if (startDate == null && endDate == null)
                {
                    return false;
                }

                var today = DateTime.Now;


                if (startDate != null && endDate == null)
                {
                    return DateTime.Compare((DateTime)startDate, today) <= 0 ? true : false;
                }

                //START FIX: Problem with IsActive when end date is today
                if (endDate.Value.TimeOfDay == new DateTime().TimeOfDay)
                {
                    endDate = endDate.Value.AddHours(23).AddMinutes(59).AddSeconds(59);
                }
                // END FIX

                if (startDate == null)
                {
                    return DateTime.Compare((DateTime)endDate, today) >= 0 ? true : false;
                }


                return DateTime.Compare((DateTime)endDate, today) >= 0 &&
                       DateTime.Compare((DateTime)startDate, today) <= 0;
            }
        }

        public ICollection<Project> Projects { get; set; }
    }
}