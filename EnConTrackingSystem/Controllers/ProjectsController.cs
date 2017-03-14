using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EnConTrackingSystem.Models;
using EnConTrackingSystem.Toast;
using EnConTrackingSystem.ViewModels;

namespace EnConTrackingSystem.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationDbContext _context;

        public ProjectsController()
        {
            this._context = new ApplicationDbContext();
        }

        //Not used
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var project = this._context.Projects
                .Include(p => p.Client)
                .Include(p => p.Consultant)
                .Include(p => p.Program).SingleOrDefault(p => p.Id == id);

            if (project == null)
            {
                return HttpNotFound();
            }

            return View(project);
        }

        public ActionResult New(int programId)
        {
            var defaultClientName = this._context.Clients.FirstOrDefault(c => c.Id == Defaults.ClientId).Name;
            var defaultConsultantName = this._context.Consultants.FirstOrDefault(c => c.Id == Defaults.ConsultantId).Name;
            var viewModel = new ProjectFormViewModel(programId, defaultClientName, defaultConsultantName);
            return View("ProjectForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Project project)
        {
            if (!this.ModelState.IsValid)
            {
                var viewModel = new ProjectFormViewModel(project);

                return View("ProjectForm", viewModel);
            }

            var message = "";
            if (project.Id == 0)
            {
                this._context.Projects.Add(project);
                message = "created";
            }
            else
            {
                var projectInDb = this._context.Projects.Single(p => p.Id == project.Id);

                projectInDb.Name = project.Name;
                projectInDb.ProjectInvestment = project.ProjectInvestment;
                projectInDb.ProjectPrice = project.ProjectPrice;
                projectInDb.ProjectInfo = project.ProjectInfo;
                message = "edited";
            }
            this._context.SaveChanges();
            this.AddToastMessage("Congratulations", $"Program {project.Name} {message} successfully!", ToastType.Success);

            return RedirectToAction("Details", "Programs", new { id = project.ProgramId });
        }

        public ActionResult Edit(int id)
        {
            var project = this._context.Projects.Include(p => p.Client).Include(p => p.Consultant).SingleOrDefault(p => p.Id == id);
            if (project == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ProjectFormViewModel(project);

            return View("ProjectForm", viewModel);
        }

        //Not used
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var project = this._context.Projects.Find(id);

            if (project == null)
            {
                return HttpNotFound();
            }

            return PartialView(project);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var project = this._context.Projects.Find(id);

            if (project == null)
            {
                return HttpNotFound();
            }

            this._context.Projects.Remove(project);
            this._context.SaveChanges();
            this.AddToastMessage("Congratulations", $"Program {project.Name} deleted successfully!", ToastType.Warning);

            return RedirectToAction("Details", "Programs", new { id = project.ProgramId });
        }

        private IEnumerable<Autocomplete> _GetClients(string query)
        {
            var clients = new List<Autocomplete>();

            try
            {
                var results =
                    this._context.Clients.Where(c => (c.Name).Contains(query))
                        .OrderBy(c => c.Name)
                        .Take(10)
                        .ToList();
                clients.AddRange(results.Select(r => new Autocomplete
                {
                    Name = r.Name,
                    Id = r.Id
                }));
            }
            catch (EntityCommandCompilationException eceex)
            {
                if (eceex.InnerException != null)
                {
                    throw eceex.InnerException;
                }

                throw;
            }
            catch
            {
                throw;
            }

            return clients;
        }

        public ActionResult GetClients(string query)
        {
            return Json(this._GetClients(query), JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<Autocomplete> _GetConsultants(string query)
        {
            var consultants = new List<Autocomplete>();

            try
            {
                var results =
                    this._context.Consultants.Where(c => (c.Name).Contains(query))
                        .OrderBy(c => c.Name)
                        .Take(10)
                        .ToList();
                consultants.AddRange(results.Select(r => new Autocomplete
                {
                    Name = r.Name,
                    Id = r.Id
                }));
            }
            catch (EntityCommandCompilationException eceex)
            {
                if (eceex.InnerException != null)
                {
                    throw eceex.InnerException;
                }

                throw;
            }
            catch
            {
                throw;
            }

            return consultants;
        }

        public ActionResult GetConsultants(string query)
        {
            return Json(this._GetConsultants(query), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }
    }
}