using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using EnConTrackingSystem.Models;
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
            var viewModel = new ProjectFormViewModel(programId);
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

            if (project.Id == 0)
            {
                this._context.Projects.Add(project);
            }
            else
            {
                var projectInDb = this._context.Projects.Single(p => p.Id == project.Id);

                projectInDb.Name = project.Name;
                projectInDb.ProjectInvestment = project.ProjectInvestment;
                projectInDb.ProjectPrice = project.ProjectPrice;
                projectInDb.ProjectInfo = project.ProjectInfo;
            }
            this._context.SaveChanges();

            return RedirectToAction("Details", "Programs", new { id = project.ProgramId });
        }

        public ActionResult Edit(int id)
        {
            var project = this._context.Projects.SingleOrDefault(p => p.Id == id);
            if (project == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ProjectFormViewModel(project);

            return View("ProjectForm", viewModel);
        }

        public ActionResult Delete(int? id)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            throw new System.NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }
    }
}