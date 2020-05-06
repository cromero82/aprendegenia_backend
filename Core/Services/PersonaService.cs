using Infraestructura;
using Infraestructura.Dto;
using Infraestructura.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public class PersonaService : IService<PersonaDto>
    {
        public PersonaService(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
            _jresult = new JResult();
        }
        public JResult _jresult { get; set; }
        public IUnitOfWorks _unitOfWorks { get; }

        public JResult Add(PersonaDto model)
        {
            return _jresult;
        }

        public JResult Delete(int id)
        {
            return _jresult;
        }

        public JResult GetAllBy(PersonaDto model, string field)
        {
            return _jresult;
        }

        public JResult GetBy(int id)
        {
            var data = _unitOfWorks.Persona.GetBy(id);
            _jresult.Data = data;
            return _jresult;
        }

        public JResult Update(PersonaDto model)
        {
            return _jresult;
        }
    }
}
