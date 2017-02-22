using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using EnConTrackingSystem.Models;
using EnConTrackingSystem.ViewModels;

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

        //[Authorize(Roles = RoleName.CanManagePrograms)]
        public ViewResult New()
        {
            var viewModel = new ProgramFormViewModel();
            return View("ProgramForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Program program)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProgramFormViewModel(program);

                return View("ProgramForm", viewModel);
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

        // PUT: /Program/Edit/{id}
        public ActionResult Edit(int id)
        {
            var program = this._context.Programs.Include(p => p.Projects).SingleOrDefault(p => p.Id == id);
            if (program == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ProgramFormViewModel(program);

            return View("ProgramForm", viewModel);
        }

        // GET: /Program/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var program = this._context.Programs.Include(p => p.Projects).FirstOrDefault(p => p.Id == id);

            if (program == null)
            {
                return HttpNotFound();
            }

            return View(program);
        }

        // POST: /Program/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var program = this._context.Programs.Include(p => p.Projects).FirstOrDefault(p => p.Id == id);

            if (program == null)
            {
                return HttpNotFound();
            }

            foreach (var project in program.Projects)
            {
                project.ProgramId = Program.DefaultProgramId;
            }

            this._context.Programs.Remove(program);
            this._context.SaveChanges();

            return RedirectToAction("Index", "Programs");
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }
    }
}