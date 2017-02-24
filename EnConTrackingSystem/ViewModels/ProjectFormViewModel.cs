using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EnConTrackingSystem.Models;
using System.Linq;
using System.Web.Mvc;

namespace EnConTrackingSystem.ViewModels
{
    public class ProjectFormViewModel
    {
        private ApplicationDbContext _context;

        public ProjectFormViewModel(int programId)
        {
            this.Id = 0;
            this.ClientId = Defaults.ClientId;
            this.ConsultantId = Defaults.ConsultantId;
            this.ProgramId = programId;
            this._context = new ApplicationDbContext();
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
            this._context = new ApplicationDbContext();
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

        [Display(Name = "Consultant")]
        public int ConsultantId { get; set; }

        public string Title => this.Id != 0
            ? App_GlobalResources.Lang.TitleProjectFormEdit
            : App_GlobalResources.Lang.TitleProjectFormNew;

        private List<Autocomplete> _GetClients(string query)
        {
            var clients = new List<Autocomplete>();

            try
            {
                var results =
                    this._context.Clients.Where(c => (c.Name).Contains(query)).OrderBy(c => c.Name).Take(10)
                        .ToList();
                foreach (var r in results)
                {
                    Autocomplete client = new Autocomplete();

                    client.Name = r.Name;
                    client.Id = r.Id;

                    clients.Add(client);
                }
            }
            catch
            {
                throw;
            }

            return clients;
        }

        public JsonResult GetClients(string query)
        {
            return NotImplementedException;
            //return Json(this._GetClients(query),JsonRequestBehavior.AllowGet);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    this._context.Dispose();
        //}
    }
}