using CoreLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoreLayer.Repositories
{
    public interface IPersonaRepository<T>
    {
        T GetBy(int Id);
        IEnumerable<T> GetAllBy(string document);
        void Add(T model);
        void Delete(int id);
        void Update(T model);
       abstract  IQueryable<T> getQueryBase();
    }
}
