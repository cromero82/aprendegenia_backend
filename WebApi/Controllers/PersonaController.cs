using Core;
using CoreLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly ILogger<PersonaController> _logger;

        public IUnitOfWorks _unitOfWork { get; }

        public PersonaController(ILogger<PersonaController> logger, IUnitOfWorks unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Persona/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var persona =_unitOfWork.Persona.GetBy(id);
            return Ok(persona);
        }

        // POST: api/Persona
        [HttpPost]
        public void Post(Persona model)
        {
            _unitOfWork.Persona.Add(model);
        }

        // PUT: api/Persona/5
        [HttpPut("{id}")]
        public void Put(int id, Persona model)
        {
            _unitOfWork.Persona.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWork.Persona.Delete(id);
        }
    }
}
