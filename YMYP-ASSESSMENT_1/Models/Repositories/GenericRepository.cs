using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YMYP_ASSESSMENT_1.Models.Repositories.Entities;

namespace YMYP_ASSESSMENT_1.Models.Repositories
{
    public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : class
    {
        public readonly DbSet<T> DbSet = context.Set<T>();

        public IQueryable<T> Where(Func<T, bool> predicate)
        {
            return DbSet.Where(predicate).AsQueryable();
        }

        //Asqueryable dataları veritabanına yansıtmadan dönüyor.Orderbydan sonra tolistle vetitabanına gidiyor.Bu şkeilde sistmei yormuyoruz.İşlemi Sql e yaptırıyoruz.
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AnyAsync(predicate);
        }

        public async Task<List<T>> GetAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }
        public T Add(T entity)
        {
            DbSet.Add(entity);

            return entity;
        }
        // await context.SaveChangesAsync();// Unit of work eklediğimde veritabanına buradan eklemiyorum.

        //Burada fazladan method yazmama gerek yok .Genel temel methotları yazıyoruz.

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await DbSet.FindAsync(id);
            DbSet.Remove(entity);
        }
    }


}
