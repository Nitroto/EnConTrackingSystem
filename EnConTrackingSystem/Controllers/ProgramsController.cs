using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            return View();
        }


        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }
    }
}