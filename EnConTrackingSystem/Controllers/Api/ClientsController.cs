using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using EnConTrackingSystem.Dtos;
using EnConTrackingSystem.Models;

namespace EnConTrackingSystem.Controllers.Api
{
    public class ClientsController : ApiController
    {
        private ApplicationDbContext _context;

        public ClientsController()
        {
            this._context = new ApplicationDbContext();
        }

        //GET /api/clients
        public IHttpActionResult GetClients(string query = null)
        {
            var clientQuery = this._context.Clients.AsQueryable();

            if (!String.IsNullOrWhiteSpace(query))
            {
                clientQuery = (DbSet<Client>)clientQuery.Where(c => c.Name.Contains(query));
            }

            var clientsDto = clientQuery.ToList().Select(Mapper.Map<Client, ClientDto>);

            return Ok(clientsDto);
        }


        //GET /api/clients/{id}
        public IHttpActionResult GetClient(int id)
        {
            var client = this._context.Clients.FirstOrDefault(c => c.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            var clientDto = Mapper.Map<Client, ClientDto>(client);
            return Ok(clientDto);
        }

        //POST /api/clients
        [HttpPost]
        public IHttpActionResult CreateClient(ClientDto clientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var client = Mapper.Map<ClientDto, Client>(clientDto);
            this._context.Clients.Add(client);
            this._context.SaveChanges();
            clientDto.Id = client.Id;

            return Created(new Uri(Request.RequestUri + "/" + client.Id), clientDto);
        }

        //PUT /api/clients/{id}
        [HttpPut]
        public IHttpActionResult UpdateClient(int id, ClientDto clientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var clientInDb = this._context.Clients.SingleOrDefault(c => c.Id == id);

            if (clientInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(clientDto, clientInDb);

            this._context.SaveChanges();

            return Ok();
        }

        //DELETE /api/clients/{id}
        [HttpDelete]
        public IHttpActionResult DeleteClient(int id)
        {
            var clientInDb = this._context.Clients.Include(c => c.Projects).SingleOrDefault(c => c.Id == id);

            if (clientInDb == null)
            {
                return NotFound();
            }

            //Move all project to default client (No Client)
            foreach (var project in clientInDb.Projects)
            {
                project.ClientId = Defaults.ClientId;
            }

            this._context.Clients.Remove(clientInDb);
            this._context.SaveChanges();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }
    }
}