﻿using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using EnConTrackingSystem.Models;
using EnConTrackingSystem.ViewModels;
using EnConTrackingSystem.Toast;

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

        [Authorize(Roles = RoleName.Administrator)]
        public ViewResult New()
        {
            var viewModel = new ProgramFormViewModel();
            return View("ProgramForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Save(Program program)
        {
            if (!this.ModelState.IsValid)
            {
                var viewModel = new ProgramFormViewModel(program);

                return View("ProgramForm", viewModel);
            }

            var message = "";
            if (program.Id == 0)
            {
                this._context.Programs.Add(program);
                message = "created";
            }
            else
            {
                var programInDb = this._context.Programs.Single(p => p.Id == program.Id);

                programInDb.Name = program.Name;
                programInDb.StartDate = program.StartDate;
                programInDb.EndDate = program.EndDate;
                message = "edited";
            }
            this._context.SaveChanges();
            this.AddToastMessage("Congratulations", $"Program {program.Name} {message} successfully!", ToastType.Success);

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
        [Authorize(Roles = RoleName.Administrator)]
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
        [Authorize(Roles = RoleName.Administrator)]
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
        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult DeleteConfirmed(int id)
        {
            var program = this._context.Programs.Include(p => p.Projects).FirstOrDefault(p => p.Id == id);

            if (program == null)
            {
                return HttpNotFound();
            }

            foreach (var project in program.Projects)
            {
                project.ProgramId = Defaults.ProgramId;
            }

            this._context.Programs.Remove(program);
            this._context.SaveChanges();
            this.AddToastMessage("Congratulations", $"Program {program.Name} deleted successfully!", ToastType.Warning);

            return RedirectToAction("Index", "Programs");
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }
    }
}