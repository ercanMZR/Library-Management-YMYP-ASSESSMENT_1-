using YMYP_ASSESSMENT_1.Models.Services.Dtos;

namespace YMYP_ASSESSMENT_1.Models.Services
{
    public interface IBookService
    {
        Task<ServiceResult<List<BookDto>>> GetAllList();

        Task<ServiceResult<BookDto>> Get(int id);

        Task<ServiceResult<AddBookResponse>> AddAsync(AddBookRequest request);

        Task<ServiceResult> UpdateAsync(UpdateBookRequest request);

        Task<ServiceResult> DeleteAsync(int id);


    }
}
