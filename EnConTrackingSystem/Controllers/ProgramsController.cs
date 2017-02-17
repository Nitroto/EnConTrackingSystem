using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using EnConTrackingSystem.Models;

namespace EnConTrackingSystem.Controllers
{
    public class ProgramsController : Controller
    {
        private ApplicationDbContext _context;

        public ProgramsController()
        {
            this._context = new ApplicationDbContext();
        }

        // GET: Programs
        public ActionResult Index()
        {
            return View("List");
        }

        public ViewResult New()
        {
            return View("ProgramForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Program program)
        {
            if (!ModelState.IsValid)
            {
                // TODO
            }

            if (program.Id == 0)
            {
                this._context.Programs.Add(program);
            }
            else
            {
                var programInDb = this._context.Programs.Single(p => p.Id == program.Id);

                programInDb.Name = program.Name;
                programInDb.StartDate = program.StartDate;
                programInDb.EndDate = program.EndDate;
            }
            this._context.SaveChanges();

            return RedirectToAction("Index", "Programs");
        }

        public ActionResult Details(int id)
        {
            var program = this._context.Programs.Include(p => p.Projects).SingleOrDefault(p => p.Id == id);

            if (program == null)
            {
                return HttpNotFound();
            }

            return View("ListProjects", program);
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }
    }
}