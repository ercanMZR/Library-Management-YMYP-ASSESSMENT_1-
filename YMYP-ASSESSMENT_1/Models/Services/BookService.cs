using System.Net;
using YMYP_ASSESSMENT_1.Models.Repositories;
using YMYP_ASSESSMENT_1.Models.Repositories.Entities;
using YMYP_ASSESSMENT_1.Models.Services.Dtos;

namespace YMYP_ASSESSMENT_1.Models.Services
{
    public class BookService(IGenericRepository<Book> bookRepository, IUnitOfWork unitOfWork) : IBookService
    {
       // private readonly IGenericRepository<Book> _bookRepository = bookRepository;
        //private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<ServiceResult<List<BookDto>>> GetAllList()
        {
            var books = await bookRepository.GetAsync();
            if (books == null)
            {
                return ServiceResult<List<BookDto>>.Success(Enumerable.Empty<BookDto>().ToList());
            }

            var booksAsDto = books.Select(b => new BookDto
            {
                Id = b.Id,
                Author = b.Author,
                ISBN = b.ISBN,
                Genre = b.Genre,
                Language = b.Language,
                Summary = b.Summary,
                Title = b.Title,
                AvailableCopies = b.AvailableCopies,
                PublicationYear = b.PublicationYear
            }).ToList();

            return ServiceResult<List<BookDto>>.Success(booksAsDto);
        }

        public async Task<ServiceResult<BookDto>> Get(int id)
        {
            var book = await bookRepository.GetAsync(id);
            if (book == null)
            {
                return ServiceResult<BookDto>.Failure("Book not found", HttpStatusCode.NotFound);
            }

            var bookDto = new BookDto
            {
                Id = book.Id,
                Author = book.Author,
                ISBN = book.ISBN,
                Genre = book.Genre,
                Language = book.Language,
                Summary = book.Summary,
                Title = book.Title,
                AvailableCopies = book.AvailableCopies,
                PublicationYear = book.PublicationYear
            };

            return ServiceResult<BookDto>.Success(bookDto);
        }

        public async Task<ServiceResult<AddBookResponse>> AddAsync(AddBookRequest request)
        {
            var book = new Book
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

              bookRepository.Add(book);
             await unitOfWork.SaveChanges();

            var response = new AddBookResponse(book.Id);
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

            bookRepository.Update(bookToUpdate);
            await unitOfWork.SaveChanges();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            await bookRepository.DeleteAsync(id);
            await unitOfWork.SaveChanges();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
