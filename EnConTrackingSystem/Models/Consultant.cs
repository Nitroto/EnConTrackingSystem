using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnConTrackingSystem.Models
{
    public class Consultant
    {
        public string Id { get; set; }

        [StringLength(255)]
        [Required]
        [Display(Name = "Consultant Name")]
        public string Name { get; set; }

        [Display(Name = "Consultant Phone")]
        public string Phone { get; set; }

        [Display(Name = "Consultant Email")]
        public string Email { get; set; }

        public IEnumerable<Project> Projects { get; set; }
    }
}