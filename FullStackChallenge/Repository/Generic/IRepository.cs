using FullStackChallenge.Model.Base;
using System;
using System.Collections.Generic;

namespace FullStackChallenge.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);

        T FindById(Guid id);

        List<T> FindAll();

        T Update(T item);

        void Delete(Guid id);

        List<T> FindWithPagedSearch(string query);
    }
}