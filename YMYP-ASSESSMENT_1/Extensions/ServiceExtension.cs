using YMYP_ASSESSMENT_1.Models.Repositories;
using YMYP_ASSESSMENT_1.Models.Repositories.Entities;
using YMYP_ASSESSMENT_1.Models.Services;

namespace YMYP_ASSESSMENT_1.Extensions
{
    public static class ServiceExtension
    {
        public static void CustomServices(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
