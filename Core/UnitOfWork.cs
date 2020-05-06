using Infraestructura.Repositories;
using Domain.Models;

namespace Domain
{
    public interface IUnitOfWorks
    {
        IPersonaRepository<Persona> Persona { get; }
        void Complete();
    }

    public class UnitOfWork : IUnitOfWorks
    {
        private readonly ApplicationDbContext _context;
        public IPersonaRepository<Persona> Persona { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            // Other reposistories
        }
        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
