using System.ComponentModel.DataAnnotations;

namespace EnConTrackingSystem.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter project's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public decimal? ProjectCost { get; set; }

        public decimal? ProjectPrice { get; set; }

        [Display(Name = "Info")]
        public string ProjectInfo { get; set; }

        public Program Program { get; set; }

        public Client Client { get; set; }

        public Consultant Consultant { get; set; }
    }
}