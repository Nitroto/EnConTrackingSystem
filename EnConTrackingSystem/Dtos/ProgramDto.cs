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

        public bool IsActive { get; set; }

        public ICollection<ProjectDto> Projects { get; set; }
    }
}