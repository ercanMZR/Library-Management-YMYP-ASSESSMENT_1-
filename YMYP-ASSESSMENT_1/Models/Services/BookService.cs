using Azure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection;
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
        public async Task<ServiceResult<AddBookResponse>> AddAsync(AddBookRequest request)
        {
            var book = new Book()
            {
                Title = request.Title,
                Author = request.Author,
                PublicationYear = request.PublicationYear,
                ISBN = request.ISBN,
                Genre = request.Genre,
                Publisher = request.Publisher,
                PageCount = request.PageCount,
                Language = request.Language,
                Summary = request.Summary,
                AvailableCopies = request.AvailableCopies


            };

            var newBook = await bookRepository.AddAsync(book);
            var response = new AddBookResponse(newBook.Id);
            return ServiceResult<AddBookResponse>.Success(response, HttpStatusCode.Created);
        }
        public async Task<ServiceResult> UpdateAsync(UpdateBookRequest request)
        {
            var bookToUpdate = new Book
            {
                Id = request.Id,
                Title = request.Title,
                Author = request.Author,
                ISBN = request.ISBN,
                Genre = request.Genre,
                Publisher = request.Publisher,
                PageCount = (int)request.PageCount,
                Language = request.Language,
                Summary = request.Summary,
                AvailableCopies = (int)request.AvailableCopies
            };

            await bookRepository.UpdateAsync(bookToUpdate);

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            await bookRepository.DeleteAsync(id);
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

    }
}
