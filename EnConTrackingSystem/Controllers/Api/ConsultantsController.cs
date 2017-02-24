using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using EnConTrackingSystem.Dtos;
using EnConTrackingSystem.Models;

namespace EnConTrackingSystem.Controllers.Api
{
    public class ConsultantsController : ApiController
    {
        private ApplicationDbContext _context;

        public ConsultantsController()
        {
            this._context = new ApplicationDbContext();
        }

        //GET /api/consultants
        public IHttpActionResult GetConsultants(string query = null)
        {
            var consultantsQuery = this._context.Consultants.AsQueryable();

            if (!String.IsNullOrWhiteSpace(query))
            {
                consultantsQuery = consultantsQuery.Where(c => c.Name.Contains(query));
            }

            var consultantsDto = consultantsQuery.ToList().Select(Mapper.Map<Consultant, ConsultantDto>);

            return Ok(consultantsDto);
        }


        //GET /api/consultants/{id}
        public IHttpActionResult GetConsultant(int id)
        {
            var consultant = this._context.Consultants.FirstOrDefault(c => c.Id == id);

            if (consultant == null)
            {
                return NotFound();
            }

            var consultantsDto = Mapper.Map<Consultant, ConsultantDto>(consultant);
            return Ok(consultantsDto);
        }

        //POST /api/consultants
        [HttpPost]
        public IHttpActionResult CreateConsultant(ConsultantDto consultantDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var consultant = Mapper.Map<ConsultantDto, Consultant>(consultantDto);
            this._context.Consultants.Add(consultant);
            this._context.SaveChanges();
            consultantDto.Id = consultant.Id;

            return Created(new Uri(Request.RequestUri + "/" + consultant.Id), consultantDto);
        }

        //PUT /api/consultants/{id}
        [HttpPut]
        public IHttpActionResult UpdateConsultant(int id, ConsultantDto consultantDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var consultantInDb = this._context.Consultants.SingleOrDefault(c => c.Id == id);

            if (consultantInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(consultantDto, consultantInDb);

            this._context.SaveChanges();

            return Ok();
        }

        //DELETE /api/consultants/{id}
        [HttpDelete]
        public IHttpActionResult DeleteConsultant(int id)
        {
            var consultanttInDb = this._context.Consultants.Include(c => c.Projects).SingleOrDefault(c => c.Id == id);

            if (consultanttInDb == null)
            {
                return NotFound();
            }

            //Move all project to default consultant (No Consultant)
            foreach (var project in consultanttInDb.Projects)
            {
                project.ConsultantId = Defaults.ConsultantId;
            }

            this._context.Consultants.Remove(consultanttInDb);
            this._context.SaveChanges();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }
    }
}