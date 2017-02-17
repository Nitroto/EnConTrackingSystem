using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using EnConTrackingSystem.Models;

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

        public ActionResult New()
        {
            return View("ProjectForm");
        }

        public ActionResult Save()
        {
            throw new System.NotImplementedException();
        }

        public ActionResult Edit()
        {
            throw new System.NotImplementedException();
        }

        public ActionResult Delete()
        {
            throw new System.NotImplementedException();
        }
    }
}