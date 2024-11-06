using Microsoft.EntityFrameworkCore;

namespace YMYP_ASSESSMENT_1.Models.Repositories.Entities
{
    public class BookRepository(AppDbContext context):IBookRepository

    {
        public async Task<List<Book>> GetAsync()
        {
            return await context.Books.ToListAsync();
        }

        public async Task<Book?> GetAsync(int id)
        {
            return await context.Books.FindAsync(id);
        }

        public async Task<Book>AddAsync(Book book)
        {
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            return book;
        }
    }
}
