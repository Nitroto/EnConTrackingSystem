using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using EnConTrackingSystem.Dtos;
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

        //GET /api/programs
        public IHttpActionResult GetPrograms(string query = null)
        {
            var programsQuery = this._context.Programs.Include(p => p.Projects);

            if (!String.IsNullOrWhiteSpace(query))
            {
                programsQuery = programsQuery.Where(p => p.Name.Contains(query));
            }

            var programsDto = programsQuery.ToList().Select(Mapper.Map<Program, ProgramDto>);

            return Ok(programsDto);
        }


        //GET /api/programs/{id}
        public IHttpActionResult GetProgram(int id)
        {
            var program = this._context.Programs.FirstOrDefault(p => p.Id == id);

            if (program == null)
            {
                return NotFound();
            }

            var programDto = Mapper.Map<Program, ProgramDto>(program);
            return Ok(programDto);
        }
    }
}