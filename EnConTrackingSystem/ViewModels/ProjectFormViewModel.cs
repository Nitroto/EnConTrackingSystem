using System.ComponentModel.DataAnnotations;
using EnConTrackingSystem.Models;

namespace EnConTrackingSystem.ViewModels
{
    public class ProjectFormViewModel
    {
        public ProjectFormViewModel(int programId)
        {
            this.Id = 0;
            this.ProgramId = programId;
        }

        public ProjectFormViewModel(Project project)
        {
            this.Id = project.Id;
            this.Name = project.Name;
            this.ProjectInvestment = project.ProjectInvestment;
            this.ProjectPrice = project.ProjectPrice;
            this.ProjectInfo = project.ProjectInfo;
            this.ProgramId = project.ProgramId;
            this.ClientId = project.ClientId;
            this.ConsultantId = project.ConsultantId;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter project's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [RegularExpression(@"^\d*[\.|,]?\d*$", ErrorMessage = "Please enter valid investment")]
        [Display(Name = "Investment")]
        public decimal? ProjectInvestment { get; set; }

        [RegularExpression(@"^\d*[\.|,]?\d*$", ErrorMessage = "Please enter valid price")]
        [Display(Name = "Price")]
        public decimal? ProjectPrice { get; set; }

        [Display(Name = "Info")]
        public string ProjectInfo { get; set; }

        public int ProgramId { get; set; }

        public int ClientId { get; set; }

        public int ConsultantId { get; set; }

        public string Title => this.Id != 0
            ? App_GlobalResources.Lang.TitleProjectFormEdit
            : App_GlobalResources.Lang.TitleProjectFormNew;
    }
}