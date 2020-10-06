using FullStackChallenge.Model.Base;
using FullStackChallenge.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FullStackChallenge.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly SqlServerContext _context;
        private readonly DbSet<T> dataset;

        public GenericRepository(SqlServerContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

            return item;
        }

        public void Delete(Guid
            id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                if (result != null)
                    dataset.Remove(result);

                _context.SaveChanges();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public List<T> FindAll() =>
            dataset.ToList();

        public T FindById(Guid id) =>
            dataset.SingleOrDefault(x => x.Id.Equals(id));

        public List<T> FindWithPagedSearch(string query)
        {
            return dataset.FromSqlRaw(query).ToList();
        }

        public T Update(T item)
        {
            if (!Exist(item.Id))
                return null;

            var result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));

            try
            {
                _context.Entry(result).CurrentValues.SetValues(item);

                _context.SaveChanges();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

            return item;
        }

        private bool Exist(Guid id) =>
            dataset.Any(x => x.Id.Equals(id));
    }
}