using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace YMYP_ASSESSMENT_1.Models.Repositories.Entities
{


    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
     

        public BookRepository(AppDbContext context) : base(context)
        {
           
        }

        public async Task<List<Book>> GetAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Book?> GetAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<Book> AddAsync(Book book)
        {
            await DbSet.AddAsync(book);
            await context.SaveChangesAsync();
            return book;
        }

        public async Task<Book?> UpdateAsync(Book book)
        {
            var existingBook = await DbSet.FindAsync(book.Id);
            if (existingBook == null)
            {
                return null;
            }

            existingBook.Id = book.Id;
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.ISBN = book.ISBN;
            existingBook.Genre = book.Genre;
            existingBook.Publisher = book.Publisher;
            existingBook.PageCount = book.PageCount;
            existingBook.Summary = book.Summary;
            existingBook.AvailableCopies = book.AvailableCopies;

            DbSet.Update(existingBook);
            await context.SaveChangesAsync();//base.context diye yazarsak
            return existingBook;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await DbSet.FindAsync(id);
            if (book == null)
            { return false; }

            DbSet.Remove(book);
            await context.SaveChangesAsync();
            return true;
        }

        

    }
   

  
}
