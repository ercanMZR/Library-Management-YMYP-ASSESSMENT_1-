namespace YMYP_ASSESSMENT_1.Models.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanges();
    }
}
