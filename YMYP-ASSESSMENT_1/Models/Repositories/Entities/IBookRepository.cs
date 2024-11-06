namespace YMYP_ASSESSMENT_1.Models.Repositories.Entities
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAsync();
        Task<Book?> GetAsync(int id);

        Task<Book>AddAsync(Book book);
    }
}