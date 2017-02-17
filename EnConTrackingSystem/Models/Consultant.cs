using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnConTrackingSystem.Models
{
    public class Consultant
    {
        public Consultant()
        {
            this.Projects = new List<Project>();
        }
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        [Display(Name = "Consultant Name")]
        public string Name { get; set; }

        [Display(Name = "Consultant Phone")]
        [StringLength(20)]
        public string Phone { get; set; }

        [Display(Name = "Consultant Email")]
        [StringLength(30)]
        public string Email { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}