using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using EnConTrackingSystem.Models;

namespace EnConTrackingSystem.Controllers.Api
{
    public class ProgramsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProgramsController()
        {
            this._context = new ApplicationDbContext();
        }

        public IEnumerable<Program> GetPrograms(string query = null)
        {
            var programsQuery = this._context.Programs;

            if (!String.IsNullOrWhiteSpace(query))
            {
                //programsQuery = programsQuery.Where(p => p.Name.Contains(query));
            }

            return programsQuery.ToList();
        }
    }
}