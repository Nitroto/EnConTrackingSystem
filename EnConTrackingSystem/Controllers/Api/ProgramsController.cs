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
            var program = this._context.Programs.Include(p => p.Projects).FirstOrDefault(p => p.Id == id);

            if (program == null)
            {
                return NotFound();
            }

            var programDto = Mapper.Map<Program, ProgramDto>(program);
            return Ok(programDto);
        }

        //POST /api/programs
        [HttpPost]
        public IHttpActionResult CreateProgram(ProgramDto programDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var program = Mapper.Map<ProgramDto, Program>(programDto);
            this._context.Programs.Add(program);
            this._context.SaveChanges();
            programDto.Id = program.Id;

            return Created(new Uri(Request.RequestUri + "/" + program.Id), programDto);
        }

        //PUT /api/programs/{id}
        [HttpPut]
        public IHttpActionResult UpdateProgram(int id, ProgramDto programDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var programInDb = this._context.Programs.SingleOrDefault(p => p.Id == id);

            if (programInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(programDto, programInDb);

            this._context.SaveChanges();

            return Ok();
        }

        //DELETE /api/programs/{id}
        [HttpDelete]
        public IHttpActionResult DeleteProgram(int id)
        {
            var programInDb = this._context.Programs.Include(p => p.Projects).SingleOrDefault(p => p.Id == id);

            if (programInDb == null)
            {
                return NotFound();
            }

            //Move all project to default program (Regular Audits)
            foreach (var project in programInDb.Projects)
            {
                project.ProgramId = 1;
            }

            this._context.Programs.Remove(programInDb);
            this._context.SaveChanges();
            return Ok();
        }
    }
}