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
            var projectsQuery = this._context.Projects.Include(p => p.Client).Include(p=>p.Consultant);

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
    }
}