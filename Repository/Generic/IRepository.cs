using apiRest.Model.Base;
using System.Collections.Generic;

namespace apiRest.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindyById(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exists(long id);
    }
}