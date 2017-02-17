using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnConTrackingSystem.Dtos
{
    public class ClientDto
    {
        public ClientDto()
        {
            this.Projects = new List<ProjectDto>();
        }
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        public ICollection<ProjectDto> Projects { get; set; }
    }
}