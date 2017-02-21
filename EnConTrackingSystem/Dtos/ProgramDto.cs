using System;
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
                if (this.StartDate == null && this.EndDate == null)
                {
                    return false;
                }

                var today = DateTime.Now;

                if (this.StartDate != null && this.EndDate == null)
                {
                    return DateTime.Compare((DateTime) this.StartDate, today) <= 0 ? true : false;
                }

                if (this.EndDate != null && this.StartDate == null)
                {
                    return DateTime.Compare((DateTime) this.EndDate, today) >= 0 ? true : false;
                }

                var endDate = this.EndDate;
                var startDate = this.StartDate;
                return startDate != null && endDate != null &&
                       (DateTime.Compare((DateTime) endDate, today) >= 0 &&
                        DateTime.Compare((DateTime) startDate, today) <= 0);
            }
        }

        public ICollection<ProjectDto> Projects { get; set; }
    }
}