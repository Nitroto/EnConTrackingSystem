using System.ComponentModel.DataAnnotations;

namespace EnConTrackingSystem.Models
{
    public class Project
    {
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
        public Program Program { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int ConsultantId { get; set; }
        public Consultant Consultant { get; set; }
    }
}