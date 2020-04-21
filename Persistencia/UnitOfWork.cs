using Core;
using CoreLayer.Models;
using CoreLayer.Repositories;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWorks
    {
        private readonly ApplicationDbContext _context;
        public IPersonaRepository<Persona> Persona { get; private set; }
        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
