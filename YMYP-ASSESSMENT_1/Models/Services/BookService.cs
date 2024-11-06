using Microsoft.EntityFrameworkCore;
using System.Net;
using YMYP_ASSESSMENT_1.Models.Repositories.Entities;
using YMYP_ASSESSMENT_1.Models.Services;
using YMYP_ASSESSMENT_1.Models.Services.Dtos;

namespace YMYP_ASSESSMENT_1.Models.Services
{
    public class BookService(IBookRepository bookRepository):IBookService
    {
      
        public async Task<ServiceResult<List<BookDto>>>GetAllList()
         {
           var books = await bookRepository.GetAsync();

            var booksAsDto= new List<BookDto>();

            books.ForEach(b =>
            {
                booksAsDto.Add(new BookDto
                {
                  Id = b.Id,
                    Author = b.Author,
                    ISBN = b.ISBN,
                    Genre = b.Genre,
                    Language = b.Language,
                    Summary = b.Summary,
                    Title = b.Title,
                    AvailableCopies = b.AvailableCopies,
                    PublicationYear = b.PublicationYear,
                    
                });
            });

            return ServiceResult<List<BookDto>>.Success(booksAsDto);
        }


        public async Task<ServiceResult<BookDto>>Get(int id)
        {
            var book =await bookRepository.GetAsync(id);

            if (book == null)
            {
                return ServiceResult<BookDto>.Failure("Book not found",HttpStatusCode.NotFound);
            }

            var bookAsDto= new BookDto { 
                Id = id,
                Author = book.Author,
                ISBN = book.ISBN,
                Genre = book.Genre,  
                Language = book.Language,
                Summary = book.Summary,
                Title = book.Title,
                AvailableCopies = book.AvailableCopies,
                PublicationYear = book.PublicationYear,
                
            };
            return ServiceResult<BookDto>.Success(bookAsDto);
        }
    }
}
