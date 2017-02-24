using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using EnConTrackingSystem.Dtos;
using EnConTrackingSystem.Models;

namespace EnConTrackingSystem.Controllers.Api
{
    public class ProjectsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProjectsController()
        {
            this._context = new ApplicationDbContext();
        }

        //GET /api/projects
        public IHttpActionResult GetProjects(string query = null)
        {
            var projectsQuery = this._context.Projects.Include(p => p.Client).Include(p => p.Consultant);

            if (!String.IsNullOrWhiteSpace(query))
            {
                projectsQuery = projectsQuery.Where(p => p.Name.Contains(query));
            }

            var projectsDto = projectsQuery.ToList().Select(Mapper.Map<Project, ProjectDto>);

            return Ok(projectsDto);
        }

        //GET /api/projects/{id}
        public IHttpActionResult GetProject(int id)
        {
            var project = this._context.Projects.FirstOrDefault(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            var projectDto = Mapper.Map<Project, ProjectDto>(project);

            return Ok(projectDto);
        }

        //POST /api/projects
        [HttpPost]
        public IHttpActionResult CreateProject(ProjectDto projectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var project = Mapper.Map<ProjectDto, Project>(projectDto);
            this._context.Projects.Add(project);
            this._context.SaveChanges();
            projectDto.Id = project.Id;

            return Created(new Uri(Request.RequestUri + "/" + project.Id), projectDto);
        }

        //PUT /api/projects/{id}
        [HttpPut]
        public IHttpActionResult UpdateProject(int id, ProjectDto project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var projectInDb = this._context.Projects.SingleOrDefault(p => p.Id == id);

            if (projectInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(project, projectInDb);

            this._context.SaveChanges();

            return Ok();
        }

        //DELETE /api/projects/{id}
        [HttpDelete]
        public IHttpActionResult DeleteProject(int id)
        {
            var projectInDb = this._context.Projects.SingleOrDefault(p => p.Id == id);

            if (projectInDb == null)
            {
                return NotFound();
            }

            this._context.Projects.Remove(projectInDb);
            this._context.SaveChanges();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }
    }
}