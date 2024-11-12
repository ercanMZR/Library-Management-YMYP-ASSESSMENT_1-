using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace YMYP_ASSESSMENT_1.Models.Repositories.Entities
{
    public class BookRepository(AppDbContext context) :IBookRepository

    {
        public async Task<List<Book>> GetAsync()
        {
            return await context.Books.ToListAsync();
        }

        public async Task<Book?> GetAsync(int id)
        {
            return await context.Books.FindAsync(id);
        }

        public async Task<Book> AddAsync(Book book)
        {
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            return book;
        }

        public async Task<Book?> UpdateAsync(Book book)
        {
            var existingBook = await context.Books.FindAsync(book.Id);
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

            context.Books.Update(existingBook);
            await context.SaveChangesAsync();
            return existingBook;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await context.Books.FindAsync(id);
            if (book == null)
            { return false; }

            context.Books.Remove(book);
            await context.SaveChangesAsync();
            return true;
        }


    }

  
}
