﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnConTrackingSystem.Dtos
{
    public class ProgramDto
    {
        public ProgramDto()
        {
            this.Projects = new List<ProjectDto>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter program's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

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

        public ICollection<ProjectDto> Projects { get; set; }
    }
}