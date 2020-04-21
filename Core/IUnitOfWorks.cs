using CoreLayer.Models;
using CoreLayer.Repositories;

namespace Core
{
    public interface IUnitOfWorks
    {
        IPersonaRepository<Persona> Persona { get; }
        void Complete();
    }
}
