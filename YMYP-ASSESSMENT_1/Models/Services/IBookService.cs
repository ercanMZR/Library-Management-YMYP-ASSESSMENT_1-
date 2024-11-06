using YMYP_ASSESSMENT_1.Models.Services.Dtos;

namespace YMYP_ASSESSMENT_1.Models.Services
{
    public interface IBookService
    {
        Task<ServiceResult<List<BookDto>>> GetAllList();

        Task<ServiceResult<BookDto>> Get(int id);

      
    }
}
