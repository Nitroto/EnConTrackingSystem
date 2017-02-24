using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnConTrackingSystem.Models
{
    public class Client
    {
        public Client()
        {
            this.Projects = new List<Project>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        [Display(Name = "Client Name")]
        public string Name { get; set; }

        [Display(Name = "Client Phone")]
        [StringLength(20)]
        public string Phone { get; set; }

        [Display(Name = "Client Email")]
        [StringLength(30)]
        public string Email { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}