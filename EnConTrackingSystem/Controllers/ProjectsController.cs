using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
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

        // GET: Projects
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
            return View();
        }
    }
}