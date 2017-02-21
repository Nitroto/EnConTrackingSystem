using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnConTrackingSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace EnConTrackingSystem.ViewModels
{
    public class ProgramFormViewModel
    {
        public ProgramFormViewModel()
        {
            this.Id = 0;
            this.Projects = new List<Project>();
        }

        public ProgramFormViewModel(Program program)
        {
            this.Id = program.Id;
            this.Name = program.Name;
            this.StartDate = program.StartDate;
            this.EndDate = program.EndDate;
            this.IsActive = program.IsActive;
            this.Projects = program.Projects;
        }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter program's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Project> Projects { get; set; }

        public string Title => Id != 0
            ? App_GlobalResources.Lang.TitleProgramFormEdit
            : App_GlobalResources.Lang.TitleProgramFormNew;
    }
}