using System.Collections.Generic;

namespace SalonGarden.Core.Interfaces
{
    public interface ISalonGardenRepository
    {
        T GetById<T>(int id);
        IReadOnlyList<T> ListAll<T>();
        IReadOnlyList<T> List<T>(ISpecification<T> spec);
        T Add<T>(T entity);
        void Update<T>(T entity);
        void Delete<T>(T entity);        
    }
}