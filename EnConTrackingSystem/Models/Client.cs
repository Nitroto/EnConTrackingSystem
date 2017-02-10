using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnConTrackingSystem.Models
{
    public class Client
    {
        public string Id { get; set; }

        [StringLength(255)]
        [Required]
        [Display(Name = "Client Name")]
        public string Name { get; set; }

        [Display(Name = "Client Phone")]
        public string Phone { get; set; }

        [Display(Name = "Client Email")]
        public string Email { get; set; }

        public IEnumerable<Project> Projects { get; set; }
    }
}