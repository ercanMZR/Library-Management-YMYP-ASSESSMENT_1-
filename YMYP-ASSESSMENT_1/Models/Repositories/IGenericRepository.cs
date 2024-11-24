﻿using System.Linq.Expressions;

namespace YMYP_ASSESSMENT_1.Models.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T Add(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task DeleteAsync(int id);
        Task<List<T>> GetAsync();
        Task<T?> GetAsync(int id);
        void Update(T entity);
        IQueryable<T> Where(Func<T, bool> predicate);


    }
}