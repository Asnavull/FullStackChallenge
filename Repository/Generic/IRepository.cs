using System;
using System.Collections.Generic;

namespace Repository.Generic
{
    public interface IRepository<T>
    {
        T Create(T entity);

        T FindById(Guid id);

        List<T> FindAll();

        T Update(T entity);

        void Delete(Guid id);
    }
}