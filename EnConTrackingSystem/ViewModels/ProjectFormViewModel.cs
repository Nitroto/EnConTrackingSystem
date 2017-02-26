using System.ComponentModel.DataAnnotations;
using EnConTrackingSystem.Migrations;
using EnConTrackingSystem.Models;

namespace EnConTrackingSystem.ViewModels
{
    public class ProjectFormViewModel
    {
        public ProjectFormViewModel(int programId, string clientName, string consultantName)
        {
            this.Id = 0;
            this.ProgramId = programId;
            this.ClientId = Defaults.ClientId;
            this.ClientName = clientName;
            this.ConsultantId = Defaults.ConsultantId;
            this.ConsultantName = consultantName;
        }

        public ProjectFormViewModel(Project project)
        {
            this.Id = project.Id;
            this.Name = project.Name;
            this.ProjectInvestment = project.ProjectInvestment;
            this.ProjectPrice = project.ProjectPrice;
            this.ProjectInfo = project.ProjectInfo;
            this.ProgramId = project.ProgramId;
            this.ClientId = project.Client.Id;
            this.ClientName = project.Client.Name;
            this.ConsultantId = project.Consultant.Id;
            this.ConsultantName = project.Consultant.Name;
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

        [Display(Name = "Program")]
        public int ProgramId { get; set; }

        [Display(Name = "Client")]
        public int ClientId { get; set; }

        public string ClientName { get; set; }

        [Display(Name = "Consultant")]
        public int ConsultantId { get; set; }

        public string ConsultantName { get; set; }

        public string Title => this.Id != 0
            ? App_GlobalResources.Lang.TitleProjectFormEdit
            : App_GlobalResources.Lang.TitleProjectFormNew;
    }
}