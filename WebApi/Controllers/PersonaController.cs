using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly ILogger<PersonaController> _logger;
        private readonly ApplicationDbContext dbContext;

        public PersonaController(ILogger<PersonaController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        // GET: api/Persona
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", "value3" };
        }

        // GET: api/Persona/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult<Persona> Get(int id)
        {
            var persona = dbContext.Persona.Get( x=> x.Id).FirstOrDefault();
            return persona;
        }

        // POST: api/Persona
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Persona/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
