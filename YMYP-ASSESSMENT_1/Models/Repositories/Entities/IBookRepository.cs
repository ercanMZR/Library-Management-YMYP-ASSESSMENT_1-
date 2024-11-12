
namespace YMYP_ASSESSMENT_1.Models.Repositories.Entities
{
    public interface IBookRepository
    {
        Task<Book> AddAsync(Book book);
        Task<bool> DeleteAsync(int id);
        Task<List<Book>> GetAsync();
        Task<Book?> GetAsync(int id);
        Task<Book?> UpdateAsync(Book book);
    }
}