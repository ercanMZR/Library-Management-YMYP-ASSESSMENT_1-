
using YMYP_ASSESSMENT_1.Models.Repositories.Entities;

namespace YMYP_ASSESSMENT_1.Models.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public Task<int> SaveChanges()
        {
            return context.SaveChangesAsync();
        }
    }
}
