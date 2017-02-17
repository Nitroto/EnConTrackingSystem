﻿using System.ComponentModel.DataAnnotations;

namespace EnConTrackingSystem.Dtos
{
    public class ProjectDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter project's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public decimal? ProjectCost { get; set; }

        public decimal? ProjectPrice { get; set; }

        public string ProjectInfo { get; set; }

        public int ProgramId { get; set; }
        public ProgramDto Program { get; set; }

        public int ClientId { get; set; }
        public ClientDto Client { get; set; }

        public int ConsultantId { get; set; }
        public ConsultantDto Consultant { get; set; }
    }
}