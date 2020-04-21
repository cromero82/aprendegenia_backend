using CoreLayer.Models;
using CoreLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.Repositories
{
    public class PersonaRepository : IPersonaRepository<Persona>
    {
        private readonly ApplicationDbContext _context;

        public PersonaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Persona GetPersona(int id)
        {
            return getQueryBase().SingleOrDefault(g => g.Id == id);
        }

        
        public void Add(Persona persona)
        {
            _context.Persona.Add(persona);
        }


        public Persona GetBy(int Id)
        {
            return getQueryBase().SingleOrDefault(g => g.Id == Id);
        }

        public IEnumerable<Persona> GetAllBy(string document)
        {
            return getQueryBase()
                // Replace parameters
                .Where(g => g.Nombres == document)
                .ToList();
        }

        public void Delete(int id)
        {
            var dbItem = _context.Persona.Find(id);
            // here modify the field to delete pasive         
            this.Update(dbItem);
        }

        public void Update(Persona persona)
        {
            _context.Persona.Update(persona);
        }

        public IQueryable<Persona> getQueryBase()
        {
            return _context.Persona
                // Include statements..
                .Where(f => f.Id > 0)
                ;
        }
    }
}
