using Core;
using CoreLayer;
using CoreLayer.Dto;
using CoreLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistence;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly ILogger<PersonaController> _logger;

        public IService<PersonaDto> _service { get; }

        public PersonaController(ILogger<PersonaController> logger, IService<PersonaDto> service)
        {
            _logger = logger;
            _service = service;
        }

        // GET: api/Persona/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            //var persona =_unitOfWork.Persona.GetBy(id);
            var data= _service.GetBy(id);
            return Ok(data);
        }

        // POST: api/Persona
        [HttpPost]
        public void Post(PersonaDto model)
        {
            var data = _service.Add(model);
        }

        // PUT: api/Persona/5
        //[HttpPut("{id}")]
        //public void Put(int id, PersonaDto model)
        //{
        //    var data = _service.Update(model);
            
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    _unitOfWork.Persona.Delete(id);
        //}
    }
}
