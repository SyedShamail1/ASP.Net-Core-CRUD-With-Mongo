using System.Collections.Generic;

namespace MongoCRUD.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        T Save(T entity);

        T Get(string id);

        List<T> GetAll();

        string Delete(string id);
    }
}
